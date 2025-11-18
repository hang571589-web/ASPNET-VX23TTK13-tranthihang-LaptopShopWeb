using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LaptopShopWeb.BLL.Services;
using LaptopShopWeb.BLL.DTOs;

namespace LaptopShopWeb.Pages.Admin.Orders;

[Authorize(Roles = "Admin")]
public class DetailsModel : PageModel
{
    private readonly IOrderService _orderService;

    public DetailsModel(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public OrderDto? Order { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        try
        {
            Order = await _orderService.GetOrderWithDetailsAsync(id);
            if (Order == null)
            {
                TempData["Error"] = "Không tìm thấy đơn hàng.";
                return RedirectToPage("Index");
            }

            return Page();
        }
        catch (Exception ex)
        {
            TempData["Error"] = $"Lỗi khi tải chi tiết đơn hàng: {ex.Message}";
            return RedirectToPage("Index");
        }
    }
}
