using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LaptopShopWeb.BLL.Services;
using LaptopShopWeb.BLL.DTOs;

namespace LaptopShopWeb.Pages.Admin;

[Authorize(Roles = "Admin")]
public class IndexModel : PageModel
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;
    private readonly IUserService _userService;
    private readonly IOrderService _orderService;

    public IndexModel(
        IProductService productService,
        ICategoryService categoryService,
        IUserService userService,
        IOrderService orderService)
    {
        _productService = productService;
        _categoryService = categoryService;
        _userService = userService;
        _orderService = orderService;
    }

    public int TotalProducts { get; set; }
    public int TotalCategories { get; set; }
    public int TotalUsers { get; set; }
    public int TotalOrders { get; set; }
    public decimal TotalRevenue { get; set; }
    public List<OrderDto> RecentOrders { get; set; } = new();

    public async Task<IActionResult> OnGetAsync()
    {
        try
        {
            var products = await _productService.GetAllProductsAsync();
            var categories = await _categoryService.GetAllCategoriesAsync();
            var customers = await _userService.GetUsersByRoleAsync("Customer");
            var allOrders = await _orderService.GetRecentOrdersAsync(100);

            TotalProducts = products.Count;
            TotalCategories = categories.Count;
            TotalUsers = customers.Count;
            TotalOrders = allOrders.Count;
            TotalRevenue = allOrders
                .Where(o => o.Status == "Delivered")
                .Sum(o => o.TotalAmount);

            RecentOrders = await _orderService.GetRecentOrdersAsync(10);

            return Page();
        }
        catch (Exception ex)
        {
            TempData["Error"] = $"Lỗi khi tải dữ liệu: {ex.Message}";
            return Page();
        }
    }
}
