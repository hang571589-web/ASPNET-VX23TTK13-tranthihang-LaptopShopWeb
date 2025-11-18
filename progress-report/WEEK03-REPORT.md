# BÁO CÁO TIẾN ĐỘ TUẦN 03

**Sinh viên**: Trần Thị Hằng  
**Lớp**: VX23TTK13  
**Thời gian**: Tuần 3 - Tháng 11/2025  
**Đồ án**: LaptopShopWeb - ASP.NET Core

---

## 📋 MỤC TIÊU TUẦN 03
- Implement Repository Pattern & Unit of Work
- Develop Business Logic Layer (BLL)
- Build Authentication System
- Create Customer-facing UI with Razor Pages
- Implement Shopping Cart & Checkout Flow

---

## ✅ CÔNG VIỆC ĐÃ HOÀN THÀNH

### 1. Data Access Layer (DAL) - Repository Pattern
- ✅ **Base Repository**: Generic repository với CRUD operations
  - `IRepository<T>` interface với methods: GetByIdAsync, GetAllAsync, FindAsync, AddAsync, Update, Delete, CountAsync, ExistsAsync, GetPagedAsync
  - `Repository<T>` implementation với Entity Framework Core
  
- ✅ **Specific Repositories**: 5 repositories chuyên biệt
  - `ProductRepository`: GetProductsByCategoryAsync, GetFeaturedProductsAsync, GetProductWithVariantsAsync, SearchProductsAsync, GetActiveProductsAsync
  - `CategoryRepository`: GetCategoryWithProductsAsync, GetActiveCategoriesAsync, GetCategoryBySlugAsync
  - `OrderRepository`: GetOrdersByUserIdAsync, GetOrderWithDetailsAsync, GenerateOrderNumberAsync, GetOrdersByStatusAsync
  - `UserRepository`: GetByEmailAsync, EmailExistsAsync, GetUsersByRoleAsync
  - `CartRepository`: GetCartByUserIdAsync, GetCartWithItemsAsync, ClearCartAsync, GetCartTotalAsync

- ✅ **Unit of Work Pattern**:
  - Transaction management (BeginTransaction, Commit, Rollback)
  - Centralized SaveChanges
  - Repository coordination

### 2. Business Logic Layer (BLL)
- ✅ **DTOs (Data Transfer Objects)**: 12 DTOs
  - ProductDto, CategoryDto, UserDto, OrderDto, OrderDetailDto
  - CartDto, CartItemDto, ReviewDto, ProductImageDto, ProductVariantDto
  - **CreateOrderDto**: UserId, ShippingAddress, City, PhoneNumber, Notes, PaymentMethod
  - **UpdateUserDto**: FullName, PhoneNumber, Address
  
- ✅ **Entity Mapper**: 
  - Bidirectional mapping (Entity ↔ DTO)
  - Extension methods cho clean code
  - Support cho nested objects (Product với Category, Variants, Reviews)

- ✅ **Service Layer**: 5 services hoàn chỉnh
  - **ProductService** (11 methods): GetAllProducts, GetActiveProducts, GetFeatured, GetByCategory, GetById, GetWithDetails, Search, Create, Update, Delete, UpdateStock
  - **CategoryService** (6 methods): GetAll, GetActive, GetById, Create, Update, Delete
  - **CartService** (9 methods): GetCartByUserId, GetCartWithDetails, AddToCart, UpdateCartItem, UpdateQuantity, RemoveFromCart (2 overloads), ClearCart, GetTotal
  - **OrderService** (9 methods): GetOrdersByUserId, GetOrderById, GetOrderWithDetails, GetByOrderNumber, CreateOrder (2 overloads), UpdateStatus, GetByStatus, GetRecentOrders
  - **UserService** (11 methods): GetById, GetByEmail, GetByRole, Register, Login, UpdateProfile, UpdateAsync, ChangePassword (2 overloads), EmailExists, UpdateRole, ToggleStatus

### 3. Entity Models Enhancement
- ✅ **Cart & CartItem Entities**:
  - One-to-One relationship: User ↔ Cart
  - One-to-Many: Cart ↔ CartItems
  - Support ProductVariant trong cart
  
- ✅ **ProductVariant Entity**:
  - CPU, RAM, Storage, GraphicsCard variations
  - Price, DiscountPrice, StockQuantity per variant
  - SKU tracking

