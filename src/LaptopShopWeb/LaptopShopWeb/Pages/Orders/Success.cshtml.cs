using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LaptopShopWeb.Pages.Orders;

public class SuccessModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public int OrderId { get; set; }

    public void OnGet()
    {
    }
}
