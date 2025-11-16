using System.ComponentModel.DataAnnotations;

namespace LaptopShopWeb.Entity;

public class Review : BaseEntity
{
    [Required]
    [Range(1, 5)]
    public int Rating { get; set; }

    [MaxLength(100)]
    public string? Title { get; set; }

    [MaxLength(2000)]
    public string? Comment { get; set; }

    public bool IsApproved { get; set; } = false;

    public int HelpfulCount { get; set; } = 0;

    // Foreign Keys
    public int ProductId { get; set; }
    public int UserId { get; set; }

    // Navigation Properties
    public virtual Product Product { get; set; } = null!;
    public virtual User User { get; set; } = null!;
}
