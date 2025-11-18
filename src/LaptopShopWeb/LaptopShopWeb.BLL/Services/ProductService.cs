using LaptopShopWeb.BLL.DTOs;
using LaptopShopWeb.BLL.Mappers;
using LaptopShopWeb.DAL.UnitOfWork;
using LaptopShopWeb.Entity;

namespace LaptopShopWeb.BLL.Services;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<ProductDto>> GetAllProductsAsync()
    {
        var products = await _unitOfWork.Products.GetProductsWithVariantsAsync();
        return products.Select(p => p.ToDto()).ToList();
    }

    public async Task<List<ProductDto>> GetActiveProductsAsync()
    {
        var products = await _unitOfWork.Products.GetActiveProductsAsync();
        return products.Select(p => p.ToDto()).ToList();
    }

    public async Task<List<ProductDto>> GetFeaturedProductsAsync()
    {
        var products = await _unitOfWork.Products.GetFeaturedProductsAsync(10);
        return products.Select(p => p.ToDto()).ToList();
    }

    public async Task<List<ProductDto>> GetProductsByCategoryAsync(int categoryId)
    {
        var products = await _unitOfWork.Products.GetProductsByCategoryAsync(categoryId);
        return products.Select(p => p.ToDto()).ToList();
    }

    public async Task<ProductDto?> GetProductByIdAsync(int id)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(id);
        return product?.ToDto();
    }

    public async Task<ProductDto?> GetProductWithDetailsAsync(int id)
    {
        var product = await _unitOfWork.Products.GetProductWithVariantsAsync(id);
        return product?.ToDto();
    }

    public async Task<List<ProductDto>> SearchProductsAsync(string searchTerm)
    {
        var products = await _unitOfWork.Products.SearchProductsAsync(searchTerm);
        return products.Select(p => p.ToDto()).ToList();
    }

    public async Task<ProductDto> CreateProductAsync(ProductDto productDto)
    {
        var product = productDto.ToEntity();
        
        await _unitOfWork.Products.AddAsync(product);
        await _unitOfWork.SaveChangesAsync();
        
        return product.ToDto();
    }

    public async Task<ProductDto> UpdateProductAsync(ProductDto productDto)
    {
        var existingProduct = await _unitOfWork.Products.GetByIdAsync(productDto.Id);
        if (existingProduct == null)
            throw new Exception("Product not found");

        existingProduct.Name = productDto.Name;
        existingProduct.Description = productDto.Description;
        existingProduct.Price = productDto.Price;
        existingProduct.StockQuantity = productDto.StockQuantity;
        existingProduct.CategoryId = productDto.CategoryId;
        existingProduct.ImageUrl = productDto.ImageUrl;
        existingProduct.IsActive = productDto.IsActive;
        existingProduct.IsFeatured = productDto.IsFeatured;
        existingProduct.HasVariants = productDto.HasVariants;
        existingProduct.Brand = productDto.Brand;

        _unitOfWork.Products.Update(existingProduct);
        await _unitOfWork.SaveChangesAsync();
        
        return existingProduct.ToDto();
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(id);
        if (product == null)
            return false;

        _unitOfWork.Products.Delete(product);
        await _unitOfWork.SaveChangesAsync();
        
        return true;
    }

    public async Task<bool> UpdateStockAsync(int productId, int? variantId, int quantity)
    {
        if (variantId.HasValue)
        {
            var variant = await _unitOfWork.Repository<ProductVariant>().GetByIdAsync(variantId.Value);
            if (variant == null)
                return false;

            variant.StockQuantity -= quantity;
            _unitOfWork.Repository<ProductVariant>().Update(variant);
        }
        else
        {
            var product = await _unitOfWork.Products.GetByIdAsync(productId);
            if (product == null)
                return false;

            product.StockQuantity -= quantity;
            _unitOfWork.Products.Update(product);
        }

        await _unitOfWork.SaveChangesAsync();
        return true;
    }
}
