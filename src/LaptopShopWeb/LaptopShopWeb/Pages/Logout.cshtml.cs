using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LaptopShopWeb.Helpers;

namespace LaptopShopWeb.Pages;

public class LogoutModel : PageModel
{
    public async Task<IActionResult> OnGet()
    {
        await AuthHelper.SignOutAsync(HttpContext);
        return RedirectToPage("/Index");
    }
}
