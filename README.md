# LaptopShopWeb - ASP.NET Core Project

## 📋 Giới thiệu
Đồ án xây dựng website bán laptop sử dụng ASP.NET Core với kiến trúc phân lớp (Layered Architecture).

## 👥 Thông tin
- **Sinh viên thực hiện**: Trần Thị Hằng
- **Lớp**: VX23TTK13
- **Môn học**: ASP.NET

## 🏗️ Kiến trúc dự án
```
LaptopShopWeb/
├── LaptopShopWeb/          # Web layer (Presentation)
├── LaptopShopWeb.BLL/      # Business Logic Layer
├── LaptopShopWeb.DAL/      # Data Access Layer
└── LaptopShopWeb.Entity/   # Entity/Model Layer
```

## 🛠️ Công nghệ sử dụng
- **Framework**: ASP.NET Core 9.0
- **Database**: PostgreSQL 16
- **ORM**: Entity Framework Core
- **UI**: Razor Pages
- **Container**: Docker & Docker Compose

## 📦 Yêu cầu hệ thống
- .NET 9.0 SDK
- Docker Desktop
- Visual Studio 2022 / VS Code / JetBrains Rider

## 🚀 Hướng dẫn cài đặt

### 1. Clone repository
```bash
git clone https://github.com/hang571589-web/ASPNET-VX23TTK13-tranthihang-LaptopShopWeb.git
cd ASPNET-VX23TTK13-tranthihang-LaptopShopWeb
```

### 2. Cấu hình môi trường
Sao chép file `.env.example` thành `.env` và cập nhật thông tin nếu cần:
```bash
cp .env.example .env
```

### 3. Khởi động Database với Docker
```bash
docker-compose up -d
```

Database sẽ chạy với cấu hình từ file `.env`:
- Host: localhost
- Port: 5432
- Database: laptopshop
- Username: postgres
- Password: postgres123

### 4. Kết nối Database với DBeaver
Xem hướng dẫn chi tiết tại [DBEAVER_CONNECTION.md](DBEAVER_CONNECTION.md)

### 5. Chạy Migration
```bash
cd src/LaptopShopWeb/LaptopShopWeb
dotnet ef database update
```

### 6. Chạy ứng dụng
```bash
dotnet run
```

Truy cập: `http://localhost:5277`

## 🗄️ Quản lý Database
- **DBeaver**: Sử dụng DBeaver để kết nối và quản lý database (xem [DBEAVER_CONNECTION.md](DBEAVER_CONNECTION.md))
- Connection info từ file `.env`

## 📝 Tính năng đã thực hiện
- [x] Setup project structure với kiến trúc phân lớp
- [x] Cấu hình Docker PostgreSQL
- [x] Cấu hình Git & .gitignore
- [ ] Thiết kế database schema
- [ ] Implement Entity models
- [ ] Implement Data Access Layer
- [ ] Implement Business Logic Layer
- [ ] Xây dựng giao diện người dùng
- [ ] Chức năng quản lý sản phẩm
- [ ] Chức năng giỏ hàng
- [ ] Chức năng đặt hàng
- [ ] Authentication & Authorization

## 📚 Tài liệu tham khảo
- [ASP.NET Core Documentation](https://docs.microsoft.com/aspnet/core)
- [Entity Framework Core](https://docs.microsoft.com/ef/core)
- [PostgreSQL Documentation](https://www.postgresql.org/docs/)

## 📧 Liên hệ
- GitHub: [@hang571589-web](https://github.com/hang571589-web)

---
*Cập nhật lần cuối: Tháng 11, 2025*
