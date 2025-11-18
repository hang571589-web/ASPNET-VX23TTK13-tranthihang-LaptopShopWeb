using LaptopShopWeb.Entity;
using Microsoft.EntityFrameworkCore;

namespace LaptopShopWeb.DAL.Repositories;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId)
    {
        return await _dbSet
            .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product)
            .Include(o => o.OrderDetails)
                .ThenInclude(od => od.ProductVariant)
            .Where(o => o.UserId == userId)
            .OrderByDescending(o => o.OrderDate)
            .ToListAsync();
    }

    public async Task<Order?> GetOrderWithDetailsAsync(int orderId)
    {
        return await _dbSet
            .Include(o => o.User)
            .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product)
            .Include(o => o.OrderDetails)
                .ThenInclude(od => od.ProductVariant)
            .FirstOrDefaultAsync(o => o.Id == orderId);
    }

    public async Task<string> GenerateOrderNumberAsync()
    {
        var timestamp = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
        var random = new Random().Next(1000, 9999);
        var orderNumber = $"ORD{timestamp}{random}";

        // Ensure uniqueness
        while (await _dbSet.AnyAsync(o => o.OrderNumber == orderNumber))
        {
            random = new Random().Next(1000, 9999);
            orderNumber = $"ORD{timestamp}{random}";
        }

        return orderNumber;
    }

    public async Task<IEnumerable<Order>> GetOrdersByStatusAsync(string status)
    {
        return await _dbSet
            .Include(o => o.User)
            .Include(o => o.OrderDetails)
            .Where(o => o.Status == status)
            .OrderByDescending(o => o.OrderDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<Order>> GetRecentOrdersAsync(int count)
    {
        return await _dbSet
            .Include(o => o.User)
            .Include(o => o.OrderDetails)
            .OrderByDescending(o => o.OrderDate)
            .Take(count)
            .ToListAsync();
    }
}
