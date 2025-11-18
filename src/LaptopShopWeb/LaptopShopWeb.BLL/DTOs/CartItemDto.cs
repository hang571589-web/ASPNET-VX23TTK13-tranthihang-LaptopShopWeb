namespace LaptopShopWeb.BLL.DTOs;

public class CartItemDto
{
    public int Id { get; set; }
    public int CartId { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string? ProductImageUrl { get; set; }
    public int? ProductVariantId { get; set; }
    public string? VariantName { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    
    // Alias properties
    public string? VariantDisplayName => VariantName;
    public decimal UnitPrice => Price;
    public decimal TotalPrice => Quantity * Price;
    public decimal Subtotal => TotalPrice;
}
