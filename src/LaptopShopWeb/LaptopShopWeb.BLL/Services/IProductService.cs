using LaptopShopWeb.BLL.DTOs;

namespace LaptopShopWeb.BLL.Services;

public interface IProductService
{
    Task<List<ProductDto>> GetAllProductsAsync();
    Task<List<ProductDto>> GetActiveProductsAsync();
    Task<List<ProductDto>> GetFeaturedProductsAsync();
    Task<List<ProductDto>> GetProductsByCategoryAsync(int categoryId);
    Task<ProductDto?> GetProductByIdAsync(int id);
    Task<ProductDto?> GetProductWithDetailsAsync(int id);
    Task<List<ProductDto>> SearchProductsAsync(string searchTerm);
    Task<ProductDto> CreateProductAsync(ProductDto productDto);
    Task<ProductDto> UpdateProductAsync(ProductDto productDto);
    Task<bool> DeleteProductAsync(int id);
    Task<bool> UpdateStockAsync(int productId, int? variantId, int quantity);
}
