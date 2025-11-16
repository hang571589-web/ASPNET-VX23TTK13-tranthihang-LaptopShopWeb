using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaptopShopWeb.Entity;

public class Order : BaseEntity
{
    [Required]
    [MaxLength(50)]
    public string OrderNumber { get; set; } = string.Empty;

    public DateTime OrderDate { get; set; } = DateTime.UtcNow;

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalAmount { get; set; }

    [Required]
    [MaxLength(50)]
    public string Status { get; set; } = "Pending"; // Pending, Processing, Shipped, Delivered, Cancelled

    [Required]
    [MaxLength(500)]
    public string ShippingAddress { get; set; } = string.Empty;

    [MaxLength(100)]
    public string? ShippingCity { get; set; }

    [MaxLength(20)]
    public string? ShippingPostalCode { get; set; }

    [MaxLength(20)]
    public string? ShippingPhone { get; set; }

    [Required]
    [MaxLength(50)]
    public string PaymentMethod { get; set; } = "COD"; // COD, CreditCard, BankTransfer

    [MaxLength(50)]
    public string? PaymentStatus { get; set; } = "Unpaid"; // Paid, Unpaid

    [MaxLength(1000)]
    public string? Notes { get; set; }

    public DateTime? ShippedDate { get; set; }
    public DateTime? DeliveredDate { get; set; }

    // Foreign Keys
    public int UserId { get; set; }

    // Navigation Properties
    public virtual User User { get; set; } = null!;
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