- ✅ **Database Migration**:
  - Migration: `AddCartAndVariants`
  - Tables: Carts, CartItems, ProductVariants
  - Foreign key relationships configured

### 4. Authentication & Authorization
- ✅ **AuthHelper** - Centralized authentication manager:
  - Cookie-based authentication (7-day persistent)
  - 9 static methods: SignInAsync, SignOutAsync, GetUserId, GetUserEmail, GetUserName, GetName, GetUserRole, IsAuthenticated, IsInRole
  - Claims management: NameIdentifier, Email, Name, Role
  
- ✅ **Authorization Policies**:
  - `CustomerOnly`: Customers and Managers
  - `ManagerOnly`: Managers only
  - Role-based access control

- ✅ **Password Security**:
  - BCrypt hashing algorithm
  - Secure password verification

### 5. User Interface - Razor Pages
- ✅ **Layout & Theme**:
  - Modern red-black-white color scheme
  - Responsive Bootstrap 5 layout
  - Custom CSS với 400+ lines (gradients, animations, hover effects)
  - Font Awesome 6.4.0 icons
  - Navbar với conditional rendering based on authentication

- ✅ **Authentication Pages** (3 pages):
  - `/Login`: Email/password login với Remember Me
  - `/Register`: Full registration form với validation
  - `/Logout`: Sign out handler

- ✅ **Product Pages** (2 pages):
  - `/Products/Index`: Product listing với search, category filter, ratings
  - `/Products/Details`: Product details, variants selection, add to cart, reviews

- ✅ **Shopping Cart Flow** (2 pages):
  - `/Cart/Index`: Cart management (update quantity, remove items, clear cart)
  - `/Checkout/Index`: Checkout form với shipping info, order summary

- ✅ **Order Management** (3 pages):
  - `/Orders/Index`: Order history với status badges
  - `/Orders/Details`: Order details với shipping info, items
  - `/Orders/Success`: Order confirmation page

- ✅ **User Profile** (1 page):
  - `/Profile`: Update profile info, change password với BCrypt

- ✅ **Home Page**:
  - `/Index`: Hero section, featured products

**Tổng cộng: 11 customer-facing pages**

### 6. Seed Data
- ✅ **Location**: `LaptopShopWeb.DAL/ApplicationDbContext.cs` (SeedData method)
- ✅ **Manager Account**:
  - **Email**: `admin@laptopshop.com`
  - **Password**: Đã hash (cần reset với BCrypt khi chạy migration)
  - **Role**: Admin
  - **FullName**: Administrator
  - **Phone**: 0123456789
  
- ✅ **Categories**: 5 categories
  - Laptop Gaming, Laptop Văn Phòng, Laptop Đồ Họa, Laptop Mỏng Nhẹ, Laptop Cao Cấp
  
- ✅ **Sample Products**: 7 products
  - ASUS ROG Strix G15 (Gaming - 29,990,000đ)
  - Dell Inspiron 15 (Office - 15,990,000đ)
  - MacBook Pro 14 M3 (Premium - 49,990,000đ)
  - MSI Creator Z16 (Graphics - 45,990,000đ)
  - HP Pavilion Aero 13 (Lightweight - 17,990,000đ)
  - Lenovo Legion 5 Pro (Gaming - 35,990,000đ)
  - Acer Aspire 5 (Office - 12,990,000đ)

---

## 🔧 KỸ THUẬT VÀ CÔNG NGHỆ

### Architecture Pattern
- **Repository Pattern**: Abstraction layer cho data access
- **Unit of Work**: Transaction coordination
- **Service Layer**: Business logic separation
- **DTO Pattern**: Data transfer optimization

### Security
- **BCrypt**: Password hashing
- **Cookie Authentication**: Persistent sessions
- **Claims-based Authorization**: Role management
- **SQL Injection Protection**: Entity Framework parameterization

### UI/UX
- **Responsive Design**: Mobile-first approach
- **CSS Variables**: Consistent theming
- **Animations**: Smooth transitions and hover effects
- **Form Validation**: Client & server-side

---

## 📊 THỐNG KÊ CODE

