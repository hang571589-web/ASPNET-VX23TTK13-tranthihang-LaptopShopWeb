# HƯỚNG DẪN KIỂM TRA & SỬ DỤNG

**Dự án**: LaptopShopWeb - ASP.NET Core 9.0  
**Ngày**: 16/11/2025

---

## 📋 YÊU CẦU HỆ THỐNG

- ✅ .NET 9.0 SDK
- ✅ Docker Desktop (đang chạy)
- ✅ PostgreSQL container (qua Docker Compose)

---

## 🚀 KHỞI ĐỘNG DỰ ÁN

### 1. Clone Repository
```bash
git clone https://github.com/hang571589-web/ASPNET-VX23TTK13-tranthihang-LaptopShopWeb.git
cd ASPNET-VX23TTK13-tranthihang-LaptopShopWeb
```

### 2. Khởi động PostgreSQL
```bash
cd docker
docker-compose up -d
```

**Kiểm tra container đang chạy:**
```bash
docker-compose ps
```

Kết quả mong đợi:
```
NAME                  STATUS
laptopshop_postgres   Up (healthy)
laptopshop_pgadmin    Up
```

### 3. Restore Dependencies
```bash
cd ../src/LaptopShopWeb
dotnet restore
```

### 4. Build Solution
```bash
dotnet build
```

### 5. Kiểm tra Database (Optional)
```bash
# Migration đã được chạy, nhưng có thể chạy lại nếu cần
cd LaptopShopWeb
dotnet ef database update --project ../LaptopShopWeb.DAL
```

### 6. Chạy Application
```bash
cd LaptopShopWeb
dotnet run
```

Hoặc với watch mode (auto-reload):
```bash
dotnet watch run
```

---

## 🔍 KIỂM TRA DATABASE

### Kết nối vào PostgreSQL Container
```bash
docker exec -it laptopshop_postgres psql -U postgres -d laptopshop
```

### Xem danh sách tables
```sql
\dt
```

Kết quả:
```
Categories
OrderDetails
Orders
ProductImages
Products
Reviews
Users
__EFMigrationsHistory
```

### Kiểm tra Categories
```sql
SELECT * FROM "Categories";
```

Kết quả: 5 categories (Laptop Gaming, Văn Phòng, Đồ Họa, Mỏng Nhẹ, Cao Cấp)

### Kiểm tra Products
```sql
SELECT "Id", "Name", "Brand", "Price", "StockQuantity" 
FROM "Products";
```

Kết quả: 7 products (ASUS, Dell, Apple, MSI, HP, Lenovo, Acer)

### Kiểm tra Users
```sql
SELECT "Id", "Email", "FullName", "Role" 
FROM "Users";
```

Kết quả: 1 admin user

### Thoát PostgreSQL CLI
```sql
\q
```

---

## 🌐 TRUY CẬP PGADMIN

1. Mở trình duyệt: http://localhost:5050
2. Đăng nhập:
   - Email: `admin@laptopshop.com`
   - Password: `admin123`

3. Thêm Server Connection:
   - Host: `postgres` (tên service trong docker-compose)
   - Port: `5432`
   - Database: `laptopshop`
   - Username: `postgres`
   - Password: `postgres123`

---

## 🧪 KIỂM TRA ENTITIES & DBCONTEXT

### Test Connection (C# Interactive hoặc tạo test page)
```csharp
using LaptopShopWeb.DAL;
using Microsoft.EntityFrameworkCore;

// Trong Startup hoặc Program.cs đã có:
// builder.Services.AddDbContext<ApplicationDbContext>(...)

// Test trong controller hoặc page:
var categories = await _context.Categories.ToListAsync();
Console.WriteLine($"Total categories: {categories.Count}"); // Should be 5

var products = await _context.Products
    .Include(p => p.Category)
    .Where(p => p.IsActive)
    .ToListAsync();
Console.WriteLine($"Total active products: {products.Count}"); // Should be 7
```

---

## 📊 QUERIES MẪU

### 1. Lấy tất cả products với category
```sql
SELECT 
    p."Name" as ProductName,
    p."Price",
    p."Brand",
    c."Name" as CategoryName
FROM "Products" p
JOIN "Categories" c ON p."CategoryId" = c."Id"
WHERE p."IsActive" = true
ORDER BY p."Price" DESC;
```

### 2. Đếm products theo category
```sql
SELECT 
    c."Name" as Category,
    COUNT(p."Id") as ProductCount
FROM "Categories" c
LEFT JOIN "Products" p ON c."Id" = p."CategoryId"
GROUP BY c."Name"
ORDER BY ProductCount DESC;
```

