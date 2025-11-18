using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LaptopShopWeb.BLL.Services;
using LaptopShopWeb.BLL.DTOs;

namespace LaptopShopWeb.Pages.Products;

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
    public int? CategoryId { get; set; }
    
    [BindProperty(SupportsGet = true)]
    public string? SearchTerm { get; set; }

    public async Task OnGetAsync()
    {
        Categories = await _categoryService.GetActiveCategoriesAsync();

        if (!string.IsNullOrEmpty(SearchTerm))
        {
            Products = await _productService.SearchProductsAsync(SearchTerm);
        }
        else if (CategoryId.HasValue)
        {
            Products = await _productService.GetProductsByCategoryAsync(CategoryId.Value);
        }
        else
        {
            Products = await _productService.GetActiveProductsAsync();
        }
    }
}
