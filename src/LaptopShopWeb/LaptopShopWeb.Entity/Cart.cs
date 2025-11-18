using System.ComponentModel.DataAnnotations;

namespace LaptopShopWeb.Entity;

public class Cart : BaseEntity
{
    [Required]
    public int UserId { get; set; }

    // Navigation Properties
    public virtual User User { get; set; } = null!;
    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
}
