namespace LaptopShopWeb.BLL.DTOs;

public class UserDto
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty; // For internal use only
    public string FullName { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public string Role { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public string RoleDisplay => Role switch
    {
        "Customer" => "Khách hàng",
        "Manager" => "Quản lý",
        _ => Role
    };
}
