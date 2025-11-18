using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LaptopShopWeb.BLL.Services;
using LaptopShopWeb.BLL.DTOs;
using System.ComponentModel.DataAnnotations;

namespace LaptopShopWeb.Pages.Admin.Users;

[Authorize(Roles = "Admin")]
public class EditModel : PageModel
{
    private readonly IUserService _userService;

    public EditModel(IUserService userService)
    {
        _userService = userService;
    }

    [BindProperty]
    public new UserInputModel User { get; set; } = new();

    public DateTime CreatedAt { get; set; }

    public class UserInputModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Email là bắt buộc")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Họ tên là bắt buộc")]
        [StringLength(100, ErrorMessage = "Họ tên không được vượt quá 100 ký tự")]
        public string FullName { get; set; } = string.Empty;

        [StringLength(20, ErrorMessage = "Số điện thoại không được vượt quá 20 ký tự")]
        public string? PhoneNumber { get; set; }

        [StringLength(200, ErrorMessage = "Địa chỉ không được vượt quá 200 ký tự")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Vai trò là bắt buộc")]
        public string Role { get; set; } = "Customer";

        public bool IsActive { get; set; }
    }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        try
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                TempData["Error"] = "Không tìm thấy người dùng.";
                return RedirectToPage("Index");
            }

            User = new UserInputModel
            {
                Id = user.Id,
                Email = user.Email,
                FullName = user.FullName,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                Role = user.Role,
                IsActive = user.IsActive
            };

            CreatedAt = user.CreatedAt;

            return Page();
        }
        catch (Exception ex)
        {
            TempData["Error"] = $"Lỗi khi tải thông tin người dùng: {ex.Message}";
            return RedirectToPage("Index");
        }
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        try
        {
            var updateDto = new UpdateUserDto
            {
                FullName = User.FullName,
                PhoneNumber = User.PhoneNumber,
                Address = User.Address
            };

            await _userService.UpdateAsync(User.Id, updateDto);

            // Update role if changed
            await _userService.UpdateUserRoleAsync(User.Id, User.Role);

            // Update status
            var currentUser = await _userService.GetUserByIdAsync(User.Id);
            if (currentUser != null && currentUser.IsActive != User.IsActive)
            {
                await _userService.ToggleUserStatusAsync(User.Id);
            }

            TempData["Success"] = "Cập nhật thông tin người dùng thành công!";
            return RedirectToPage("Index");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", $"Lỗi khi cập nhật người dùng: {ex.Message}");
            return Page();
        }
    }
}
