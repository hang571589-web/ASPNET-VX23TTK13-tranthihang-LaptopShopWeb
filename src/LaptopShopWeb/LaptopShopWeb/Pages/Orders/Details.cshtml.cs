using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using LaptopShopWeb.BLL.Services;
using LaptopShopWeb.BLL.DTOs;
using LaptopShopWeb.Helpers;

namespace LaptopShopWeb.Pages.Orders;

[Authorize(Policy = "CustomerOnly")]
public class DetailsModel : PageModel
{
    private readonly IOrderService _orderService;

    public DetailsModel(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public OrderDto Order { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var userId = AuthHelper.GetUserId(User);
        if (!userId.HasValue)
        {
            return RedirectToPage("/Login");
        }

        var order = await _orderService.GetOrderWithDetailsAsync(id);
        
        if (order == null)
        {
            return NotFound();
        }

        // Verify order belongs to current user
        if (order.UserId != userId.Value)
        {
            return Forbid();
        }

        Order = order;
        return Page();
    }
}
