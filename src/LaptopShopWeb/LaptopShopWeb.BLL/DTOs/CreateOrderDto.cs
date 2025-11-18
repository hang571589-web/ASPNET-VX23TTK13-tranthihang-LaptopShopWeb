namespace LaptopShopWeb.BLL.DTOs;

public class CreateOrderDto
{
    public int UserId { get; set; }
    public string ShippingAddress { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string? Notes { get; set; }
    public string PaymentMethod { get; set; } = "COD";
}
