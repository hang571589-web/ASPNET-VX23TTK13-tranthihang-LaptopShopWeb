using LaptopShopWeb.Entity;
using Microsoft.EntityFrameworkCore;

namespace LaptopShopWeb.DAL.SeedData;

public static class CategorySeeder
{
    public static void SeedCategories(ModelBuilder modelBuilder)
    {
        var now = new DateTime(2024, 11, 16, 0, 0, 0, DateTimeKind.Utc);
        
        modelBuilder.Entity<Category>().HasData(
            new Category 
            { 
                Id = 1, 
                Name = "Laptop Gaming", 
                Description = "Laptop chuyên dụng cho game thủ với cấu hình mạnh mẽ",
                Slug = "laptop-gaming",
                IsActive = true,
                CreatedAt = now
            },
            new Category 
            { 
                Id = 2, 
                Name = "Laptop Văn Phòng", 
                Description = "Laptop phù hợp cho công việc văn phòng, học tập",
                Slug = "laptop-van-phong",
                IsActive = true,
                CreatedAt = now
            },
            new Category 
            { 
                Id = 3, 
                Name = "Laptop Đồ Họa", 
                Description = "Laptop dành cho thiết kế đồ họa, render video",
                Slug = "laptop-do-hoa",
                IsActive = true,
                CreatedAt = now
            },
            new Category 
            { 
                Id = 4, 
                Name = "Laptop Mỏng Nhẹ", 
                Description = "Laptop siêu mỏng nhẹ, dễ dàng di chuyển",
                Slug = "laptop-mong-nhe",
                IsActive = true,
                CreatedAt = now
            },
            new Category 
            { 
                Id = 5, 
                Name = "Laptop Cao Cấp", 
                Description = "Laptop cao cấp, sang trọng với hiệu năng vượt trội",
                Slug = "laptop-cao-cap",
                IsActive = true,
                CreatedAt = now
            }
        );
    }
}