### 3. Lấy featured products
```sql
SELECT 
    "Name",
    "Brand",
    "Price",
    "DiscountPrice"
FROM "Products"
WHERE "IsFeatured" = true
ORDER BY "Price" DESC;
```

### 4. Tìm products trong khoảng giá
```sql
SELECT 
    "Name",
    "Brand",
    "Price"
FROM "Products"
WHERE "Price" BETWEEN 15000000 AND 40000000
ORDER BY "Price";
```

---

## 🛠️ COMMANDS HỮU ÍCH

### Docker Commands
```bash
# Xem logs
docker-compose logs postgres

# Restart containers
docker-compose restart

# Stop containers
docker-compose stop

# Stop và xóa containers (data vẫn giữ trong volumes)
docker-compose down

# Xóa containers và volumes (XÓA DATA)
docker-compose down -v
```

### EF Core Commands
```bash
# Tạo migration mới
dotnet ef migrations add MigrationName --project ../LaptopShopWeb.DAL

# Xem migrations
dotnet ef migrations list --project ../LaptopShopWeb.DAL

# Xóa migration cuối
dotnet ef migrations remove --project ../LaptopShopWeb.DAL

# Update database
dotnet ef database update --project ../LaptopShopWeb.DAL

# Rollback về migration cụ thể
dotnet ef database update MigrationName --project ../LaptopShopWeb.DAL

# Drop database
dotnet ef database drop --project ../LaptopShopWeb.DAL
```

### .NET Commands
```bash
# Build
dotnet build

# Run
dotnet run

# Watch (auto-reload)
dotnet watch run

# Clean
dotnet clean

# Restore packages
dotnet restore

# Check version
dotnet --version
```

---

## 🔐 THÔNG TIN ĐĂNG NHẬP

### PostgreSQL Database
- Host: localhost
- Port: 5432
- Database: laptopshop
- Username: postgres
- Password: postgres123

### PgAdmin
- URL: http://localhost:5050
- Email: admin@laptopshop.com
- Password: admin123

### Admin User (Application)
- Email: admin@laptopshop.com
- Password: (chưa implement authentication - sẽ làm trong tuần tới)

---

## 📁 CẤU TRÚC PROJECT

```
src/LaptopShopWeb/
├── LaptopShopWeb.sln              # Solution file
├── LaptopShopWeb/                 # Web layer
│   ├── Program.cs                 # Entry point + DbContext registration
│   ├── appsettings.json           # Configuration + Connection string
│   └── ...
├── LaptopShopWeb.Entity/          # Entity models
│   ├── BaseEntity.cs              # Base class
│   ├── Category.cs
│   ├── Product.cs
│   ├── User.cs
│   ├── Order.cs
│   ├── OrderDetail.cs
│   ├── ProductImage.cs
│   └── Review.cs
├── LaptopShopWeb.DAL/             # Data Access Layer
│   ├── ApplicationDbContext.cs    # DbContext + Fluent API + Seed data
│   └── Migrations/                # EF Core migrations
└── LaptopShopWeb.BLL/             # Business Logic Layer (sẽ implement tuần 3)
```

---

## ⚠️ TROUBLESHOOTING

### Lỗi: Connection refused (port 5432)
**Nguyên nhân**: PostgreSQL container chưa chạy  
**Giải pháp**:
```bash
cd docker
docker-compose up -d
docker-compose ps  # Kiểm tra status
```

### Lỗi: Migration pending changes
**Nguyên nhân**: DateTime.UtcNow trong seed data  
**Giải pháp**: Đã fix bằng static DateTime

### Lỗi: Package not found
**Nguyên nhân**: Chưa restore packages  
**Giải pháp**:
```bash
dotnet restore
dotnet build
```

### Lỗi: Cannot drop database (in use)
**Giải pháp**:
```bash
# Đóng tất cả connections, sau đó:
docker-compose restart postgres
```

---

## 📚 TÀI LIỆU THAM KHẢO

- [ASP.NET Core Docs](https://docs.microsoft.com/aspnet/core)
- [EF Core Docs](https://docs.microsoft.com/ef/core)
- [Npgsql EF Core Provider](https://www.npgsql.org/efcore/)
- [PostgreSQL Docs](https://www.postgresql.org/docs/)
- [Docker Compose](https://docs.docker.com/compose/)

---

## ✅ CHECKLIST KHI BẮT ĐẦU LÀM VIỆC

- [ ] Docker Desktop đang chạy
- [ ] PostgreSQL container đang chạy (`docker-compose ps`)
- [ ] Đã restore packages (`dotnet restore`)
- [ ] Database đã được migrate (`dotnet ef database update`)
- [ ] Application build thành công (`dotnet build`)

---

**Lưu ý**: Document này sẽ được cập nhật khi có thêm features mới!

*Cập nhật lần cuối: 16/11/2025*
