using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using LaptopShopWeb.BLL.Services;
using LaptopShopWeb.BLL.DTOs;
using LaptopShopWeb.Helpers;
using BCrypt.Net;

namespace LaptopShopWeb.Pages;

[Authorize(Policy = "CustomerOnly")]
public class ProfileModel : PageModel
{
    private readonly IUserService _userService;

    public ProfileModel(IUserService userService)
    {
        _userService = userService;
    }

    public UserDto CurrentUser { get; set; } = null!;

    [BindProperty]
    public ProfileInputModel Input { get; set; } = new();

    [BindProperty]
    public PasswordInputModel PasswordInput { get; set; } = new();

    [TempData]
    public string? SuccessMessage { get; set; }

    [TempData]
    public string? ErrorMessage { get; set; }

    public class ProfileInputModel
    {
        [Required(ErrorMessage = "Vui lòng nhập họ tên")]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        public string? PhoneNumber { get; set; }

        [StringLength(500)]
        public string? Address { get; set; }
    }

    public class PasswordInputModel
    {
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu hiện tại")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu mới")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng xác nhận mật khẩu")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Mật khẩu xác nhận không khớp")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }

    public async Task<IActionResult> OnGetAsync()
    {
        var userId = AuthHelper.GetUserId(User);
        if (!userId.HasValue)
        {
            return RedirectToPage("/Login");
        }

        var user = await _userService.GetByIdAsync(userId.Value);
        if (user == null)
        {
            return RedirectToPage("/Login");
        }

        CurrentUser = user;
        
        // Pre-fill form
        Input.FullName = user.FullName;
        Input.PhoneNumber = user.PhoneNumber;
        Input.Address = user.Address;

        return Page();
    }

    public async Task<IActionResult> OnPostUpdateProfileAsync()
    {
        var userId = AuthHelper.GetUserId(User);
        if (!userId.HasValue)
        {
            return RedirectToPage("/Login");
        }

        if (!ModelState.IsValid)
        {
            var user = await _userService.GetByIdAsync(userId.Value);
            if (user != null) CurrentUser = user;
            return Page();
        }

        try
        {
            var updateDto = new UpdateUserDto
            {
                FullName = Input.FullName,
                PhoneNumber = Input.PhoneNumber,
                Address = Input.Address
            };

            await _userService.UpdateAsync(userId.Value, updateDto);
            SuccessMessage = "Cập nhật thông tin thành công!";
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }

        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostChangePasswordAsync()
    {
        var userId = AuthHelper.GetUserId(User);
        if (!userId.HasValue)
        {
            return RedirectToPage("/Login");
        }

        if (!ModelState.IsValid)
        {
            var user = await _userService.GetByIdAsync(userId.Value);
            if (user != null) CurrentUser = user;
            return Page();
        }

        try
        {
            var user = await _userService.GetByIdAsync(userId.Value);
            if (user == null)
            {
                return RedirectToPage("/Login");
            }

            // Verify current password
            if (!BCrypt.Net.BCrypt.Verify(PasswordInput.CurrentPassword, user.PasswordHash))
            {
                ErrorMessage = "Mật khẩu hiện tại không đúng!";
                CurrentUser = user;
                Input.FullName = user.FullName;
                Input.PhoneNumber = user.PhoneNumber;
                Input.Address = user.Address;
                return Page();
            }

            // Update password
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(PasswordInput.NewPassword);
            await _userService.ChangePasswordAsync(userId.Value, hashedPassword);
            
            SuccessMessage = "Đổi mật khẩu thành công!";
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }

        return RedirectToPage();
    }
}
