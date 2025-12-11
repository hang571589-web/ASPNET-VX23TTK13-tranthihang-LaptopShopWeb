# LaptopShopWeb - E-commerce Website

## 📋 Mô tả Project

Website bán laptop với đầy đủ tính năng quản lý sản phẩm, giỏ hàng, đặt hàng và quản trị hệ thống. Xây dựng bằng ASP.NET Core 9.0 với kiến trúc phân lớp (Layered Architecture).

**Sinh viên**: Trần Thị Hằng - Lớp VX23TTK13

## 🛠️ Công nghệ

- **Backend**: ASP.NET Core 9.0, Entity Framework Core 9.0
- **Database**: PostgreSQL 15
- **Frontend**: Razor Pages, Bootstrap 5
- **Authentication**: Cookie-based với BCrypt
- **Container**: Docker & Docker Compose

## ✨ Tính năng

### Khách hàng

- Xem danh sách sản phẩm, tìm kiếm, lọc theo danh mục
- Xem chi tiết sản phẩm với variants (CPU, RAM, Storage)
- Thêm vào giỏ hàng, cập nhật số lượng
- Đặt hàng với thông tin giao hàng
- Xem lịch sử đơn hàng
- Quản lý tài khoản, đổi mật khẩu

### Quản trị viên

- Dashboard với thống kê tổng quan
- Quản lý danh mục: CRUD operations
- Quản lý sản phẩm: CRUD operations với filter/search
- Quản lý người dùng: phân quyền, kích hoạt/vô hiệu hóa
- Quản lý đơn hàng: cập nhật trạng thái theo workflow
- Xem chi tiết đơn hàng

## � Hướng dẫn chạy Project

### Yêu cầu

- .NET 9.0 SDK ([Download](https://dotnet.microsoft.com/download/dotnet/9.0))
- Docker Desktop ([Download](https://www.docker.com/products/docker-desktop))

### Bước 1: Clone repository

```bash
git clone https://github.com/hang571589-web/ASPNET-VX23TTK13-tranthihang-LaptopShopWeb.git
cd ASPNET-VX23TTK13-tranthihang-LaptopShopWeb
```

### Bước 2: Khởi động PostgreSQL với Docker

```bash
cd docker
docker-compose up -d
```

Chờ 5-10 giây để PostgreSQL khởi động hoàn toàn.

### Bước 3: Update Database (chạy migrations)

```bash
cd ../src/LaptopShopWeb/LaptopShopWeb
dotnet ef database update --project ../LaptopShopWeb.DAL
```

Lệnh này sẽ:

- Tạo 9 tables trong database
- Seed dữ liệu mẫu: 5 categories, 7 products, 1 admin user

### Bước 4: Trust HTTPS certificate

```bash
dotnet dev-certs https --trust
```

### Bước 5: Chạy ứng dụng với HTTPS

```bash
dotnet watch run --launch-profile https
```

### Bước 6: Truy cập ứng dụng

- **HTTPS**: https://localhost:7253
- **HTTP**: http://localhost:5277

## 👤 Tài khoản mẫu

### Admin

- Email: `admin@laptopshop.com`
- Password: (đã được seed với BCrypt hash)

## 🗄️ Cấu trúc Database

9 tables chính:

- **Categories**: Danh mục sản phẩm
- **Products**: Sản phẩm laptop
- **ProductVariants**: Biến thể sản phẩm (CPU, RAM, Storage)
- **ProductImages**: Hình ảnh sản phẩm
- **Users**: Người dùng (Customer, Admin)
- **Carts**: Giỏ hàng
- **CartItems**: Chi tiết giỏ hàng
- **Orders**: Đơn hàng
- **OrderDetails**: Chi tiết đơn hàng
- **Reviews**: Đánh giá sản phẩm

## 🏗️ Kiến trúc Project

```
src/LaptopShopWeb/
├── LaptopShopWeb/              # Presentation Layer (Razor Pages)
├── LaptopShopWeb.BLL/          # Business Logic Layer (Services, DTOs)
├── LaptopShopWeb.DAL/          # Data Access Layer (Repositories, EF Core)
└── LaptopShopWeb.Entity/       # Domain Models (Entities)
```

## 🐳 Docker Commands

```bash
# Khởi động PostgreSQL
docker-compose up -d

# Dừng PostgreSQL
docker-compose down

# Xóa volumes (reset database)
docker-compose down -v

# Xem logs
docker-compose logs -f
```

## 📊 Migration Commands

```bash
# Update database
dotnet ef database update --project ../LaptopShopWeb.DAL

# Tạo migration mới
dotnet ef migrations add MigrationName --project ../LaptopShopWeb.DAL

# Xóa migration cuối
dotnet ef migrations remove --project ../LaptopShopWeb.DAL
```

## 🔧 Troubleshooting

### Lỗi: Database connection failed

```bash
# Kiểm tra PostgreSQL đang chạy
docker ps

# Restart PostgreSQL
cd docker
docker-compose restart
```

### Lỗi: Port 5277 hoặc 7253 đã được sử dụng

```bash
# macOS/Linux: Kill process trên port
lsof -ti:5277,7253 | xargs kill -9

# Hoặc thay đổi port trong Properties/launchSettings.json
```

### Lỗi: Migration failed

```bash
# Xóa database và chạy lại
docker-compose down -v
docker-compose up -d
sleep 5
dotnet ef database update --project ../LaptopShopWeb.DAL
```

## 📈 Tiến độ hoàn thành: 100%

- ✅ Project structure & Docker setup
- ✅ Database design & Entity models (9 tables)
- ✅ Repository Pattern & Unit of Work
- ✅ Business Logic Layer (5 services, 12 DTOs)
- ✅ Authentication & Authorization
- ✅ Customer UI (11 pages)
- ✅ Admin Dashboard (11 pages)
- ✅ Shopping Cart & Checkout
- ✅ Order Management
- ✅ Bug fixes & Optimization

## 📧 Liên hệ

- GitHub: [@hang571589-web](https://github.com/hang571589-web)
- Repository: [LaptopShopWeb](https://github.com/hang571589-web/ASPNET-VX23TTK13-tranthihang-LaptopShopWeb)

---

_Cập nhật: Tháng 12, 2025_
