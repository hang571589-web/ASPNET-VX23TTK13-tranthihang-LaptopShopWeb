namespace LaptopShopWeb.BLL.DTOs;

public class OrderDto
{
    public int Id { get; set; }
    public string OrderNumber { get; set; } = string.Empty;
    public int UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string UserEmail { get; set; } = string.Empty;
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; } = string.Empty;
    public string? ShippingAddress { get; set; }
    public string? ShippingCity { get; set; }
    public string? ShippingPhone { get; set; }
    public string? PaymentMethod { get; set; }
    public string? Notes { get; set; }
    
    public List<OrderDetailDto> OrderDetails { get; set; } = new();
    
    // Alias properties for compatibility
    public List<OrderDetailDto> Items => OrderDetails;
    public string CustomerName => UserName;
    public string City => ShippingCity ?? string.Empty;
    public string PhoneNumber => ShippingPhone ?? string.Empty;
    public int TotalItems => OrderDetails.Sum(d => d.Quantity);
    
    public string StatusDisplay => Status switch
    {
        "Pending" => "Chờ xử lý",
        "Processing" => "Đang xử lý",
        "Shipped" => "Đang giao hàng",
        "Delivered" => "Đã giao hàng",
        "Cancelled" => "Đã hủy",
        _ => Status
    };
}
