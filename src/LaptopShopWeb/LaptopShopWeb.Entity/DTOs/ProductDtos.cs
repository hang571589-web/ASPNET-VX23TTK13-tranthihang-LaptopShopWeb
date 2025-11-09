namespace LaptopShopWeb.Entity.DTOs;

public class ProductDto
{
    public int ProductId { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string Brand { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public decimal BasePrice { get; set; }
    public string? Screen { get; set; }
    public string? Os { get; set; }
    public string? GraphicsCard { get; set; }
    public string? Battery { get; set; }
    public decimal? Weight { get; set; }
    public List<ProductVariantDto> Variants { get; set; } = new();
}

public class CreateProductDto
{
    public int CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string Brand { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public decimal BasePrice { get; set; }
    public string? Screen { get; set; }
    public string? Os { get; set; }
    public string? GraphicsCard { get; set; }
    public string? Battery { get; set; }
    public decimal? Weight { get; set; }
}

public class UpdateProductDto
{
    public int ProductId { get; set; }
    public int CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string Brand { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public decimal BasePrice { get; set; }
    public string? Screen { get; set; }
    public string? Os { get; set; }
    public string? GraphicsCard { get; set; }
    public string? Battery { get; set; }
    public decimal? Weight { get; set; }
    public bool IsActive { get; set; }
}
