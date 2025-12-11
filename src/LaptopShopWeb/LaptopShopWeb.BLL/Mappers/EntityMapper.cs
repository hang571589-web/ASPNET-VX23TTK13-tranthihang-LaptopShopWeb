using LaptopShopWeb.BLL.DTOs;
using LaptopShopWeb.Entity;

namespace LaptopShopWeb.BLL.Mappers;

public static class EntityMapper
{
    // Product Mapping
    public static ProductDto ToDto(this Product product)
    {
        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            StockQuantity = product.StockQuantity,
            CategoryId = product.CategoryId,
            CategoryName = product.Category?.Name ?? string.Empty,
            ImageUrl = product.ImageUrl,
            IsActive = product.IsActive,
            IsFeatured = product.IsFeatured,
            HasVariants = product.HasVariants,
            Brand = product.Brand,
            CreatedAt = product.CreatedAt,
            Variants = product.ProductVariants?.Select(v => v.ToDto()).ToList() ?? new(),
            Images = product.ProductImages?.Select(i => i.ToDto()).ToList() ?? new(),
            Reviews = product.Reviews?.Select(r => r.ToDto()).ToList() ?? new()
        };
    }

    public static Product ToEntity(this ProductDto dto)
    {
        return new Product
        {
            Id = dto.Id,
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            StockQuantity = dto.StockQuantity,
            CategoryId = dto.CategoryId,
            ImageUrl = dto.ImageUrl,
            IsActive = dto.IsActive,
            IsFeatured = dto.IsFeatured,
            HasVariants = dto.HasVariants,
            Brand = dto.Brand
        };
    }

    // ProductVariant Mapping
    public static ProductVariantDto ToDto(this ProductVariant variant)
    {
        return new ProductVariantDto
        {
            Id = variant.Id,
            ProductId = variant.ProductId,
            CPU = variant.CPU,
            RAM = variant.RAM,
            Storage = variant.Storage,
            GraphicsCard = variant.GraphicsCard,
            Price = variant.Price,
            StockQuantity = variant.StockQuantity,
            SKU = variant.SKU,
            IsActive = variant.IsActive
        };
    }

    public static ProductVariant ToEntity(this ProductVariantDto dto)
    {
        return new ProductVariant
        {
            Id = dto.Id,
            ProductId = dto.ProductId,
            CPU = dto.CPU,
            RAM = dto.RAM,
            Storage = dto.Storage,
            GraphicsCard = dto.GraphicsCard,
            Price = dto.Price,
            StockQuantity = dto.StockQuantity,
            SKU = dto.SKU,
            IsActive = dto.IsActive
        };
    }

    // Category Mapping
    public static CategoryDto ToDto(this Category category)
    {
        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description,
            Slug = category.Slug,
            IsActive = category.IsActive,
            ProductCount = category.Products?.Count ?? 0,
            Products = category.Products?.Select(p => p.ToDto()).ToList() ?? new()
        };
    }

    public static Category ToEntity(this CategoryDto dto)
    {
        return new Category
        {
            Id = dto.Id,
            Name = dto.Name,
            Description = dto.Description,
            Slug = dto.Slug,
            IsActive = dto.IsActive
        };
    }

    // Cart Mapping
    public static CartDto ToDto(this Cart cart)
    {
        return new CartDto
        {
            Id = cart.Id,
            UserId = cart.UserId,
            CartItems = cart.CartItems?.Select(ci => ci.ToDto()).ToList() ?? new()
        };
    }

    // CartItem Mapping
    public static CartItemDto ToDto(this CartItem cartItem)
    {
        var variantName = "";
        if (cartItem.ProductVariant != null)
        {
            variantName = $"{cartItem.ProductVariant.CPU} / {cartItem.ProductVariant.RAM} / {cartItem.ProductVariant.Storage}";
            if (!string.IsNullOrEmpty(cartItem.ProductVariant.GraphicsCard))
            {
                variantName += $" / {cartItem.ProductVariant.GraphicsCard}";
            }
        }
        
        return new CartItemDto
        {
            Id = cartItem.Id,
            CartId = cartItem.CartId,
            ProductId = cartItem.ProductId,
            ProductName = cartItem.Product?.Name ?? string.Empty,
            ProductImageUrl = cartItem.Product?.ImageUrl,
            ProductVariantId = cartItem.ProductVariantId,
            VariantName = variantName,
            Quantity = cartItem.Quantity,
            Price = cartItem.Price
        };
    }

    // Order Mapping
    public static OrderDto ToDto(this Order order)
    {
        return new OrderDto
        {
            Id = order.Id,
            OrderNumber = order.OrderNumber,
            UserId = order.UserId,
            UserName = order.User?.FullName ?? string.Empty,
            UserEmail = order.User?.Email ?? string.Empty,
            OrderDate = order.OrderDate,
            TotalAmount = order.TotalAmount,
            Status = order.Status,
            ShippingAddress = order.ShippingAddress,
            ShippingCity = order.ShippingCity,
            ShippingPhone = order.ShippingPhone,
            PaymentMethod = order.PaymentMethod,
            Notes = order.Notes,
            OrderDetails = order.OrderDetails?.Select(od => od.ToDto()).ToList() ?? new()
        };
    }

    // OrderDetail Mapping
    public static OrderDetailDto ToDto(this OrderDetail orderDetail)
    {
        return new OrderDetailDto
        {
            Id = orderDetail.Id,
            OrderId = orderDetail.OrderId,
            ProductId = orderDetail.ProductId,
            ProductName = orderDetail.Product?.Name ?? string.Empty,
            ProductImageUrl = orderDetail.Product?.ImageUrl,
            ProductVariantId = orderDetail.ProductVariantId,
            VariantDescription = orderDetail.VariantDescription,
            Quantity = orderDetail.Quantity,
            UnitPrice = orderDetail.UnitPrice
        };
    }

    // User Mapping
    public static UserDto ToDto(this User user)
    {
        return new UserDto
        {
            Id = user.Id,
            Email = user.Email,
            FullName = user.FullName,
            PhoneNumber = user.PhoneNumber,
            Address = user.Address,
            Role = user.Role,
            IsActive = user.IsActive,
            CreatedAt = user.CreatedAt
        };
    }

    public static User ToEntity(this UserDto dto)
    {
        return new User
        {
            Id = dto.Id,
            Email = dto.Email,
            FullName = dto.FullName,
            PhoneNumber = dto.PhoneNumber,
            Address = dto.Address,
            Role = dto.Role,
            IsActive = dto.IsActive
        };
    }

    // ProductImage Mapping
    public static ProductImageDto ToDto(this ProductImage image)
    {
        return new ProductImageDto
        {
            Id = image.Id,
            ProductId = image.ProductId,
            ImageUrl = image.ImageUrl,
            IsPrimary = image.IsPrimary,
            DisplayOrder = image.DisplayOrder
        };
    }

    // Review Mapping
    public static ReviewDto ToDto(this Review review)
    {
        return new ReviewDto
        {
            Id = review.Id,
            ProductId = review.ProductId,
            UserId = review.UserId,
            UserName = review.User?.FullName ?? "Anonymous",
            Rating = review.Rating,
            Comment = review.Comment,
            CreatedAt = review.CreatedAt
        };
    }
}
