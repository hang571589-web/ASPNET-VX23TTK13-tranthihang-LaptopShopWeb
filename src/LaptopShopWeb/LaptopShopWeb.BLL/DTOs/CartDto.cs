namespace LaptopShopWeb.BLL.DTOs;

public class CartDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public List<CartItemDto> CartItems { get; set; } = new();
    
    // Alias properties for compatibility
    public List<CartItemDto> Items => CartItems;
    public int TotalItems => CartItems.Sum(item => item.Quantity);
    public decimal TotalAmount => CartItems.Sum(item => item.Subtotal);
    
    public decimal Total => TotalAmount;
    public int ItemCount => TotalItems;
}
