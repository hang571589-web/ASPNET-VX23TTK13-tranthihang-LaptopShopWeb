# BÁO CÁO TIẾN ĐỘ TUẦN 02

**Sinh viên**: Trần Thị Hằng  
**Lớp**: VX23TTK13  
**Thời gian**: Tuần 2 - Tháng 11/2025  
**Đồ án**: LaptopShopWeb - ASP.NET Core

---

## 📋 MỤC TIÊU TUẦN 02
- Thiết kế Database Schema (ERD)
- Implement Entity Models
- Setup Entity Framework Core
- Tạo và chạy Database Migrations
- Seed initial data

---

## ✅ CÔNG VIỆC ĐÃ HOÀN THÀNH

### 1. Thiết kế Database Schema
- ✅ Định nghĩa các bảng chính:
  - `Categories` - Danh mục sản phẩm (5 categories)
  - `Products` - Sản phẩm laptop (7 sample products)
  - `Users` - Người dùng (1 admin user)
  - `Orders` - Đơn hàng
  - `OrderDetails` - Chi tiết đơn hàng
  - `ProductImages` - Hình ảnh sản phẩm
  - `Reviews` - Đánh giá sản phẩm
- ✅ Xác định relationships và foreign keys
- ✅ Định nghĩa indexes và constraints

**Database Schema (Dự kiến):**

```
Categories
- Id (PK)
- Name
- Description
- CreatedAt

Products
- Id (PK)
- CategoryId (FK)
- Name
- Description
- Price
- Brand
- CPU
- RAM
- Storage
- Screen
- StockQuantity
- ImageUrl
- CreatedAt
- UpdatedAt

Users
- Id (PK)
- Email
- PasswordHash
- FullName
- PhoneNumber
- Address
- Role
- CreatedAt

Orders
- Id (PK)
- UserId (FK)
- OrderDate
- TotalAmount
- Status
- ShippingAddress
- PaymentMethod

OrderDetails
- Id (PK)
- OrderId (FK)
- ProductId (FK)
- Quantity
- UnitPrice
- Subtotal
```

### 2. Implement Entity Models
- ✅ Tạo entities trong `LaptopShopWeb.Entity`:
  - `BaseEntity.cs` - Base class với common properties
  - `Category.cs` - Danh mục sản phẩm
  - `Product.cs` - Sản phẩm (đầy đủ specs)
  - `User.cs` - Người dùng với roles
  - `Order.cs` - Đơn hàng
  - `OrderDetail.cs` - Chi tiết đơn hàng
  - `ProductImage.cs` - Hình ảnh sản phẩm
  - `Review.cs` - Đánh giá sản phẩm
- ✅ Thêm Data Annotations (Required, MaxLength, etc.)
- ✅ Định nghĩa Navigation Properties
- ✅ Tạo base entity class với CreatedAt, UpdatedAt

### 3. Setup Entity Framework Core
- ✅ Cài đặt NuGet packages:
  - `Microsoft.EntityFrameworkCore` v9.0.0
  - `Microsoft.EntityFrameworkCore.Design` v9.0.0
  - `Npgsql.EntityFrameworkCore.PostgreSQL` v9.0.0
  - `Microsoft.EntityFrameworkCore.Tools` v9.0.0
- ✅ Tạo `ApplicationDbContext` trong DAL layer
- ✅ Cấu hình DbSets cho các entities (7 DbSets)
- ✅ Cấu hình Fluent API trong `OnModelCreating`
- ✅ Cập nhật connection string trong `appsettings.json`
- ✅ Override SaveChanges để tự động cập nhật timestamps

### 4. Database Migrations
- ✅ Tạo initial migration: `InitialCreate`
- ✅ Review migration files
- ✅ Update database: Tables created successfully
- ✅ Verify tables được tạo trong PostgreSQL (8 tables)
- ✅ Test connection từ application

### 5. Seed Initial Data
- ✅ Seed Categories (5 categories: Gaming, Văn Phòng, Đồ Họa, Mỏng Nhẹ, Cao Cấp)
- ✅ Seed sample Products (7 products từ các hãng: ASUS, Dell, Apple, MSI, HP, Lenovo, Acer)
- ✅ Seed admin user (admin@laptopshop.com)
- ✅ Cấu hình seed data trong ApplicationDbContext
- ✅ Data được insert thành công vào PostgreSQL

---

## 📊 TIẾN ĐỘ THỰC HIỆN

- [x] Project setup & Docker - **100%** ✓
- [x] Database Schema Design - **100%** ✓
- [x] Entity Models Implementation - **100%** ✓
- [x] EF Core Setup - **100%** ✓
- [x] Migrations & Database Creation - **100%** ✓
- [x] Data Seeding - **100%** ✓

**Tổng tiến độ dự án**: ~40%  
**Mục tiêu tuần 02**: ✅ **ĐÃ ĐẠT 40%**

