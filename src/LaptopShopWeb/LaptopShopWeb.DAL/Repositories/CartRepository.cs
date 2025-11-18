using LaptopShopWeb.Entity;
using Microsoft.EntityFrameworkCore;

namespace LaptopShopWeb.DAL.Repositories;

public class CartRepository : Repository<Cart>, ICartRepository
{
    public CartRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<Cart?> GetCartByUserIdAsync(int userId)
    {
        return await _dbSet
            .FirstOrDefaultAsync(c => c.UserId == userId);
    }

    public async Task<Cart?> GetCartWithItemsAsync(int userId)
    {
        return await _dbSet
            .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Product)
            .Include(c => c.CartItems)
                .ThenInclude(ci => ci.ProductVariant)
            .FirstOrDefaultAsync(c => c.UserId == userId);
    }

    public async Task ClearCartAsync(int userId)
    {
        var cart = await GetCartWithItemsAsync(userId);
        if (cart != null && cart.CartItems.Any())
        {
            _context.CartItems.RemoveRange(cart.CartItems);
        }
    }

    public async Task<decimal> GetCartTotalAsync(int userId)
    {
        var cart = await GetCartWithItemsAsync(userId);
        if (cart == null || !cart.CartItems.Any())
            return 0;

        return cart.CartItems.Sum(ci => ci.Price * ci.Quantity);
    }
}
