using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using LaptopShopWeb.BLL.Services;
using LaptopShopWeb.BLL.DTOs;
using LaptopShopWeb.Helpers;

namespace LaptopShopWeb.Pages.Cart;

[Authorize(Policy = "CustomerOnly")]
public class IndexModel : PageModel
{
    private readonly ICartService _cartService;

    public IndexModel(ICartService cartService)
    {
        _cartService = cartService;
    }

    public CartDto Cart { get; set; } = null!;
    
    [TempData]
    public string? SuccessMessage { get; set; }
    
    [TempData]
    public string? ErrorMessage { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        var userId = AuthHelper.GetUserId(User);
        if (!userId.HasValue)
        {
            return RedirectToPage("/Login");
        }

        Cart = await _cartService.GetCartWithDetailsAsync(userId.Value);
        return Page();
    }

    public async Task<IActionResult> OnPostUpdateQuantityAsync(int cartItemId, int quantity)
    {
        try
        {
            await _cartService.UpdateCartItemQuantityAsync(cartItemId, quantity);
            SuccessMessage = "Đã cập nhật số lượng!";
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }

        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostRemoveItemAsync(int cartItemId)
    {
        try
        {
            await _cartService.RemoveFromCartAsync(cartItemId);
            SuccessMessage = "Đã xóa sản phẩm khỏi giỏ hàng!";
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }

        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostClearCartAsync()
    {
        var userId = AuthHelper.GetUserId(User);
        if (!userId.HasValue)
        {
            return RedirectToPage("/Login");
        }

        try
        {
            await _cartService.ClearCartAsync(userId.Value);
            SuccessMessage = "Đã xóa toàn bộ giỏ hàng!";
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }

        return RedirectToPage();
    }
}
