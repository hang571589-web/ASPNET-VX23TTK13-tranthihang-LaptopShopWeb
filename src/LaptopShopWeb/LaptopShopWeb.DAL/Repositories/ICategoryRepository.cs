using LaptopShopWeb.Entity;

namespace LaptopShopWeb.DAL.Repositories;

public interface ICategoryRepository : IRepository<Category>
{
    Task<Category?> GetCategoryWithProductsAsync(int categoryId);
    Task<IEnumerable<Category>> GetActiveCategoriesAsync();
    Task<Category?> GetCategoryBySlugAsync(string slug);
}