### Backend Statistics
- **Entities**: 9 classes (User, Product, Category, Order, OrderDetail, Review, ProductImage, ProductVariant, Cart, CartItem)
- **Repositories**: 5 interfaces + 5 implementations + 1 generic base
- **Services**: 5 interfaces + 5 implementations
- **DTOs**: 12 classes
- **Helper Classes**: 2 (AuthHelper, EntityMapper)

### Frontend Statistics
- **Razor Pages**: 11 pages
- **CSS Files**: 1 custom.css (400+ lines)
- **Total Lines of Code**: ~60,000+ (including migrations)

### Database
- **Tables**: 9 main tables
- **Seed Data**: 1 admin user, 5 categories, 7 products
- **Migrations**: 2 migrations

---

## 🐛 VẤN ĐỀ ĐÃ GIẢI QUYẾT

### 1. Property Name Conflicts
**Issue**: `ProfileModel.User` và `CheckoutModel.User` conflict với `PageModel.User` (ClaimsPrincipal)

**Solution**: Renamed to `CurrentUser` property và updated all view references

### 2. Missing DTO Properties
**Issue**: UI pages expect properties không có trong DTOs (Items, TotalItems, VariantDisplayName, etc.)

**Solution**: Added alias properties và helper properties to DTOs:
- CartDto: Items → CartItems, TotalItems, TotalAmount
- OrderDto: Items → OrderDetails, CustomerName, City, PhoneNumber, TotalItems
- CartItemDto: VariantDisplayName, UnitPrice, TotalPrice
- OrderDetailDto: VariantDisplayName, TotalPrice

### 3. Service Method Overloads
**Issue**: Different pages needed different method signatures

**Solution**: Added method overloads:
- ICartService: UpdateCartItemQuantityAsync, RemoveFromCartAsync
- IUserService: GetByIdAsync (alias), UpdateAsync, ChangePasswordAsync (hashedPassword)
- IOrderService: GetOrderWithDetailsAsync (alias), CreateOrderAsync returning orderId

### 4. Missing Helper Methods
**Issue**: Layout cần AuthHelper.GetName() nhưng chỉ có GetUserName()

**Solution**: Added GetName() alias method pointing to GetUserName()

### 5. BCrypt Password Verification
**Issue**: Profile page cần verify old password nhưng UserDto không có PasswordHash

**Solution**: Added PasswordHash property to UserDto (for internal use only)

---

## 📈 TIẾN ĐỘ DỰ ÁN

### Hoàn thành
- ✅ Database Design & Migrations (100%)
- ✅ Entity Models (100%)
- ✅ Repository Pattern (100%)
- ✅ Business Logic Layer (100%)
- ✅ Authentication System (100%)
- ✅ Customer UI Pages (100%)
- ✅ Shopping Cart & Checkout (100%)

### Đang thực hiện
- 🔄 Manager Dashboard UI (0%)
- 🔄 Product Management CRUD (0%)
- 🔄 Order Management for Managers (0%)
- 🔄 User Management (0%)

### Kế hoạch tuần tới
- [ ] Manager Layout & Dashboard
- [ ] Product CRUD Pages (/Manager/Products)
- [ ] Category CRUD Pages (/Manager/Categories)
- [ ] Order Management Pages (/Manager/Orders)
- [ ] User Management Pages (/Manager/Users)
- [ ] Report & Statistics

---

## 🎯 BÀI HỌC KINH NGHIỆM

### Technical Lessons
1. **Property Naming**: Careful với inherited properties trong PageModel (User là ClaimsPrincipal)
2. **DTO Design**: Alias properties useful cho backward compatibility
3. **Method Overloading**: Multiple signatures hỗ trợ flexible API usage
4. **Password Security**: Never expose raw passwords, always hash before storage
5. **Transaction Management**: Unit of Work essential cho complex operations (checkout process)

### Development Process
1. **Incremental Building**: Build từng layer, test trước khi move on
2. **Error Handling**: Try-catch và meaningful error messages quan trọng
3. **Code Reusability**: Helper classes (AuthHelper, EntityMapper) save time
4. **Consistent Naming**: Follow conventions giúp code readable

---

## 📸 SCREENSHOTS (Optional)

### Home Page
![Home Page](../screenshots/week03-home.png)

### Product Listing
![Product Listing](../screenshots/week03-products.png)

