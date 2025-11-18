using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaptopShopWeb.Entity;

public class ProductVariant : BaseEntity
{
    [MaxLength(100)]
    public string? CPU { get; set; }

    [MaxLength(50)]
    public string? RAM { get; set; }

    [MaxLength(100)]
    public string? Storage { get; set; }

    [MaxLength(50)]
    public string? GraphicsCard { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? DiscountPrice { get; set; }

    public int StockQuantity { get; set; } = 0;

    [MaxLength(100)]
    public string? SKU { get; set; }

    public bool IsActive { get; set; } = true;

    // Foreign Keys
    public int ProductId { get; set; }

    // Navigation Properties
    public virtual Product Product { get; set; } = null!;
    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
