using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LaptopShopWeb.BLL.Services;
using LaptopShopWeb.BLL.DTOs;
using System.ComponentModel.DataAnnotations;

namespace LaptopShopWeb.Pages.Admin.Products;

[Authorize(Roles = "Admin")]
public class EditModel : PageModel
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;

    public EditModel(IProductService productService, ICategoryService categoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
    }

    [BindProperty]
    public ProductInputModel Product { get; set; } = new();

    public List<CategoryDto> Categories { get; set; } = new();

    public class ProductInputModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm là bắt buộc")]
        [StringLength(200, ErrorMessage = "Tên sản phẩm không được vượt quá 200 ký tự")]
        public string Name { get; set; } = string.Empty;

        [StringLength(2000, ErrorMessage = "Mô tả không được vượt quá 2000 ký tự")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Giá là bắt buộc")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá phải lớn hơn hoặc bằng 0")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Số lượng tồn kho là bắt buộc")]
        [Range(0, int.MaxValue, ErrorMessage = "Số lượng phải lớn hơn hoặc bằng 0")]
        public int StockQuantity { get; set; }

        [Required(ErrorMessage = "Danh mục là bắt buộc")]
        public int CategoryId { get; set; }

        [StringLength(500, ErrorMessage = "URL hình ảnh không được vượt quá 500 ký tự")]
        public string? ImageUrl { get; set; }

        [StringLength(100, ErrorMessage = "Thương hiệu không được vượt quá 100 ký tự")]
        public string? Brand { get; set; }

        public bool IsActive { get; set; }
        public bool IsFeatured { get; set; }
    }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        try
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                TempData["Error"] = "Không tìm thấy sản phẩm.";
                return RedirectToPage("Index");
            }

            Product = new ProductInputModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                CategoryId = product.CategoryId,
                ImageUrl = product.ImageUrl,
                Brand = product.Brand,
                IsActive = product.IsActive,
                IsFeatured = product.IsFeatured
            };

            Categories = await _categoryService.GetActiveCategoriesAsync();
            return Page();
        }
        catch (Exception ex)
        {
            TempData["Error"] = $"Lỗi khi tải sản phẩm: {ex.Message}";
            return RedirectToPage("Index");
        }
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            Categories = await _categoryService.GetActiveCategoriesAsync();
            return Page();
        }

        try
        {
            var productDto = new ProductDto
            {
                Id = Product.Id,
                Name = Product.Name,
                Description = Product.Description,
                Price = Product.Price,
                StockQuantity = Product.StockQuantity,
                CategoryId = Product.CategoryId,
                ImageUrl = Product.ImageUrl,
                Brand = Product.Brand,
                IsActive = Product.IsActive,
                IsFeatured = Product.IsFeatured
            };

            await _productService.UpdateProductAsync(productDto);
            TempData["Success"] = "Cập nhật sản phẩm thành công!";
            return RedirectToPage("Index");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", $"Lỗi khi cập nhật sản phẩm: {ex.Message}");
            Categories = await _categoryService.GetActiveCategoriesAsync();
            return Page();
        }
    }
}
