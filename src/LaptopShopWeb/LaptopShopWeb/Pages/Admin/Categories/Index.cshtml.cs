using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LaptopShopWeb.BLL.Services;
using LaptopShopWeb.BLL.DTOs;

namespace LaptopShopWeb.Pages.Admin.Categories;

[Authorize(Roles = "Admin")]
public class IndexModel : PageModel
{
    private readonly ICategoryService _categoryService;

    public IndexModel(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public List<CategoryDto> Categories { get; set; } = new();

    public async Task<IActionResult> OnGetAsync()
    {
        try
        {
            Categories = await _categoryService.GetAllCategoriesAsync();
            return Page();
        }
        catch (Exception ex)
        {
            TempData["Error"] = $"Lỗi khi tải danh sách danh mục: {ex.Message}";
            return Page();
        }
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        try
        {
            var result = await _categoryService.DeleteCategoryAsync(id);
            if (result)
            {
                TempData["Success"] = "Xóa danh mục thành công!";
            }
            else
            {
                TempData["Error"] = "Không thể xóa danh mục. Vui lòng thử lại.";
            }
        }
        catch (Exception ex)
        {
            TempData["Error"] = $"Lỗi khi xóa danh mục: {ex.Message}";
        }

        return RedirectToPage();
    }
}
