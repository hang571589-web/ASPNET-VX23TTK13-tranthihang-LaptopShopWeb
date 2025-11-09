namespace LaptopShopWeb.Entity.DTOs;

public class CartDto
{
    public int CartId { get; set; }
    public int CustomerId { get; set; }
    public List<CartItemDto> Items { get; set; } = new();
    public decimal TotalAmount { get; set; }
}

public class CartItemDto
{
    public int CartItemId { get; set; }
    public int VariantId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string Ram { get; set; } = string.Empty;
    public string Processor { get; set; } = string.Empty;
    public string? Storage { get; set; }
    public string? ImageUrl { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
    public int StockQuantity { get; set; }
}

public class AddToCartDto
{
    public int VariantId { get; set; }
    public int Quantity { get; set; }
}

public class UpdateCartItemDto
{
    public int CartItemId { get; set; }
    public int Quantity { get; set; }
}
