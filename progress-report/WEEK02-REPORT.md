# BÁO CÁO TIẾN ĐỘ TUẦN 02

**Sinh viên**: Trần Thị Hằng  
**Lớp**: VX23TTK13  
**Thời gian**: Tuần 2 - Tháng 11/2025  
**Đồ án**: LaptopShopWeb - ASP.NET Core

---

## 📋 CÔNG VIỆC ĐÃ HOÀN THÀNH

### 1. Thiết kế Database Schema

- Thiết kế 8 bảng chính: Categories, Products, Users, Orders, OrderDetails, ProductImages, Reviews, ProductVariants
- Định nghĩa relationships và foreign keys giữa các bảng
- Xác định indexes và constraints cho hiệu suất
- Lập kế hoạch seed data cho 5 categories và 7 sample products

### 2. Implement Entity Models

- Tạo BaseEntity.cs với properties: Id, CreatedAt, UpdatedAt
- Implement 8 entity classes trong LaptopShopWeb.Entity:
  - Category: Danh mục sản phẩm với Name, Description, Slug
  - Product: Sản phẩm laptop với đầy đủ specs (Brand, CPU, RAM, Storage, Screen, Price, etc.)
  - User: Người dùng với Email, PasswordHash, FullName, Role, Address
  - Order: Đơn hàng với OrderNumber, TotalAmount, Status, ShippingAddress
  - OrderDetail: Chi tiết đơn hàng với Quantity, UnitPrice, Subtotal
  - ProductImage: Hình ảnh sản phẩm với ImageUrl, DisplayOrder
  - Review: Đánh giá sản phẩm với Rating, Comment, IsApproved
  - ProductVariant: Biến thể sản phẩm với SKU, Price, StockQuantity
- Thêm Data Annotations: [Required], [MaxLength], [Column], [EmailAddress]
- Định nghĩa Navigation Properties cho relationships

### 3. Setup Entity Framework Core

- Cài đặt NuGet packages: Microsoft.EntityFrameworkCore (v9.0.0), EFCore.Design, Npgsql.EFCore.PostgreSQL, EFCore.Tools
- Tạo ApplicationDbContext trong LaptopShopWeb.DAL
- Cấu hình 8 DbSets cho các entities
- Cấu hình Fluent API trong OnModelCreating: relationships, constraints, indexes
- Cập nhật connection string trong appsettings.json
- Override SaveChanges để tự động cập nhật CreatedAt, UpdatedAt timestamps

### 4. Database Migrations

- Tạo initial migration: InitialCreate
- Review migration files và SQL statements
- Chạy dotnet ef database update - tạo thành công 8 tables
- Verify database structure trong PgAdmin
- Test connection từ application

### 5. Seed Initial Data

- Seed 5 Categories: Gaming, Văn Phòng, Đồ Họa, Mỏng Nhẹ, Cao Cấp
- Seed 7 sample Products từ các hãng: ASUS ROG, Dell XPS, Apple MacBook, MSI Creator, HP Pavilion, Lenovo ThinkPad, Acer Aspire
- Seed 1 admin user: admin@laptopshop.com
- Cấu hình seed data trong ApplicationDbContext.OnModelCreating
- Verify data insertion thành công trong PostgreSQL

---

## � KẾ HOẠCH TUẦN TIẾP THEO

### Tuần 03 - Repository Pattern & Business Logic

- Implement Repository Pattern và Generic Repository
- Tạo Unit of Work pattern
- Develop Business Logic Layer với Services
- Tạo DTOs (Data Transfer Objects) và Mappers
- Build Authentication System với cookie-based auth
- Implement Shopping Cart functionality
- Create Customer-facing UI với Razor Pages
- Develop Product listing, detail, search pages

---

## 📊 TỔNG KẾT

**Hoàn thành**: 100%

- ✅ Database schema design (8 tables)
- ✅ Entity models implementation
- ✅ EF Core setup & configuration
- ✅ Migrations & database creation
- ✅ Data seeding (5 categories, 7 products, 1 admin user)

**Tiến độ dự án**: 40%

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

| Package                               | Version | Layer | Mục đích                |
| ------------------------------------- | ------- | ----- | ----------------------- |
| Microsoft.EntityFrameworkCore         | 9.0.x   | DAL   | EF Core framework       |
| Microsoft.EntityFrameworkCore.Design  | 9.0.x   | DAL   | Migration tools         |
| Npgsql.EntityFrameworkCore.PostgreSQL | 9.0.x   | DAL   | PostgreSQL provider     |
| Microsoft.EntityFrameworkCore.Tools   | 9.0.x   | DAL   | Package Manager Console |

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

| Vấn đề                            | Giải pháp dự kiến                                       |
| --------------------------------- | ------------------------------------------------------- |
| PostgreSQL connection error       | Check Docker container status, verify connection string |
| Migration conflicts               | Delete migration files và database, tạo lại từ đầu      |
| Circular reference trong entities | Sử dụng `[JsonIgnore]` attribute                        |
| Data type mismatch                | Sử dụng `[Column(TypeName)]` attribute                  |

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

_Sẽ bổ sung khi hoàn thành:_

- [ ] ERD Diagram
- [ ] Database structure trong PgAdmin
- [ ] Migration files
- [ ] Seeded data trong database

---

## 📊 THỜI GIAN THỰC HIỆN

| Công việc             | Thời gian dự kiến | Thực tế | Ghi chú |
| --------------------- | ----------------- | ------- | ------- |
| Database Design       | 2 ngày            | -       | -       |
| Entity Implementation | 2 ngày            | -       | -       |
| EF Core Setup         | 1 ngày            | -       | -       |
| Migration & Seeding   | 1 ngày            | -       | -       |
| Testing & Debug       | 1 ngày            | -       | -       |
| **TỔNG**              | **7 ngày**        | **-**   | -       |

---

## 💡 GHI CHÚ & BÀI HỌC

_Sẽ cập nhật sau khi hoàn thành tuần 2:_

- Những khó khăn gặp phải
- Cách giải quyết
- Kinh nghiệm rút ra
- Tips & tricks

---

**Trạng thái**: ✅ **ĐÃ HOÀN THÀNH**  
**Ngày bắt đầu**: 16/11/2025  
**Ngày hoàn thành**: 16/11/2025  
**Người thực hiện**: Trần Thị Hằng
