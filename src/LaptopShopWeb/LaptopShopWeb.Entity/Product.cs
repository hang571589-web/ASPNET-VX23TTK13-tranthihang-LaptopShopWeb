using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaptopShopWeb.Entity;

public class Product : BaseEntity
{
    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(2000)]
    public string? Description { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? DiscountPrice { get; set; }

    [MaxLength(100)]
    public string? Brand { get; set; }

    [MaxLength(100)]
    public string? CPU { get; set; }

    [MaxLength(50)]
    public string? RAM { get; set; }

    [MaxLength(100)]
    public string? Storage { get; set; }

    [MaxLength(100)]
    public string? Screen { get; set; }

    [MaxLength(50)]
    public string? GraphicsCard { get; set; }

    [MaxLength(50)]
    public string? OperatingSystem { get; set; }

    [Column(TypeName = "decimal(5,2)")]
    public decimal? Weight { get; set; }

    [MaxLength(50)]
    public string? Color { get; set; }

    public int StockQuantity { get; set; } = 0;

    [MaxLength(500)]
    public string? ImageUrl { get; set; }

    [MaxLength(200)]
    public string? Slug { get; set; }

    public bool IsActive { get; set; } = true;

    public bool IsFeatured { get; set; } = false;

    public int ViewCount { get; set; } = 0;

    // Foreign Keys
    public int CategoryId { get; set; }

    // Navigation Properties
    public virtual Category Category { get; set; } = null!;
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
