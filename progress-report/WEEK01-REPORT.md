# BÁO CÁO TIẾN ĐỘ TUẦN 01

**Sinh viên**: Trần Thị Hằng  
**Lớp**: VX23TTK13  
**Thời gian**: Tuần 1 - Tháng 11/2025  
**Đồ án**: LaptopShopWeb - ASP.NET Core

---

## 📋 MỤC TIÊU TUẦN 01
- Khởi tạo và cấu hình project ASP.NET Core
- Thiết lập môi trường phát triển
- Cấu hình Docker và Database
- Setup Git repository

---

## ✅ CÔNG VIỆC ĐÃ HOÀN THÀNH

### 1. Khởi tạo Project Structure
- ✅ Tạo solution `LaptopShopWeb.sln`
- ✅ Tạo 4 projects theo kiến trúc phân lớp:
  - `LaptopShopWeb` - Web/Presentation Layer (Razor Pages)
  - `LaptopShopWeb.BLL` - Business Logic Layer
  - `LaptopShopWeb.DAL` - Data Access Layer
  - `LaptopShopWeb.Entity` - Entity/Model Layer
- ✅ Cấu hình project dependencies và references

### 2. Cấu hình Docker & Database
- ✅ Tạo `docker-compose.yml` cho PostgreSQL 16
- ✅ Thêm PgAdmin 4 để quản lý database
- ✅ Tạo file `.env` và `.env.example` cho environment variables
- ✅ Cấu hình volumes và networks cho Docker containers
- ✅ Test kết nối PostgreSQL thành công

**Chi tiết cấu hình:**
- PostgreSQL: port 5432
- PgAdmin: port 5050
- Database name: `laptopshop`
- Health check và auto-restart được cấu hình

### 3. Setup Git Repository
- ✅ Tạo repository trên GitHub
- ✅ Tạo file `.gitignore` cho ASP.NET project
  - Loại bỏ bin/, obj/ folders
  - Loại bỏ .vs/, .idea/ IDE configs
  - Loại bỏ file .env (bảo mật)
  - Loại bỏ build artifacts
- ✅ Push initial commit lên GitHub

### 4. Documentation
- ✅ Tạo `README.md` với:
  - Giới thiệu dự án
  - Hướng dẫn cài đặt chi tiết
  - Kiến trúc hệ thống
  - Công nghệ sử dụng
  - Checklist tính năng
- ✅ Setup progress-report folder

---

## 📂 CẤU TRÚC PROJECT

```
LaptopShopWeb/
├── docker/
│   ├── docker-compose.yml
│   ├── .env
│   └── .env.example
├── src/
│   └── LaptopShopWeb/
│       ├── LaptopShopWeb.sln
│       ├── LaptopShopWeb/          # Web Layer
│       ├── LaptopShopWeb.BLL/      # Business Logic
│       ├── LaptopShopWeb.DAL/      # Data Access
│       └── LaptopShopWeb.Entity/   # Models
├── progress-report/
├── .gitignore
└── README.md
```

---

## 🛠️ CÔNG NGHỆ ĐÃ SỬ DỤNG

| Công nghệ | Phiên bản | Mục đích |
|-----------|-----------|----------|
| .NET Core | 9.0 | Framework chính |
| PostgreSQL | 16-alpine | Database |
| Docker | Latest | Containerization |
| PgAdmin 4 | Latest | Database Management |
| Git/GitHub | - | Version Control |

---

## 📊 TIẾN ĐỘ THỰC HIỆN

- [x] Khởi tạo project structure - **100%**
- [x] Cấu hình Docker & PostgreSQL - **100%**
- [x] Setup Git repository - **100%**
- [x] Viết documentation - **100%**
- [ ] Thiết kế Database Schema - **0%**
- [ ] Implement Entity Models - **0%**

**Tổng tiến độ tuần 01**: ~20% dự án

---

## 🎯 KẾ HOẠCH TUẦN 02

1. **Thiết kế Database**
   - Vẽ ERD diagram
   - Định nghĩa các bảng: Products, Categories, Users, Orders, OrderDetails
   - Xác định relationships và constraints

2. **Implement Entity Models**
   - Tạo các entity classes trong `LaptopShopWeb.Entity`
   - Định nghĩa properties và relationships
   - Thêm Data Annotations

3. **Setup Entity Framework Core**
   - Cài đặt EF Core packages
   - Tạo DbContext
   - Cấu hình connection string
   - Tạo và chạy migrations đầu tiên

4. **Seed Initial Data**
   - Tạo data seeder
   - Thêm sample data cho testing

---

## 🔧 VẤN ĐỀ GẶP PHẢI & GIẢI QUYẾT

| Vấn đề | Giải pháp |
|--------|-----------|
| Chưa rõ kiến trúc phân lớp | Nghiên cứu Layered Architecture pattern |
| Docker configuration | Tham khảo PostgreSQL Docker documentation |
| Git ignore files | Sử dụng template .gitignore cho ASP.NET |

---

## 📝 GHI CHÚ & KINH NGHIỆM

- Kiến trúc phân lớp giúp code dễ maintain và test
- Docker giúp đồng bộ môi trường phát triển
- .gitignore rất quan trọng để tránh commit các file không cần thiết
- README.md cần cập nhật thường xuyên theo tiến độ

---

## 📸 SCREENSHOTS

*Sẽ bổ sung trong các tuần tiếp theo khi có giao diện*

---

**Ngày báo cáo**: 16/11/2025  
**Người thực hiện**: Trần Thị Hằng
