using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using LaptopShopWeb.BLL.Services;
using LaptopShopWeb.BLL.DTOs;
using LaptopShopWeb.Helpers;

namespace LaptopShopWeb.Pages.Orders;

[Authorize(Policy = "CustomerOnly")]
public class IndexModel : PageModel
{
    private readonly IOrderService _orderService;

    public IndexModel(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public IEnumerable<OrderDto> Orders { get; set; } = new List<OrderDto>();

    public async Task<IActionResult> OnGetAsync()
    {
        var userId = AuthHelper.GetUserId(User);
        if (!userId.HasValue)
        {
            return RedirectToPage("/Login");
        }

        Orders = await _orderService.GetOrdersByUserIdAsync(userId.Value);
        return Page();
    }
}
