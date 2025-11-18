using LaptopShopWeb.Entity;

namespace LaptopShopWeb.DAL.Repositories;

public interface IOrderRepository : IRepository<Order>
{
    Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId);
    Task<Order?> GetOrderWithDetailsAsync(int orderId);
    Task<string> GenerateOrderNumberAsync();
    Task<IEnumerable<Order>> GetOrdersByStatusAsync(string status);
    Task<IEnumerable<Order>> GetRecentOrdersAsync(int count);
}
