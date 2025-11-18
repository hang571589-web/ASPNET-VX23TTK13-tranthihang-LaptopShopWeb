using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using LaptopShopWeb.BLL.Services;
using LaptopShopWeb.BLL.DTOs;
using LaptopShopWeb.Helpers;

namespace LaptopShopWeb.Pages.Checkout;

[Authorize(Policy = "CustomerOnly")]
public class IndexModel : PageModel
{
    private readonly ICartService _cartService;
    private readonly IOrderService _orderService;
    private readonly IUserService _userService;

    public IndexModel(ICartService cartService, IOrderService orderService, IUserService userService)
    {
        _cartService = cartService;
        _orderService = orderService;
        _userService = userService;
    }

    public CartDto Cart { get; set; } = null!;
    public UserDto CurrentUser { get; set; } = null!;

    [BindProperty]
    public CheckoutInputModel Input { get; set; } = new();

    [TempData]
    public string? ErrorMessage { get; set; }

    public class CheckoutInputModel
    {
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ giao hàng")]
        [StringLength(500)]
        public string ShippingAddress { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng nhập thành phố")]
        [StringLength(100)]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        public string PhoneNumber { get; set; } = string.Empty;

        public string? Notes { get; set; }
    }

    public async Task<IActionResult> OnGetAsync()
    {
        var userId = AuthHelper.GetUserId(User);
        if (!userId.HasValue)
        {
            return RedirectToPage("/Login");
        }

        Cart = await _cartService.GetCartWithDetailsAsync(userId.Value);
        
        if (!Cart.Items.Any())
        {
            return RedirectToPage("/Cart/Index");
        }

        var user = await _userService.GetByIdAsync(userId.Value);
        if (user == null)
        {
            return RedirectToPage("/Login");
        }
        
        CurrentUser = user;
        
        // Pre-fill form with user data
        Input.ShippingAddress = user.Address ?? "";
        Input.PhoneNumber = user.PhoneNumber ?? "";

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var userId = AuthHelper.GetUserId(User);
        if (!userId.HasValue)
        {
            return RedirectToPage("/Login");
        }

        if (!ModelState.IsValid)
        {
            Cart = await _cartService.GetCartWithDetailsAsync(userId.Value);
            var user = await _userService.GetByIdAsync(userId.Value);
            if (user != null) CurrentUser = user;
            return Page();
        }

        try
        {
            var createOrderDto = new CreateOrderDto
            {
                UserId = userId.Value,
                ShippingAddress = Input.ShippingAddress,
                City = Input.City,
                PhoneNumber = Input.PhoneNumber,
                Notes = Input.Notes
            };

            var orderId = await _orderService.CreateOrderAsync(createOrderDto);
            await _cartService.ClearCartAsync(userId.Value);

            return RedirectToPage("/Orders/Success", new { orderId });
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
            Cart = await _cartService.GetCartWithDetailsAsync(userId.Value);
            var user = await _userService.GetByIdAsync(userId.Value);
            if (user != null) CurrentUser = user;
            return Page();
        }
    }
}
