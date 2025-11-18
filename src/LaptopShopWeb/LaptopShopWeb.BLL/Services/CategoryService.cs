using LaptopShopWeb.BLL.DTOs;
using LaptopShopWeb.BLL.Mappers;
using LaptopShopWeb.DAL.UnitOfWork;

namespace LaptopShopWeb.BLL.Services;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<CategoryDto>> GetAllCategoriesAsync()
    {
        var categories = await _unitOfWork.Categories.GetAllAsync();
        return categories.Select(c => c.ToDto()).ToList();
    }

    public async Task<List<CategoryDto>> GetActiveCategoriesAsync()
    {
        var categories = await _unitOfWork.Categories.GetActiveCategoriesAsync();
        return categories.Select(c => c.ToDto()).ToList();
    }

    public async Task<CategoryDto?> GetCategoryByIdAsync(int id)
    {
        var category = await _unitOfWork.Categories.GetByIdAsync(id);
        return category?.ToDto();
    }

    public async Task<CategoryDto?> GetCategoryWithProductsAsync(int id)
    {
        var category = await _unitOfWork.Categories.GetCategoryWithProductsAsync(id);
        return category?.ToDto();
    }

    public async Task<CategoryDto?> GetCategoryBySlugAsync(string slug)
    {
        var category = await _unitOfWork.Categories.GetCategoryBySlugAsync(slug);
        return category?.ToDto();
    }

    public async Task<CategoryDto> CreateCategoryAsync(CategoryDto categoryDto)
    {
        var category = categoryDto.ToEntity();
        
        // Generate slug if not provided
        if (string.IsNullOrEmpty(category.Slug))
        {
            category.Slug = GenerateSlug(category.Name);
        }
        
        await _unitOfWork.Categories.AddAsync(category);
        await _unitOfWork.SaveChangesAsync();
        
        return category.ToDto();
    }

    public async Task<CategoryDto> UpdateCategoryAsync(CategoryDto categoryDto)
    {
        var existingCategory = await _unitOfWork.Categories.GetByIdAsync(categoryDto.Id);
        if (existingCategory == null)
            throw new Exception("Category not found");

        existingCategory.Name = categoryDto.Name;
        existingCategory.Description = categoryDto.Description;
        existingCategory.Slug = categoryDto.Slug ?? GenerateSlug(categoryDto.Name);
        existingCategory.IsActive = categoryDto.IsActive;

        _unitOfWork.Categories.Update(existingCategory);
        await _unitOfWork.SaveChangesAsync();
        
        return existingCategory.ToDto();
    }

    public async Task<bool> DeleteCategoryAsync(int id)
    {
        var category = await _unitOfWork.Categories.GetByIdAsync(id);
        if (category == null)
            return false;

        // Check if category has products
        var hasProducts = await _unitOfWork.Products.GetProductsByCategoryAsync(id);
        if (hasProducts.Any())
            throw new Exception("Cannot delete category with products");

        _unitOfWork.Categories.Delete(category);
        await _unitOfWork.SaveChangesAsync();
        
        return true;
    }

    private string GenerateSlug(string name)
    {
        return name.ToLower()
            .Replace(" ", "-")
            .Replace("á", "a").Replace("à", "a").Replace("ả", "a").Replace("ã", "a").Replace("ạ", "a")
            .Replace("ă", "a").Replace("ắ", "a").Replace("ằ", "a").Replace("ẳ", "a").Replace("ẵ", "a").Replace("ặ", "a")
            .Replace("â", "a").Replace("ấ", "a").Replace("ầ", "a").Replace("ẩ", "a").Replace("ẫ", "a").Replace("ậ", "a")
            .Replace("é", "e").Replace("è", "e").Replace("ẻ", "e").Replace("ẽ", "e").Replace("ẹ", "e")
            .Replace("ê", "e").Replace("ế", "e").Replace("ề", "e").Replace("ể", "e").Replace("ễ", "e").Replace("ệ", "e")
            .Replace("í", "i").Replace("ì", "i").Replace("ỉ", "i").Replace("ĩ", "i").Replace("ị", "i")
            .Replace("ó", "o").Replace("ò", "o").Replace("ỏ", "o").Replace("õ", "o").Replace("ọ", "o")
            .Replace("ô", "o").Replace("ố", "o").Replace("ồ", "o").Replace("ổ", "o").Replace("ỗ", "o").Replace("ộ", "o")
            .Replace("ơ", "o").Replace("ớ", "o").Replace("ờ", "o").Replace("ở", "o").Replace("ỡ", "o").Replace("ợ", "o")
            .Replace("ú", "u").Replace("ù", "u").Replace("ủ", "u").Replace("ũ", "u").Replace("ụ", "u")
            .Replace("ư", "u").Replace("ứ", "u").Replace("ừ", "u").Replace("ử", "u").Replace("ữ", "u").Replace("ự", "u")
            .Replace("ý", "y").Replace("ỳ", "y").Replace("ỷ", "y").Replace("ỹ", "y").Replace("ỵ", "y")
            .Replace("đ", "d");
    }
}