### Shopping Cart
![Shopping Cart](../screenshots/week03-cart.png)

### Checkout
![Checkout](../screenshots/week03-checkout.png)

---

## 🔗 COMMIT HISTORY

### Major Commits (Recommended Structure)

```bash
# 1. Repository Pattern
git add src/LaptopShopWeb/LaptopShopWeb.DAL/Repositories/
git commit -m "feat(dal): implement repository pattern with 5 specific repos"

# 2. Unit of Work
git add src/LaptopShopWeb/LaptopShopWeb.DAL/UnitOfWork/
git commit -m "feat(dal): add unit of work pattern with transaction support"

# 3. DTOs
git add src/LaptopShopWeb/LaptopShopWeb.BLL/DTOs/
git commit -m "feat(bll): create 12 DTOs for data transfer"

# 4. Entity Mapper
git add src/LaptopShopWeb/LaptopShopWeb.BLL/Mappers/
git commit -m "feat(bll): implement entity mapper with extension methods"

# 5. Services
git add src/LaptopShopWeb/LaptopShopWeb.BLL/Services/
git commit -m "feat(bll): develop 5 service layers with business logic"

# 6. Cart & Variants Entities
git add src/LaptopShopWeb/LaptopShopWeb.Entity/
git add src/LaptopShopWeb/LaptopShopWeb.DAL/Migrations/
git commit -m "feat(entity): add cart, cart item, and product variant models"

# 7. Authentication
git add src/LaptopShopWeb/LaptopShopWeb/Helpers/AuthHelper.cs
git add src/LaptopShopWeb/LaptopShopWeb/Program.cs
git commit -m "feat(auth): implement cookie authentication with BCrypt"

# 8. Layout & Theme
git add src/LaptopShopWeb/LaptopShopWeb/Pages/Shared/
git add src/LaptopShopWeb/LaptopShopWeb/wwwroot/css/custom.css
git commit -m "feat(ui): create responsive layout with red-black-white theme"

# 9. Auth Pages
git add src/LaptopShopWeb/LaptopShopWeb/Pages/Login.*
git add src/LaptopShopWeb/LaptopShopWeb/Pages/Register.*
git add src/LaptopShopWeb/LaptopShopWeb/Pages/Logout.*
git commit -m "feat(ui): build login, register, and logout pages"

# 10. Product Pages
git add src/LaptopShopWeb/LaptopShopWeb/Pages/Products/
git commit -m "feat(ui): create product listing and details pages"

# 11. Shopping Cart
git add src/LaptopShopWeb/LaptopShopWeb/Pages/Cart/
git commit -m "feat(ui): implement shopping cart with update/remove"

# 12. Checkout
git add src/LaptopShopWeb/LaptopShopWeb/Pages/Checkout/
git commit -m "feat(ui): build checkout flow with order creation"

# 13. Order Management
git add src/LaptopShopWeb/LaptopShopWeb/Pages/Orders/
git commit -m "feat(ui): add order history and details pages"

# 14. User Profile
git add src/LaptopShopWeb/LaptopShopWeb/Pages/Profile.*
git commit -m "feat(ui): create user profile with password change"

# 15. Bug Fixes
git add .
git commit -m "fix(ui): resolve property conflicts and add missing DTO properties"

# 16. Final Build Success
git add .
git commit -m "build: fix all compilation errors, project builds successfully"
```

---

## 📝 GHI CHÚ

### Tài khoản test
- **Manager**: `admin@laptopshop.com` (password cần reset)
- **Customer**: Tạo mới qua Register page

### URLs quan trọng
- Home: `/`
- Products: `/Products/Index`
- Cart: `/Cart/Index`
- Checkout: `/Checkout/Index`
- Orders: `/Orders/Index`
- Profile: `/Profile`

### Database Connection
- Sử dụng PostgreSQL
- Connection string trong `appsettings.json`
- Run migrations: `dotnet ef database update`

---

**Kết luận**: Tuần 03 hoàn thành thành công toàn bộ Backend Architecture (Repository, Unit of Work, Services) và Customer-facing UI. Project build 100% successful với 0 errors. Ready cho Manager Dashboard implementation ở tuần 04.

**Người thực hiện**: Trần Thị Hằng  
**Ngày hoàn thành**: 18/11/2025
