using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LaptopShopWeb.BLL.Services;
using LaptopShopWeb.BLL.DTOs;

namespace LaptopShopWeb.Pages.Admin.Products;

[Authorize(Roles = "Admin")]
public class IndexModel : PageModel
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;

    public IndexModel(IProductService productService, ICategoryService categoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
    }

    public List<ProductDto> Products { get; set; } = new();
    public List<CategoryDto> Categories { get; set; } = new();

    [BindProperty(SupportsGet = true)]
    public string? SearchTerm { get; set; }

    [BindProperty(SupportsGet = true)]
    public int? CategoryId { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? Status { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        try
        {
            Categories = await _categoryService.GetAllCategoriesAsync();
            
            // Get products based on filters
            if (!string.IsNullOrWhiteSpace(SearchTerm))
            {
                Products = await _productService.SearchProductsAsync(SearchTerm);
            }
            else if (CategoryId.HasValue)
            {
                Products = await _productService.GetProductsByCategoryAsync(CategoryId.Value);
            }
            else
            {
                Products = await _productService.GetAllProductsAsync();
            }

            // Apply status filter
            if (!string.IsNullOrWhiteSpace(Status))
            {
                Products = Status.ToLower() switch
                {
                    "active" => Products.Where(p => p.IsActive).ToList(),
                    "inactive" => Products.Where(p => !p.IsActive).ToList(),
                    _ => Products
                };
            }

            return Page();
        }
        catch (Exception ex)
        {
            TempData["Error"] = $"Lỗi khi tải danh sách sản phẩm: {ex.Message}";
            return Page();
        }
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        try
        {
            var result = await _productService.DeleteProductAsync(id);
            if (result)
            {
                TempData["Success"] = "Xóa sản phẩm thành công!";
            }
            else
            {
                TempData["Error"] = "Không thể xóa sản phẩm. Vui lòng thử lại.";
            }
        }
        catch (Exception ex)
        {
            TempData["Error"] = $"Lỗi khi xóa sản phẩm: {ex.Message}";
        }

        return RedirectToPage();
    }
}