---

## 🎯 CÔNG VIỆC CHI TIẾT

### Phase 1: Database Design (Ngày 1-2)
```
✓ Nghiên cứu yêu cầu hệ thống
✓ Xác định các entities cần thiết
⟳ Vẽ ERD diagram (draw.io hoặc dbdiagram.io)
⟳ Review và điều chỉnh schema
```

### Phase 2: Entity Implementation (Ngày 3-4)
```
⟳ Tạo các entity classes
⟳ Thêm validation attributes
⟳ Định nghĩa relationships
⟳ Code review entities
```

### Phase 3: EF Core Setup (Ngày 5-6)
```
⟳ Install EF Core packages
⟳ Tạo DbContext
⟳ Configure entities
⟳ Test connection
```

### Phase 4: Migration & Seeding (Ngày 7)
```
⟳ Create & run migrations
⟳ Verify database structure
⟳ Create seed data
⟳ Test data access
```

---

## 🛠️ PACKAGES CẦN CÀI ĐẶT

| Package | Version | Layer | Mục đích |
|---------|---------|-------|----------|
| Microsoft.EntityFrameworkCore | 9.0.x | DAL | EF Core framework |
| Microsoft.EntityFrameworkCore.Design | 9.0.x | DAL | Migration tools |
| Npgsql.EntityFrameworkCore.PostgreSQL | 9.0.x | DAL | PostgreSQL provider |
| Microsoft.EntityFrameworkCore.Tools | 9.0.x | DAL | Package Manager Console |

**Commands để cài đặt:**
```bash
cd src/LaptopShopWeb/LaptopShopWeb.DAL
dotnet add package Microsoft.EntityFrameworkCore --version 9.0.0
dotnet add package Microsoft.EntityFrameworkCore.Design --version 9.0.0
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 9.0.0
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 9.0.0
```

---

## 📝 MẪU CODE DỰ KIẾN

### Entity Example: Product.cs
```csharp
public class Product
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(200)]
    public string Name { get; set; }
    
    public int CategoryId { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    
    // Navigation Properties
    public Category Category { get; set; }
    public ICollection<OrderDetail> OrderDetails { get; set; }
}
```

### DbContext Example
```csharp
public class ApplicationDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure relationships
        // Configure constraints
        // Seed data
    }
}
```

---

## 🔧 VẤN ĐỀ CÓ THỂ GẶP PHẢI

| Vấn đề | Giải pháp dự kiến |
|--------|-------------------|
| PostgreSQL connection error | Check Docker container status, verify connection string |
| Migration conflicts | Delete migration files và database, tạo lại từ đầu |
| Circular reference trong entities | Sử dụng `[JsonIgnore]` attribute |
| Data type mismatch | Sử dụng `[Column(TypeName)]` attribute |

---

## 🎯 KẾ HOẠCH TUẦN 03

1. **Data Access Layer Implementation**
   - Tạo Repository Pattern
   - Implement Generic Repository
   - Tạo Unit of Work pattern
   - Viết CRUD operations

2. **Business Logic Layer**
   - Tạo Service interfaces
   - Implement Services
   - Add business validation
   - Error handling

3. **Testing**
   - Test Repository methods
   - Test Service methods
   - Verify database operations

---

## 📚 TÀI LIỆU THAM KHẢO

- [EF Core Documentation](https://docs.microsoft.com/en-us/ef/core/)
- [PostgreSQL with EF Core](https://www.npgsql.org/efcore/)
- [Code First Migrations](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/)
- [Data Seeding](https://docs.microsoft.com/en-us/ef/core/modeling/data-seeding)

---

## 📸 SCREENSHOTS

*Sẽ bổ sung khi hoàn thành:*
- [ ] ERD Diagram
- [ ] Database structure trong PgAdmin
- [ ] Migration files
- [ ] Seeded data trong database

---

## 📊 THỜI GIAN THỰC HIỆN

| Công việc | Thời gian dự kiến | Thực tế | Ghi chú |
|-----------|-------------------|---------|---------|
| Database Design | 2 ngày | - | - |
| Entity Implementation | 2 ngày | - | - |
| EF Core Setup | 1 ngày | - | - |
| Migration & Seeding | 1 ngày | - | - |
| Testing & Debug | 1 ngày | - | - |
| **TỔNG** | **7 ngày** | **-** | - |

---

## 💡 GHI CHÚ & BÀI HỌC

*Sẽ cập nhật sau khi hoàn thành tuần 2:*
- Những khó khăn gặp phải
- Cách giải quyết
- Kinh nghiệm rút ra
- Tips & tricks

---

**Trạng thái**: ✅ **ĐÃ HOÀN THÀNH**  
**Ngày bắt đầu**: 16/11/2025  
**Ngày hoàn thành**: 16/11/2025  
**Người thực hiện**: Trần Thị Hằng
