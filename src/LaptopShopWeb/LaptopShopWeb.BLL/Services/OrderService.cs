using LaptopShopWeb.BLL.DTOs;
using LaptopShopWeb.BLL.Mappers;
using LaptopShopWeb.DAL.UnitOfWork;
using LaptopShopWeb.Entity;

namespace LaptopShopWeb.BLL.Services;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICartService _cartService;
    private readonly IProductService _productService;

    public OrderService(IUnitOfWork unitOfWork, ICartService cartService, IProductService productService)
    {
        _unitOfWork = unitOfWork;
        _cartService = cartService;
        _productService = productService;
    }

    public async Task<List<OrderDto>> GetOrdersByUserIdAsync(int userId)
    {
        var orders = await _unitOfWork.Orders.GetOrdersByUserIdAsync(userId);
        return orders.Select(o => o.ToDto()).ToList();
    }

    public async Task<OrderDto?> GetOrderByIdAsync(int orderId)
    {
        var order = await _unitOfWork.Orders.GetOrderWithDetailsAsync(orderId);
        return order?.ToDto();
    }

    public async Task<OrderDto?> GetOrderWithDetailsAsync(int orderId)
    {
        // Alias method
        return await GetOrderByIdAsync(orderId);
    }

    public async Task<OrderDto?> GetOrderByNumberAsync(string orderNumber)
    {
        var orders = await _unitOfWork.Orders.GetAllAsync();
        var order = orders.FirstOrDefault(o => o.OrderNumber == orderNumber);
        if (order != null)
        {
            order = await _unitOfWork.Orders.GetOrderWithDetailsAsync(order.Id);
        }
        return order?.ToDto();
    }

    public async Task<OrderDto> CreateOrderAsync(int userId, string shippingAddress, string shippingCity, 
        string shippingPhone, string? paymentMethod, string? notes)
    {
        // Get cart
        var cartDto = await _cartService.GetCartByUserIdAsync(userId);
        if (cartDto == null || !cartDto.CartItems.Any())
            throw new Exception("Cart is empty");

        // Start transaction
        await _unitOfWork.BeginTransactionAsync();

        try
        {
            // Generate order number
            var orderNumber = await _unitOfWork.Orders.GenerateOrderNumberAsync();

            // Create order
            var order = new Order
            {
                OrderNumber = orderNumber,
                UserId = userId,
                OrderDate = DateTime.UtcNow,
                TotalAmount = cartDto.Total,
                Status = "Pending",
                ShippingAddress = shippingAddress,
                ShippingCity = shippingCity,
                ShippingPhone = shippingPhone,
                PaymentMethod = paymentMethod ?? "COD",
                Notes = notes
            };

            await _unitOfWork.Orders.AddAsync(order);
            await _unitOfWork.SaveChangesAsync();

            // Create order details
            foreach (var cartItem in cartDto.CartItems)
            {
                var orderDetail = new OrderDetail
                {
                    OrderId = order.Id,
                    ProductId = cartItem.ProductId,
                    ProductVariantId = cartItem.ProductVariantId,
                    VariantDescription = cartItem.VariantName,
                    Quantity = cartItem.Quantity,
                    UnitPrice = cartItem.Price
                };

                await _unitOfWork.Repository<OrderDetail>().AddAsync(orderDetail);

                // Update stock
                await _productService.UpdateStockAsync(cartItem.ProductId, cartItem.ProductVariantId, cartItem.Quantity);
            }

            await _unitOfWork.SaveChangesAsync();

            // Clear cart
            await _cartService.ClearCartAsync(userId);

            // Commit transaction
            await _unitOfWork.CommitTransactionAsync();

            // Return order with details
            var createdOrder = await _unitOfWork.Orders.GetOrderWithDetailsAsync(order.Id);
            return createdOrder!.ToDto();
        }
        catch
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }

    public async Task<int> CreateOrderAsync(CreateOrderDto createOrderDto)
    {
        // Get cart
        var cartDto = await _cartService.GetCartByUserIdAsync(createOrderDto.UserId);
        if (cartDto == null || !cartDto.CartItems.Any())
            throw new Exception("Cart is empty");

        // Start transaction
        await _unitOfWork.BeginTransactionAsync();

        try
        {
            // Generate order number
            var orderNumber = await _unitOfWork.Orders.GenerateOrderNumberAsync();

            // Create order
            var order = new Order
            {
                OrderNumber = orderNumber,
                UserId = createOrderDto.UserId,
                OrderDate = DateTime.UtcNow,
                TotalAmount = cartDto.Total,
                Status = "Pending",
                ShippingAddress = createOrderDto.ShippingAddress,
                ShippingCity = createOrderDto.City,
                ShippingPhone = createOrderDto.PhoneNumber,
                PaymentMethod = createOrderDto.PaymentMethod,
                Notes = createOrderDto.Notes
            };

            await _unitOfWork.Orders.AddAsync(order);
            await _unitOfWork.SaveChangesAsync();

            // Create order details
            foreach (var cartItem in cartDto.CartItems)
            {
                var orderDetail = new OrderDetail
                {
                    OrderId = order.Id,
                    ProductId = cartItem.ProductId,
                    ProductVariantId = cartItem.ProductVariantId,
                    VariantDescription = cartItem.VariantName,
                    Quantity = cartItem.Quantity,
                    UnitPrice = cartItem.Price
                };

                await _unitOfWork.Repository<OrderDetail>().AddAsync(orderDetail);

                // Update stock
                await _productService.UpdateStockAsync(cartItem.ProductId, cartItem.ProductVariantId, cartItem.Quantity);
            }

            await _unitOfWork.SaveChangesAsync();

            // Clear cart
            await _cartService.ClearCartAsync(createOrderDto.UserId);

            // Commit transaction
            await _unitOfWork.CommitTransactionAsync();

            return order.Id;
        }
        catch
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }

    public async Task<OrderDto> UpdateOrderStatusAsync(int orderId, string status)
    {
        var order = await _unitOfWork.Orders.GetByIdAsync(orderId);
        if (order == null)
            throw new Exception("Order not found");

        order.Status = status;
        _unitOfWork.Orders.Update(order);
        await _unitOfWork.SaveChangesAsync();

        var updatedOrder = await _unitOfWork.Orders.GetOrderWithDetailsAsync(orderId);
        return updatedOrder!.ToDto();
    }

    public async Task<List<OrderDto>> GetOrdersByStatusAsync(string status)
    {
        var orders = await _unitOfWork.Orders.GetOrdersByStatusAsync(status);
        return orders.Select(o => o.ToDto()).ToList();
    }

    public async Task<List<OrderDto>> GetRecentOrdersAsync(int count)
    {
        var orders = await _unitOfWork.Orders.GetRecentOrdersAsync(count);
        return orders.Select(o => o.ToDto()).ToList();
    }
}
