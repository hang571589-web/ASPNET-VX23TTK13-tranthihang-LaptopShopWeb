using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using LaptopShopWeb.BLL.Services;
using LaptopShopWeb.BLL.DTOs;
using LaptopShopWeb.Helpers;

namespace LaptopShopWeb.Pages.Products;

public class DetailsModel : PageModel
{
    private readonly IProductService _productService;
    private readonly ICartService _cartService;

    public DetailsModel(IProductService productService, ICartService cartService)
    {
        _productService = productService;
        _cartService = cartService;
    }

    public ProductDto Product { get; set; } = null!;
    
    [BindProperty]
    public int? SelectedVariantId { get; set; }
    
    [BindProperty]
    public int Quantity { get; set; } = 1;
    
    [TempData]
    public string? SuccessMessage { get; set; }
    
    [TempData]
    public string? ErrorMessage { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var product = await _productService.GetProductWithDetailsAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        Product = product;
        return Page();
    }

    public async Task<IActionResult> OnPostAddToCartAsync(int id)
    {
        if (!AuthHelper.IsAuthenticated(User))
        {
            return RedirectToPage("/Login", new { returnUrl = $"/Products/Details?id={id}" });
        }

        var userId = AuthHelper.GetUserId(User);
        if (!userId.HasValue)
        {
            return RedirectToPage("/Login");
        }

        try
        {
            await _cartService.AddToCartAsync(userId.Value, id, SelectedVariantId, Quantity);
            SuccessMessage = "Đã thêm sản phẩm vào giỏ hàng!";
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }

        return RedirectToPage(new { id });
    }
}
