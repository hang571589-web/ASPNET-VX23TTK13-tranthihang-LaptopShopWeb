using LaptopShopWeb.BLL.DTOs;
using LaptopShopWeb.BLL.Mappers;
using LaptopShopWeb.DAL.UnitOfWork;
using LaptopShopWeb.Entity;

namespace LaptopShopWeb.BLL.Services;

public class CartService : ICartService
{
    private readonly IUnitOfWork _unitOfWork;

    public CartService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CartDto?> GetCartByUserIdAsync(int userId)
    {
        var cart = await _unitOfWork.Carts.GetCartWithItemsAsync(userId);
        return cart?.ToDto();
    }

    public async Task<CartDto?> GetCartWithDetailsAsync(int userId)
    {
        // Alias method that returns the same result
        return await GetCartByUserIdAsync(userId);
    }

    public async Task<CartDto> AddToCartAsync(int userId, int productId, int? variantId, int quantity)
    {
        // Get or create cart
        var cart = await _unitOfWork.Carts.GetCartWithItemsAsync(userId);
        if (cart == null)
        {
            cart = new Cart { UserId = userId };
            await _unitOfWork.Carts.AddAsync(cart);
            await _unitOfWork.SaveChangesAsync();
            
            // Reload cart with items
            cart = await _unitOfWork.Carts.GetCartWithItemsAsync(userId);
        }

        // Get product to check price
        var product = await _unitOfWork.Products.GetProductWithVariantsAsync(productId);
        if (product == null)
            throw new Exception("Product not found");

        // Calculate price
        decimal price = product.Price;
        if (variantId.HasValue)
        {
            var variant = product.ProductVariants?.FirstOrDefault(v => v.Id == variantId.Value);
            if (variant != null)
            {
                price = variant.Price;
            }
        }

        // Check if item already exists in cart
        var existingItem = cart!.CartItems?
            .FirstOrDefault(ci => ci.ProductId == productId && ci.ProductVariantId == variantId);

        if (existingItem != null)
        {
            // Update quantity
            existingItem.Quantity += quantity;
            _unitOfWork.Repository<CartItem>().Update(existingItem);
        }
        else
        {
            // Add new item
            var cartItem = new CartItem
            {
                CartId = cart.Id,
                ProductId = productId,
                ProductVariantId = variantId,
                Quantity = quantity,
                Price = price
            };
            await _unitOfWork.Repository<CartItem>().AddAsync(cartItem);
        }

        await _unitOfWork.SaveChangesAsync();
        
        // Reload cart
        cart = await _unitOfWork.Carts.GetCartWithItemsAsync(userId);
        return cart!.ToDto();
    }

    public async Task<CartDto> UpdateCartItemAsync(int userId, int cartItemId, int quantity)
    {
        var cartItem = await _unitOfWork.Repository<CartItem>().GetByIdAsync(cartItemId);
        if (cartItem == null)
            throw new Exception("Cart item not found");

        if (quantity <= 0)
        {
            _unitOfWork.Repository<CartItem>().Delete(cartItem);
        }
        else
        {
            cartItem.Quantity = quantity;
            _unitOfWork.Repository<CartItem>().Update(cartItem);
        }

        await _unitOfWork.SaveChangesAsync();
        
        var cart = await _unitOfWork.Carts.GetCartWithItemsAsync(userId);
        return cart!.ToDto();
    }

    public async Task UpdateCartItemQuantityAsync(int cartItemId, int quantity)
    {
        var cartItem = await _unitOfWork.Repository<CartItem>().GetByIdAsync(cartItemId);
        if (cartItem == null)
            throw new Exception("Cart item not found");

        if (quantity <= 0)
        {
            _unitOfWork.Repository<CartItem>().Delete(cartItem);
        }
        else
        {
            cartItem.Quantity = quantity;
            _unitOfWork.Repository<CartItem>().Update(cartItem);
        }

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<CartDto> RemoveFromCartAsync(int userId, int cartItemId)
    {
        var cartItem = await _unitOfWork.Repository<CartItem>().GetByIdAsync(cartItemId);
        if (cartItem != null)
        {
            _unitOfWork.Repository<CartItem>().Delete(cartItem);
            await _unitOfWork.SaveChangesAsync();
        }

        var cart = await _unitOfWork.Carts.GetCartWithItemsAsync(userId);
        return cart!.ToDto();
    }

    public async Task RemoveFromCartAsync(int cartItemId)
    {
        var cartItem = await _unitOfWork.Repository<CartItem>().GetByIdAsync(cartItemId);
        if (cartItem != null)
        {
            _unitOfWork.Repository<CartItem>().Delete(cartItem);
            await _unitOfWork.SaveChangesAsync();
        }
    }

    public async Task ClearCartAsync(int userId)
    {
        await _unitOfWork.Carts.ClearCartAsync(userId);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<decimal> GetCartTotalAsync(int userId)
    {
        return await _unitOfWork.Carts.GetCartTotalAsync(userId);
    }
}
