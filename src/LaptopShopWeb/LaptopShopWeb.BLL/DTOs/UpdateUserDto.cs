namespace LaptopShopWeb.BLL.DTOs;

public class UpdateUserDto
{
    public string FullName { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
}
