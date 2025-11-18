using Microsoft.AspNetCore.Mvc.RazorPages;
using LaptopShopWeb.BLL.Services;
using LaptopShopWeb.BLL.DTOs;

namespace LaptopShopWeb.Pages;

public class IndexModel : PageModel
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;

    public IndexModel(IProductService productService, ICategoryService categoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
    }

    public List<ProductDto> FeaturedProducts { get; set; } = new();
    public List<CategoryDto> Categories { get; set; } = new();

    public async Task OnGetAsync()
    {
        FeaturedProducts = await _productService.GetFeaturedProductsAsync();
        Categories = await _categoryService.GetActiveCategoriesAsync();
    }
}
