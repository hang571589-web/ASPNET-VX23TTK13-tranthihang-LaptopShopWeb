using LaptopShopWeb.Entity;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

namespace LaptopShopWeb.DAL.SeedData;

public static class UserSeeder
{
    public static void SeedUsers(ModelBuilder modelBuilder)
    {
        var now = new DateTime(2024, 11, 16, 0, 0, 0, DateTimeKind.Utc);
        
        // Pre-generate password hashes
        // Admin password: Admin@123
        // Customer password: Customer@123
        var adminPasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin@123", 11);
        var customerPasswordHash = BCrypt.Net.BCrypt.HashPassword("Customer@123", 11);
        
        modelBuilder.Entity<User>().HasData(
            // Admin Account
            new User
            {
                Id = 1,
                Email = "admin@laptopshop.com",
                PasswordHash = adminPasswordHash,
                FullName = "Administrator",
                PhoneNumber = "0123456789",
                Address = "123 Admin Street",
                City = "Ho Chi Minh City",
                Role = "Admin",
                IsActive = true,
                CreatedAt = now
            },
            // Customer Account
            new User
            {
                Id = 2,
                Email = "customer@test.com",
                PasswordHash = customerPasswordHash,
                FullName = "Test Customer",
                PhoneNumber = "0987654321",
                Address = "456 Customer Street",
                City = "Hanoi",
                Role = "Customer",
                IsActive = true,
                CreatedAt = now
            }
        );
    }
}
