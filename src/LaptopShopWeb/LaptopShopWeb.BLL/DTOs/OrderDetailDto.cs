namespace LaptopShopWeb.BLL.DTOs;

public class OrderDetailDto
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string? ProductImageUrl { get; set; }
    public int? ProductVariantId { get; set; }
    public string? VariantDescription { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    
    // Alias properties
    public string? VariantDisplayName => VariantDescription;
    public decimal TotalPrice => Quantity * UnitPrice;
    public decimal Subtotal => TotalPrice;
}
