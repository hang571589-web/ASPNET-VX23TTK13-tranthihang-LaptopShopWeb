namespace LaptopShopWeb.Entity.Entities;

public class Product
{
    public int ProductId { get; set; }
    public int CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string Brand { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public decimal BasePrice { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    // Laptop specific properties
    public string? Screen { get; set; }
    public string? Os { get; set; }
    public string? GraphicsCard { get; set; }
    public string? Battery { get; set; }
    public decimal? Weight { get; set; }

    // Navigation properties
    public Category Category { get; set; } = null!;
    public ICollection<ProductVariant> Variants { get; set; } = new List<ProductVariant>();
}
