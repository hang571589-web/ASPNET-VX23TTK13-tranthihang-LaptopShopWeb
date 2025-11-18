using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LaptopShopWeb.BLL.Services;
using LaptopShopWeb.BLL.DTOs;

namespace LaptopShopWeb.Pages.Admin.Orders;

[Authorize(Roles = "Admin")]
public class IndexModel : PageModel
{
    private readonly IOrderService _orderService;

    public IndexModel(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public List<OrderDto> Orders { get; set; } = new();

    [BindProperty(SupportsGet = true)]
    public string? SearchTerm { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? StatusFilter { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        try
        {
            if (!string.IsNullOrWhiteSpace(StatusFilter))
            {
                Orders = await _orderService.GetOrdersByStatusAsync(StatusFilter);
            }
            else
            {
                Orders = await _orderService.GetRecentOrdersAsync(100);
            }

            if (!string.IsNullOrWhiteSpace(SearchTerm))
            {
                Orders = Orders.Where(o => o.OrderNumber.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            Orders = Orders.OrderByDescending(o => o.OrderDate).ToList();

            return Page();
        }
        catch (Exception ex)
        {
            TempData["Error"] = $"Lỗi khi tải danh sách đơn hàng: {ex.Message}";
            return Page();
        }
    }

    public async Task<IActionResult> OnPostUpdateStatusAsync(int id, string newStatus)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(newStatus))
            {
                TempData["Error"] = "Vui lòng chọn trạng thái mới.";
                return RedirectToPage();
            }

            await _orderService.UpdateOrderStatusAsync(id, newStatus);
            TempData["Success"] = "Cập nhật trạng thái đơn hàng thành công!";
        }
        catch (Exception ex)
        {
            TempData["Error"] = $"Lỗi khi cập nhật trạng thái: {ex.Message}";
        }

        return RedirectToPage();
    }
}
