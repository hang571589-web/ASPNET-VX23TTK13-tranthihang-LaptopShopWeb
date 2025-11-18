using LaptopShopWeb.BLL.DTOs;

namespace LaptopShopWeb.BLL.Services;

public interface ICartService
{
    Task<CartDto?> GetCartByUserIdAsync(int userId);
    Task<CartDto?> GetCartWithDetailsAsync(int userId);
    Task<CartDto> AddToCartAsync(int userId, int productId, int? variantId, int quantity);
    Task<CartDto> UpdateCartItemAsync(int userId, int cartItemId, int quantity);
    Task UpdateCartItemQuantityAsync(int cartItemId, int quantity);
    Task<CartDto> RemoveFromCartAsync(int userId, int cartItemId);
    Task RemoveFromCartAsync(int cartItemId);
    Task ClearCartAsync(int userId);
    Task<decimal> GetCartTotalAsync(int userId);
}
