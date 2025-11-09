namespace LaptopShopWeb.Entity.Entities;

public class ProductVariant
{
    public int VariantId { get; set; }
    public int ProductId { get; set; }
    public string Ram { get; set; } = string.Empty; // e.g., "16GB", "32GB"
    public string Processor { get; set; } = string.Empty; // e.g., "Intel Core i5", "Intel Core i7"
    public string? Storage { get; set; } // e.g., "512GB SSD", "1TB SSD"
    public string Sku { get; set; } = string.Empty; // Stock Keeping Unit
    public decimal PriceAdjustment { get; set; } = 0; // Price difference from base price
    public int StockQuantity { get; set; } = 0;
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    // Navigation properties
    public Product Product { get; set; } = null!;
    public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
