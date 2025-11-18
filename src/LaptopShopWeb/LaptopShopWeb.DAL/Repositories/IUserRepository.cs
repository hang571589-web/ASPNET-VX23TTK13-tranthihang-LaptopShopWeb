using LaptopShopWeb.Entity;

namespace LaptopShopWeb.DAL.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
    Task<bool> EmailExistsAsync(string email);
    Task<IEnumerable<User>> GetUsersByRoleAsync(string role);
}
