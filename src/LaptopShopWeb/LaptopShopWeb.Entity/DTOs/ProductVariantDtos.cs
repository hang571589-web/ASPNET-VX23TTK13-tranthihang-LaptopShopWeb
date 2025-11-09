namespace LaptopShopWeb.Entity.DTOs;

public class ProductVariantDto
{
    public int VariantId { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string Ram { get; set; } = string.Empty;
    public string Processor { get; set; } = string.Empty;
    public string? Storage { get; set; }
    public string Sku { get; set; } = string.Empty;
    public decimal FinalPrice { get; set; }
    public decimal PriceAdjustment { get; set; }
    public int StockQuantity { get; set; }
    public bool IsActive { get; set; }
}

public class CreateProductVariantDto
{
    public int ProductId { get; set; }
    public string Ram { get; set; } = string.Empty;
    public string Processor { get; set; } = string.Empty;
    public string? Storage { get; set; }
    public string Sku { get; set; } = string.Empty;
    public decimal PriceAdjustment { get; set; }
    public int StockQuantity { get; set; }
}

public class UpdateProductVariantDto
{
    public int VariantId { get; set; }
    public string Ram { get; set; } = string.Empty;
    public string Processor { get; set; } = string.Empty;
    public string? Storage { get; set; }
    public string Sku { get; set; } = string.Empty;
    public decimal PriceAdjustment { get; set; }
    public int StockQuantity { get; set; }
    public bool IsActive { get; set; }
}
