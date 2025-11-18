using LaptopShopWeb.Entity;
using Microsoft.EntityFrameworkCore;

namespace LaptopShopWeb.DAL.SeedData;

public static class ProductSeeder
{
    public static void SeedProducts(ModelBuilder modelBuilder)
    {
        var now = new DateTime(2024, 11, 16, 0, 0, 0, DateTimeKind.Utc);
        
        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                CategoryId = 1,
                Name = "ASUS ROG Strix G15 G513",
                Description = "Laptop gaming ASUS ROG Strix G15 với AMD Ryzen 7, RTX 3060, màn hình 15.6 inch 144Hz",
                Price = 32990000,
                DiscountPrice = 29990000,
                Brand = "ASUS",
                CPU = "AMD Ryzen 7 5800H",
                RAM = "16GB DDR4",
                Storage = "512GB SSD NVMe",
                Screen = "15.6 inch FHD 144Hz",
                GraphicsCard = "NVIDIA RTX 3060 6GB",
                OperatingSystem = "Windows 11",
                Weight = 2.3m,
                Color = "Black",
                StockQuantity = 15,
                ImageUrl = "/images/products/asus-rog-strix-g15.jpg",
                Slug = "asus-rog-strix-g15-g513",
                IsActive = true,
                IsFeatured = true,
                CreatedAt = now
            },
            new Product
            {
                Id = 2,
                CategoryId = 2,
                Name = "Dell Inspiron 15 3520",
                Description = "Laptop Dell Inspiron 15 cho văn phòng với Intel Core i5, thiết kế gọn nhẹ",
                Price = 15990000,
                Brand = "Dell",
                CPU = "Intel Core i5-1235U",
                RAM = "8GB DDR4",
                Storage = "256GB SSD",
                Screen = "15.6 inch FHD",
                GraphicsCard = "Intel Iris Xe",
                OperatingSystem = "Windows 11",
                Weight = 1.8m,
                Color = "Silver",
                StockQuantity = 25,
                ImageUrl = "/images/products/dell-inspiron-15.jpg",
                Slug = "dell-inspiron-15-3520",
                IsActive = true,
                CreatedAt = now
            },
            new Product
            {
                Id = 3,
                CategoryId = 5,
                Name = "MacBook Pro 14 M3",
                Description = "MacBook Pro 14 inch với chip M3, màn hình Liquid Retina XDR",
                Price = 52990000,
                DiscountPrice = 49990000,
                Brand = "Apple",
                CPU = "Apple M3",
                RAM = "16GB Unified",
                Storage = "512GB SSD",
                Screen = "14.2 inch Liquid Retina XDR",
                GraphicsCard = "10-core GPU",
                OperatingSystem = "macOS",
                Weight = 1.6m,
                Color = "Space Gray",
                StockQuantity = 10,
                ImageUrl = "/images/products/macbook-pro-14-m3.jpg",
                Slug = "macbook-pro-14-m3",
                IsActive = true,
                IsFeatured = true,
                CreatedAt = now
            },
            new Product
            {
                Id = 4,
                CategoryId = 3,
                Name = "MSI Creator Z16",
                Description = "Laptop MSI Creator Z16 dành cho đồ họa với Intel Core i7 và RTX 4060",
                Price = 45990000,
                Brand = "MSI",
                CPU = "Intel Core i7-13700H",
                RAM = "32GB DDR5",
                Storage = "1TB SSD NVMe",
                Screen = "16 inch QHD+ 165Hz",
                GraphicsCard = "NVIDIA RTX 4060 8GB",
                OperatingSystem = "Windows 11 Pro",
                Weight = 2.2m,
                Color = "Gray",
                StockQuantity = 8,
                ImageUrl = "/images/products/msi-creator-z16.jpg",
                Slug = "msi-creator-z16",
                IsActive = true,
                IsFeatured = true,
                CreatedAt = now
            },
            new Product
            {
                Id = 5,
                CategoryId = 4,
                Name = "HP Pavilion Aero 13",
                Description = "Laptop HP Pavilion Aero 13 siêu mỏng nhẹ chỉ 1kg với AMD Ryzen 5",
                Price = 19990000,
                DiscountPrice = 17990000,
                Brand = "HP",
                CPU = "AMD Ryzen 5 7535U",
                RAM = "16GB LPDDR5",
                Storage = "512GB SSD",
                Screen = "13.3 inch WUXGA",
                GraphicsCard = "AMD Radeon",
                OperatingSystem = "Windows 11",
                Weight = 0.99m,
                Color = "Pale Gold",
                StockQuantity = 20,
                ImageUrl = "/images/products/hp-pavilion-aero-13.jpg",
                Slug = "hp-pavilion-aero-13",
                IsActive = true,
                CreatedAt = now
            },
            new Product
            {
                Id = 6,
                CategoryId = 1,
                Name = "Lenovo Legion 5 Pro",
                Description = "Laptop gaming Lenovo Legion 5 Pro với AMD Ryzen 7 và RTX 3070",
                Price = 38990000,
                DiscountPrice = 35990000,
                Brand = "Lenovo",
                CPU = "AMD Ryzen 7 6800H",
                RAM = "16GB DDR5",
                Storage = "512GB SSD",
                Screen = "16 inch WQXGA 165Hz",
                GraphicsCard = "NVIDIA RTX 3070 8GB",
                OperatingSystem = "Windows 11",
                Weight = 2.5m,
                Color = "Storm Grey",
                StockQuantity = 12,
                ImageUrl = "/images/products/lenovo-legion-5-pro.jpg",
                Slug = "lenovo-legion-5-pro",
                IsActive = true,
                IsFeatured = true,
                CreatedAt = now
            },
            new Product
            {
                Id = 7,
                CategoryId = 2,
                Name = "Acer Aspire 5 A515",
                Description = "Laptop Acer Aspire 5 với Intel Core i3, phù hợp học sinh sinh viên",
                Price = 12990000,
                Brand = "Acer",
                CPU = "Intel Core i3-1215U",
                RAM = "8GB DDR4",
                Storage = "256GB SSD",
                Screen = "15.6 inch FHD",
                GraphicsCard = "Intel UHD",
                OperatingSystem = "Windows 11",
                Weight = 1.7m,
                Color = "Silver",
                StockQuantity = 30,
                ImageUrl = "/images/products/acer-aspire-5.jpg",
                Slug = "acer-aspire-5-a515",
                IsActive = true,
                CreatedAt = now
            }
        );
    }
}
