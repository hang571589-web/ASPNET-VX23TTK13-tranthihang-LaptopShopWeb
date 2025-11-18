using LaptopShopWeb.Entity;

namespace LaptopShopWeb.DAL.Repositories;

public interface IProductRepository : IRepository<Product>
{
    Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId);
    Task<IEnumerable<Product>> GetFeaturedProductsAsync(int count);
    Task<Product?> GetProductWithVariantsAsync(int productId);
    Task<Product?> GetProductWithCategoryAsync(int productId);
    Task<IEnumerable<Product>> SearchProductsAsync(string keyword);
    Task<IEnumerable<Product>> GetActiveProductsAsync();
    Task<IEnumerable<Product>> GetProductsWithVariantsAsync();
}
