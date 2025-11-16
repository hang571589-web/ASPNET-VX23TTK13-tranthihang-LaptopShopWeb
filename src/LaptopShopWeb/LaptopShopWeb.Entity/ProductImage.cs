using System.ComponentModel.DataAnnotations;

namespace LaptopShopWeb.Entity;

public class ProductImage : BaseEntity
{
    [Required]
    [MaxLength(500)]
    public string ImageUrl { get; set; } = string.Empty;

    [MaxLength(200)]
    public string? AltText { get; set; }

    public bool IsPrimary { get; set; } = false;

    public int DisplayOrder { get; set; } = 0;

    // Foreign Keys
    public int ProductId { get; set; }

    // Navigation Properties
    public virtual Product Product { get; set; } = null!;
}
