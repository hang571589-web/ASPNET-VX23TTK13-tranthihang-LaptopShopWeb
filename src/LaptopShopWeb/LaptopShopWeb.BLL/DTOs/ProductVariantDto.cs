namespace LaptopShopWeb.BLL.DTOs;

public class ProductVariantDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string? CPU { get; set; }
    public string? RAM { get; set; }
    public string? Storage { get; set; }
    public string? GraphicsCard { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public string? SKU { get; set; }
    public bool IsActive { get; set; }
    
    public string DisplayName => $"{CPU} / {RAM} / {Storage}" + 
                                 (string.IsNullOrEmpty(GraphicsCard) ? "" : $" / {GraphicsCard}");
}
