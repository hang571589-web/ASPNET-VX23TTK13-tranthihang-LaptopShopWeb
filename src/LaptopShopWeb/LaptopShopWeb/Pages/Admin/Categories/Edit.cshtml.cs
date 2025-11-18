using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LaptopShopWeb.BLL.Services;
using LaptopShopWeb.BLL.DTOs;
using System.ComponentModel.DataAnnotations;

namespace LaptopShopWeb.Pages.Admin.Categories;

[Authorize(Roles = "Admin")]
public class EditModel : PageModel
{
    private readonly ICategoryService _categoryService;

    public EditModel(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [BindProperty]
    public CategoryInputModel Category { get; set; } = new();

    public int ProductCount { get; set; }

    public class CategoryInputModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên danh mục là bắt buộc")]
        [StringLength(100, ErrorMessage = "Tên danh mục không được vượt quá 100 ký tự")]
        public string Name { get; set; } = string.Empty;

        [StringLength(200, ErrorMessage = "Slug không được vượt quá 200 ký tự")]
        public string? Slug { get; set; }

        [StringLength(500, ErrorMessage = "Mô tả không được vượt quá 500 ký tự")]
        public string? Description { get; set; }

        public bool IsActive { get; set; }
    }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        try
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                TempData["Error"] = "Không tìm thấy danh mục.";
                return RedirectToPage("Index");
            }

            Category = new CategoryInputModel
            {
                Id = category.Id,
                Name = category.Name,
                Slug = category.Slug,
                Description = category.Description,
                IsActive = category.IsActive
            };

            ProductCount = category.ProductCount;

            return Page();
        }
        catch (Exception ex)
        {
            TempData["Error"] = $"Lỗi khi tải danh mục: {ex.Message}";
            return RedirectToPage("Index");
        }
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        try
        {
            var categoryDto = new CategoryDto
            {
                Id = Category.Id,
                Name = Category.Name,
                Slug = Category.Slug,
                Description = Category.Description,
                IsActive = Category.IsActive
            };

            await _categoryService.UpdateCategoryAsync(categoryDto);
            TempData["Success"] = "Cập nhật danh mục thành công!";
            return RedirectToPage("Index");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", $"Lỗi khi cập nhật danh mục: {ex.Message}");
            return Page();
        }
    }
}
