# BÁO CÁO TIẾN ĐỘ TUẦN 01

**Sinh viên**: Trần Thị Hằng  
**Lớp**: VX23TTK13  
**Thời gian**: Tuần 1 - Tháng 11/2025  
**Đồ án**: LaptopShopWeb - ASP.NET Core

---

## 📋 CÔNG VIỆC ĐÃ HOÀN THÀNH

### 1. Khởi tạo Project Structure

- Tạo solution LaptopShopWeb.sln với kiến trúc phân lớp
- Tạo 4 projects chính:
  - LaptopShopWeb: Web/Presentation Layer (Razor Pages)
  - LaptopShopWeb.BLL: Business Logic Layer
  - LaptopShopWeb.DAL: Data Access Layer
  - LaptopShopWeb.Entity: Entity/Model Layer
- Cấu hình project dependencies và references giữa các layers

### 2. Cấu hình Môi trường Phát triển

- Cài đặt .NET Core 9.0 SDK
- Setup Docker Desktop
- Cấu hình Docker Compose cho PostgreSQL 15
- Thêm PgAdmin 4 để quản lý database (port 5050)
- Tạo file .env và .env.example cho environment variables
- Cấu hình volumes, networks và health check cho containers
- Test kết nối database thành công (port 5432)

### 3. Setup Git Repository

- Tạo repository trên GitHub: LaptopShopWeb
- Tạo file .gitignore loại trừ: bin/, obj/, .vs/, .idea/, .env
- Push initial commit lên GitHub
- Setup branch protection và workflow

### 4. Documentation

- Viết README.md với giới thiệu dự án và hướng dẫn cài đặt
- Tạo progress-report folder để theo dõi tiến độ
- Document kiến trúc hệ thống và công nghệ sử dụng

---

## � KẾ HOẠCH TUẦN TIẾP THEO

### Tuần 02 - Thiết kế Database & Entity Models

- Thiết kế database schema với các bảng chính
- Implement Entity Models cho: Categories, Products, Users, Orders, Reviews
- Setup Entity Framework Core và ApplicationDbContext
- Tạo và chạy database migrations đầu tiên
- Seed dữ liệu mẫu (categories, products, admin user)
- Cấu hình relationships và foreign keys
- Thêm indexes và constraints

---

## 📊 TỔNG KẾT

**Hoàn thành**: 100%

- ✅ Project structure
- ✅ Docker & Database setup
- ✅ Git repository
- ✅ Documentation

**Công nghệ**: .NET Core 9.0, PostgreSQL 15, Docker, Git/GitHub

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

| Vấn đề                     | Giải pháp                                 |
| -------------------------- | ----------------------------------------- |
| Chưa rõ kiến trúc phân lớp | Nghiên cứu Layered Architecture pattern   |
| Docker configuration       | Tham khảo PostgreSQL Docker documentation |
| Git ignore files           | Sử dụng template .gitignore cho ASP.NET   |

---

## 📝 GHI CHÚ & KINH NGHIỆM

- Kiến trúc phân lớp giúp code dễ maintain và test
- Docker giúp đồng bộ môi trường phát triển
- .gitignore rất quan trọng để tránh commit các file không cần thiết
- README.md cần cập nhật thường xuyên theo tiến độ

---

## 📸 SCREENSHOTS

_Sẽ bổ sung trong các tuần tiếp theo khi có giao diện_

---

**Ngày báo cáo**: 16/11/2025  
**Người thực hiện**: Trần Thị Hằng
