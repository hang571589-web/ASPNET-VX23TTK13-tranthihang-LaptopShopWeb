using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LaptopShopWeb.BLL.Services;
using LaptopShopWeb.BLL.DTOs;

namespace LaptopShopWeb.Pages.Admin.Users;

[Authorize(Roles = "Admin")]
public class IndexModel : PageModel
{
    private readonly IUserService _userService;

    public IndexModel(IUserService userService)
    {
        _userService = userService;
    }

    public List<UserDto> Users { get; set; } = new();

    public async Task<IActionResult> OnGetAsync()
    {
        try
        {
            var customers = await _userService.GetUsersByRoleAsync("Customer");
            var managers = await _userService.GetUsersByRoleAsync("Manager");
            var admins = await _userService.GetUsersByRoleAsync("Admin");
            
            Users = customers.Concat(managers).Concat(admins)
                .OrderByDescending(u => u.CreatedAt)
                .ToList();

            return Page();
        }
        catch (Exception ex)
        {
            TempData["Error"] = $"Lỗi khi tải danh sách người dùng: {ex.Message}";
            return Page();
        }
    }

    public async Task<IActionResult> OnPostToggleStatusAsync(int id)
    {
        try
        {
            var result = await _userService.ToggleUserStatusAsync(id);
            if (result)
            {
                TempData["Success"] = "Cập nhật trạng thái người dùng thành công!";
            }
            else
            {
                TempData["Error"] = "Không thể cập nhật trạng thái người dùng.";
            }
        }
        catch (Exception ex)
        {
            TempData["Error"] = $"Lỗi: {ex.Message}";
        }

        return RedirectToPage();
    }
}
