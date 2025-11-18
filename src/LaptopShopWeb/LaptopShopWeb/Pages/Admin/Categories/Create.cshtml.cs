using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LaptopShopWeb.BLL.Services;
using LaptopShopWeb.BLL.DTOs;
using System.ComponentModel.DataAnnotations;

namespace LaptopShopWeb.Pages.Admin.Categories;

[Authorize(Roles = "Admin")]
public class CreateModel : PageModel
{
    private readonly ICategoryService _categoryService;

    public CreateModel(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [BindProperty]
    public CategoryInputModel Category { get; set; } = new();

    public class CategoryInputModel
    {
        [Required(ErrorMessage = "Tên danh mục là bắt buộc")]
        [StringLength(100, ErrorMessage = "Tên danh mục không được vượt quá 100 ký tự")]
        public string Name { get; set; } = string.Empty;

        [StringLength(200, ErrorMessage = "Slug không được vượt quá 200 ký tự")]
        public string? Slug { get; set; }

        [StringLength(500, ErrorMessage = "Mô tả không được vượt quá 500 ký tự")]
        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        try
        {
            // Generate slug if not provided
            if (string.IsNullOrWhiteSpace(Category.Slug))
            {
                Category.Slug = GenerateSlug(Category.Name);
            }

            var categoryDto = new CategoryDto
            {
                Name = Category.Name,
                Slug = Category.Slug,
                Description = Category.Description,
                IsActive = Category.IsActive
            };

            await _categoryService.CreateCategoryAsync(categoryDto);
            TempData["Success"] = "Thêm danh mục thành công!";
            return RedirectToPage("Index");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", $"Lỗi khi thêm danh mục: {ex.Message}");
            return Page();
        }
    }

    private string GenerateSlug(string name)
    {
        // Simple slug generation - remove diacritics and replace spaces
        var slug = name.ToLowerInvariant()
            .Replace(" ", "-")
            .Replace("á", "a").Replace("à", "a").Replace("ả", "a").Replace("ã", "a").Replace("ạ", "a")
            .Replace("ă", "a").Replace("ắ", "a").Replace("ằ", "a").Replace("ẳ", "a").Replace("ẵ", "a").Replace("ặ", "a")
            .Replace("â", "a").Replace("ấ", "a").Replace("ầ", "a").Replace("ẩ", "a").Replace("ẫ", "a").Replace("ậ", "a")
            .Replace("đ", "d")
            .Replace("é", "e").Replace("è", "e").Replace("ẻ", "e").Replace("ẽ", "e").Replace("ẹ", "e")
            .Replace("ê", "e").Replace("ế", "e").Replace("ề", "e").Replace("ể", "e").Replace("ễ", "e").Replace("ệ", "e")
            .Replace("í", "i").Replace("ì", "i").Replace("ỉ", "i").Replace("ĩ", "i").Replace("ị", "i")
            .Replace("ó", "o").Replace("ò", "o").Replace("ỏ", "o").Replace("õ", "o").Replace("ọ", "o")
            .Replace("ô", "o").Replace("ố", "o").Replace("ồ", "o").Replace("ổ", "o").Replace("ỗ", "o").Replace("ộ", "o")
            .Replace("ơ", "o").Replace("ớ", "o").Replace("ờ", "o").Replace("ở", "o").Replace("ỡ", "o").Replace("ợ", "o")
            .Replace("ú", "u").Replace("ù", "u").Replace("ủ", "u").Replace("ũ", "u").Replace("ụ", "u")
            .Replace("ư", "u").Replace("ứ", "u").Replace("ừ", "u").Replace("ử", "u").Replace("ữ", "u").Replace("ự", "u")
            .Replace("ý", "y").Replace("ỳ", "y").Replace("ỷ", "y").Replace("ỹ", "y").Replace("ỵ", "y");

        // Remove special characters
        slug = new string(slug.Where(c => char.IsLetterOrDigit(c) || c == '-').ToArray());

        return slug;
    }
}
