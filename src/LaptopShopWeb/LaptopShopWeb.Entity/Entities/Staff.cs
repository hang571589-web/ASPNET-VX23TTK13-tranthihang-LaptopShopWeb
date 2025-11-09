namespace LaptopShopWeb.Entity.Entities;

public class Staff
{
    public int StaffId { get; set; }
    public int UserId { get; set; }
    public string Position { get; set; } = string.Empty;
    public string? Department { get; set; }
    public DateTime HireDate { get; set; } = DateTime.UtcNow;
    public decimal Salary { get; set; }

    // Navigation properties
    public User User { get; set; } = null!;
}
