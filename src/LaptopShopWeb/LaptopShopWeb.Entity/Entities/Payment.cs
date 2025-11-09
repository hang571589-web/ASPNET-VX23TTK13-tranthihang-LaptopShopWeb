namespace LaptopShopWeb.Entity.Entities;

public class Payment
{
    public int PaymentId { get; set; }
    public int OrderId { get; set; }
    public string PaymentMethod { get; set; } = string.Empty; // CreditCard, PayPal, BankTransfer, Cash
    public decimal Amount { get; set; }
    public string PaymentStatus { get; set; } = "Pending"; // Pending, Completed, Failed, Refunded
    public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
    public string? TransactionId { get; set; }
    public string? Notes { get; set; }

    // Navigation properties
    public Order Order { get; set; } = null!;
}
