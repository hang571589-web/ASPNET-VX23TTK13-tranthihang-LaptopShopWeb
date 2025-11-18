using LaptopShopWeb.BLL.DTOs;

namespace LaptopShopWeb.BLL.Services;

public interface IOrderService
{
    Task<List<OrderDto>> GetOrdersByUserIdAsync(int userId);
    Task<OrderDto?> GetOrderByIdAsync(int orderId);
    Task<OrderDto?> GetOrderWithDetailsAsync(int orderId); // Alias with details
    Task<OrderDto?> GetOrderByNumberAsync(string orderNumber);
    Task<int> CreateOrderAsync(CreateOrderDto createOrderDto);
    Task<OrderDto> CreateOrderAsync(int userId, string shippingAddress, string shippingCity, string shippingPhone, string? paymentMethod, string? notes);
    Task<OrderDto> UpdateOrderStatusAsync(int orderId, string status);
    Task<List<OrderDto>> GetOrdersByStatusAsync(string status);
    Task<List<OrderDto>> GetRecentOrdersAsync(int count);
}
