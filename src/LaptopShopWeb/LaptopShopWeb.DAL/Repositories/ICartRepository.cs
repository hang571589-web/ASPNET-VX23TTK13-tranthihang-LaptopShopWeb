using LaptopShopWeb.Entity;

namespace LaptopShopWeb.DAL.Repositories;

public interface ICartRepository : IRepository<Cart>
{
    Task<Cart?> GetCartByUserIdAsync(int userId);
    Task<Cart?> GetCartWithItemsAsync(int userId);
    Task ClearCartAsync(int userId);
    Task<decimal> GetCartTotalAsync(int userId);
}
