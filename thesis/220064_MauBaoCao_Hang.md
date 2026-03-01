#  {#section .unnumbered}

**LỜI CẢM ƠN**

Sau thời gian nghiên cứu và triển khai đồ án \"LaptopShopWeb - Hệ thống
Thương mại Điện tử Laptop\", em xin bày tỏ lòng biết ơn sâu sắc đến
những người đã đồng hành và hỗ trợ em hoàn thành công trình này.

Đầu tiên, em xin gửi lời cảm ơn chân thành đến TS. Đoàn Phước Miền -
người thầy đã tận tâm hướng dẫn, dành thời gian góp ý và định hướng em
từ những bước đầu tiên. Những kiến thức Thầy truyền đạt về kiến trúc
phân lớp, các nguyên tắc thiết kế phần mềm và phương pháp tiếp cận bài
toán thực tế đã giúp em xây dựng được một hệ thống vừa đáp ứng yêu cầu
học thuật, vừa hướng đến khả năng ứng dụng thực tiễn.

Em xin cảm ơn quý Thầy Cô trong Khoa Công nghệ Thông tin - Trường Đại
học Trà Vinh đã trang bị cho em nền tảng kiến thức vững chắc trong suốt
quá trình học tập. Những môn học về phát triển ứng dụng web, quản trị cơ
sở dữ liệu, và phân tích thiết kế hệ thống đã trở thành hành trang quan
trọng để em tự tin thực hiện đồ án này.

Em xin gửi lời tri ân đến gia đình, những người luôn tin tưởng, động
viên và tạo mọi điều kiện thuận lợi nhất để em có thể tập trung hoàn
thành chương trình học. Sự ủng hộ tinh thần của gia đình là nguồn động
lực lớn lao giúp em vượt qua những khó khăn trong quá trình nghiên cứu.

Em cũng xin cảm ơn các bạn bè đã nhiệt tình tham gia kiểm thử hệ thống,
đóng góp ý kiến về giao diện và trải nghiệm người dùng. Những phản hồi
của các bạn đã giúp em nhận ra và khắc phục nhiều vấn đề, từ đó hoàn
thiện sản phẩm tốt hơn.

Đồ án này không chỉ là kết quả của quá trình học tập mà còn là hành
trình em khám phá và ứng dụng công nghệ ASP.NET Core, Entity Framework
Core, và các pattern thiết kế vào giải quyết bài toán thực tế. Em hy
vọng rằng sản phẩm này sẽ góp phần nhỏ bé vào việc số hóa hoạt động kinh
doanh laptop, đồng thời là tài liệu tham khảo hữu ích cho các bạn sinh
viên có cùng định hướng nghiên cứu.

Một lần nữa, em xin chân thành cảm ơn!

**\
MỤC LỤC**

CHƯƠNG 1 : NGHIÊN CỨU LÝ THUYẾT [6](#chương-1-nghiên-cứu-lý-thuyết)

1\. Nền tảng ASP.NET Core [6](#nền-tảng-asp.net-core)

2\. Entity Framwork Core [7](#entity-framwork-core)

**3. SQL Server Database** [7](#_Toc216420413)

**3.1 Tổng quan** [7](#_Toc216420414)

**3.2 SQL Server vs PostgreSQL vs MySQL:** [8](#_Toc216420415)

4\. Design pattern và kiến trúc [9](#design-pattern-và-kiến-trúc)

5\. Repository Pattern [11](#repository-pattern)

6\. Unit of Work [12](#unit-of-work-1)

7\. Bảo mật Cơ bản trong Ứng dụng Web
[12](#bảo-mật-cơ-bản-trong-ứng-dụng-web)

**8.** **Docker** [12](#_Toc216420420)

CHƯƠNG 2: HIỆN THỰC HOÁ NGHIÊN CỨU [14](#_Toc216440804)

1\. Phân tích bài toán [14](#phân-tích-bài-toán)

2\. Phân tích yêu cầu [14](#phân-tích-yêu-cầu)

3\. Thiết kế cơ sở dữ liệu [15](#thiết-kế-cơ-sở-dữ-liệu)

**4.** **Bảo mật và xác thực** [16](#_Toc216420425)

**5.** **Chiến lược kiểm thử** [17](#_Toc216420426)

**6.** **Triển khai và môi trường** [17](#_Toc216420427)

CHƯƠNG 3: KẾT QUẢ NGHIÊN CỨU [19](#chương-3-kết-quả-nghiên-cứu)

1\. Chức năng dành cho khách hàng [19](#chức-năng-dành-cho-khách-hàng)

2\. Chức năng quản trị [37](#chức-năng-quản-trị)

2.1 Chức năng quản lí sản phẩm [37](#chức-năng-quản-lí-sản-phẩm)

2.2 Chức năng quản lý danh mục [39](#chức-năng-quản-lý-danh-mục)

2.3 Chức năng quản lý đơn hàng [40](#chức-năng-quản-lý-đơn-hàng)

2.4 Chức năng dashboard [42](#chức-năng-dashboard)

3\. Kết quả đạt được [43](#kết-quả-đạt-được)

3.1 Đánh giá chất lượng hệ thống [43](#đánh-giá-chất-lượng-hệ-thống)

3.2 Giải quyết bài toán ban đầu [44](#giải-quyết-bài-toán-ban-đầu)

CHƯƠNG 4: KẾT LUẬN [46](#chương-4-kết-luận)

1\. Kết luận [46](#kết-luận)

2\. Hướng phát triển [47](#hướng-phát-triển)

2.1 Ngắn hạn (1-3 tháng) [47](#ngắn-hạn-1-3-tháng)

2.2 Trung hạn (3-6 tháng) [47](#trung-hạn-3-6-tháng)

2.3 Dài hạn (6-12 tháng) [47](#dài-hạn-6-12-tháng)

2.4 Mở rộng scalability [48](#mở-rộng-scalability)

2.5 Scalability improvements [48](#scalability-improvements)

3\. Lời kết [49](#lời-kết)

**\
DANH MỤC HÌNH ẢNH**

Hình 3. 1 - Form đăng ký rỗng với validation rules hiển thị
[19](#_Toc216441376)

Hình 3. 2 - Form đăng ký với validation errors (password không khớp,
email sai format) [20](#_Toc216441377)

Hình 3. 3 - Thông báo lỗi email đã tồn tại [21](#_Toc216441378)

Hình 3. 4 - Trang chủ sau đăng ký thành công với user menu hiển thị tên
[22](#_Toc216441379)

Hình 3. 5 - Form đăng nhập với returnUrl parameter [23](#_Toc216441380)

Hình 3. 6 - Form đăng nhập với error message \"Email hoặc mật khẩu không
đúng\" [24](#_Toc216441381)

Hình 3. 7 - Navbar sau đăng nhập với user dropdown menu
[25](#_Toc216441382)

Hình 3. 8 - Trang Products với grid layout 4 cột và product cards
[26](#_Toc216441383)

Hình 3. 9 - Products page với filters applied và results count
[27](#_Toc216441384)

Hình 3. 10 - Search results cho keyword \"core i3\" [27](#_Toc216441385)

Hình 3. 11 - Product details page với image gallery và specifications
table [29](#_Toc216441386)

Hình 3. 12 - Toast notification \"Đã thêm vào giỏ hàng\" và cart icon
badge showing number [30](#_Toc216441387)

Hình 3. 13 - Cart page với 2-3 items [31](#_Toc216441388)

Hình 3. 14 - Quantity update với real-time total calculation
[32](#_Toc216441389)

Hình 3. 15 - Confirmation modal \"Xóa sản phẩm\" [33](#_Toc216441390)

Hình 3. 16 - Empty cart state với CTA button [33](#_Toc216441391)

Hình 3. 17 - Checkout page với form và order summary
[34](#_Toc216441392)

Hình 3. 18 - Order confirmation với all order details
[35](#_Toc216441393)

Hình 3. 19 - Orders list page với multiple orders và status badges
[36](#_Toc216441394)

Hình 3. 20 - Order details page với full information
[36](#_Toc216441395)

Hình 3. 21 - Admin Products list với table và filters
[37](#_Toc216441396)

Hình 3. 22 - Create Product form với tất cả fields [38](#_Toc216441397)

Hình 3. 23 - Edit Product form với data pre-filled [38](#_Toc216441398)

Hình 3. 24 - Delete confirmation modal [39](#_Toc216441399)

Hình 3. 25 - Admin Categories list [40](#_Toc216441400)

Hình 3. 26 - Admin Orders list với filters [41](#_Toc216441401)

Hình 3. 27 - Update order status modal [42](#_Toc216441402)

Hình 3. 28 - Dashboard summary cards [43](#_Toc216441403)

**\
TÓM TẮT ĐỒ ÁN**

Đồ án \"LaptopShopWeb - Hệ thống Thương mại Điện tử Laptop\" được phát
triển nhằm đáp ứng nhu cầu số hóa hoạt động kinh doanh laptop trong bối
cảnh thương mại điện tử phát triển mạnh mẽ tại Việt Nam. Hệ thống hướng
đến mục tiêu xây dựng một nền tảng web hoàn chỉnh, thay thế quy trình
quản lý thủ công bằng giải pháp tự động hóa, giúp cửa hàng laptop quy mô
vừa và nhỏ nâng cao hiệu quả vận hành, giảm thiểu sai sót trong quản lý
sản phẩm và đơn hàng, đồng thời mang đến trải nghiệm mua sắm trực tuyến
tiện lợi cho khách hàng.

Về mặt công nghệ, hệ thống được xây dựng trên nền tảng ASP.NET Core 9.0
với kiến trúc Razor Pages, kết hợp Entity Framework Core 9.0 làm công cụ
ORM và SQL Server làm hệ quản trị cơ sở dữ liệu. Kiến trúc phân lớp ba
tầng (Presentation Layer - Business Logic Layer - Data Access Layer)
được áp dụng nhằm đảm bảo sự phân tách rõ ràng giữa các thành phần, tăng
khả năng bảo trì và mở rộng. Các design patterns quan trọng như
Repository Pattern, Unit of Work (thông qua DbContext) và Dependency
Injection được triển khai một cách nhất quán, giúp giảm độ kết dính giữa
các module và hỗ trợ kiểm thử tự động. Docker và Docker Compose được sử
dụng để container hóa ứng dụng, đảm bảo tính nhất quán môi trường phát
triển và triển khai.

Về chức năng, hệ thống cung cấp hai khu vực chính: Front-office phục vụ
khách hàng với các tính năng duyệt sản phẩm, tìm kiếm theo nhiều tiêu
chí (thương hiệu, giá, cấu hình), xem chi tiết thông số kỹ thuật laptop
(CPU, RAM, ổ cứng, card đồ họa), quản lý giỏ hàng và đặt hàng trực
tuyến; Back-office dành cho quản trị viên và nhân viên với đầy đủ chức
năng CRUD cho sản phẩm, danh mục, đơn hàng và người dùng, cùng với
dashboard thống kê cơ bản về doanh thu và hoạt động kinh doanh. Hệ thống
phân quyền ba cấp độ (Customer, Staff, Admin) được triển khai với cơ chế
xác thực dựa trên Cookie Authentication và mã hóa mật khẩu BCrypt, đảm
bảo bảo mật thông tin người dùng. Dữ liệu demo được seed tự động thông
qua EF Core Migrations, hỗ trợ quá trình kiểm thử và demo hệ thống.

Kết quả đạt được cho thấy hệ thống hoạt động ổn định với đầy đủ các chức
năng cốt lõi của một nền tảng thương mại điện tử. Các module chính như
quản lý sản phẩm, giỏ hàng, đơn hàng, và phân quyền người dùng đều được
triển khai hoàn chỉnh và kiểm thử kỹ lưỡng. Giao diện người dùng được
xây dựng responsive với Bootstrap 5, đảm bảo trải nghiệm tốt trên nhiều
thiết bị. Database được thiết kế chuẩn hóa, hỗ trợ tốt các quan hệ phức
tạp giữa các entity như Product, Category, Order, User và Cart. Việc áp
dụng HTTPS cho production environment và container hóa bằng Docker giúp
hệ thống sẵn sàng cho triển khai thực tế.

Ý nghĩa của đồ án thể hiện ở cả khía cạnh học thuật và thực tiễn. Về mặt
học thuật, đồ án cung cấp một case study điển hình về việc áp dụng kiến
trúc phân lớp và các design patterns trong phát triển ứng dụng web với
.NET Core, có thể làm tài liệu tham khảo cho sinh viên và developer. Về
mặt thực tiễn, hệ thống giải quyết bài toán thực tế của các cửa hàng
laptop quy mô nhỏ trong việc số hóa hoạt động kinh doanh, có thể được mở
rộng và tùy chỉnh để đưa vào sử dụng chính thức. Đồ án cũng minh chứng
cho khả năng tích hợp các công nghệ hiện đại như Docker, Entity
Framework Core, và Cookie Authentication vào một giải pháp tổng thể,
đồng thời hệ thống hóa quy trình phát triển phần mềm từ phân tích đến
triển khai.

**MỞ ĐẦU**

**1.1 Lý do chọn đề tài**

Nhiều cửa hàng kinh doanh laptop quy mô vừa và nhỏ vẫn duy trì phương
thức quản lý truyền thống thông qua sổ sách, bảng tính Excel hoặc các hệ
thống đơn giản không đồng bộ. Thực trạng này dẫn đến nhiều vấn đề như:
thông tin sản phẩm không nhất quán giữa các kênh bán hàng, khó kiểm soát
tồn kho, xử lý đơn hàng thủ công tốn thời gian, và thiếu dữ liệu để phân
tích hành vi khách hàng. Đặc biệt, việc quản lý sản phẩm laptop với
nhiều cấu hình khác nhau (CPU, RAM, ổ cứng, card đồ họa) càng làm phức
tạp thêm quy trình vận hành.

Nhận thấy nhu cầu thực tế này, em quyết định chọn đề tài
\"LaptopShopWeb - Hệ thống Thương mại Điện tử Laptop\" với mục đích xây
dựng một nền tảng web tích hợp đầy đủ các chức năng cần thiết cho cả
khách hàng lẫn người quản trị. Hệ thống sử dụng công nghệ ASP.NET Core
Razor Pages kết hợp Entity Framework Core và SQL Server, áp dụng kiến
trúc phân lớp rõ ràng (Presentation - Business Logic - Data Access) nhằm
đảm bảo tính dễ bảo trì và khả năng mở rộng trong tương lai.

Việc lựa chọn công nghệ .NET không chỉ dựa trên tính phổ biến và cộng
đồng hỗ trợ mạnh mẽ, mà còn vì khả năng tích hợp tốt với các dịch vụ
cloud, bảo mật ở cấp độ framework và hiệu năng xử lý cao. Đồng thời, đề
tài cũng tạo cơ hội để em áp dụng các kiến thức đã học về phân tích
thiết kế hệ thống, quản trị cơ sở dữ liệu, và các design patterns vào
giải quyết bài toán thực tiễn.

**1.2 Mục đích nghiên cứu**

Mục tiêu tổng quát của đồ án là xây dựng một hệ thống thương mại điện tử
hoàn chỉnh cho lĩnh vực kinh doanh laptop, đáp ứng nhu cầu của cả khách
hàng và người quản lý cửa hàng. Cụ thể, đồ án hướng đến các mục tiêu
sau:

Về chức năng:

\- Xây dựng giao diện người dùng thân thiện cho phép khách hàng duyệt
sản phẩm, tìm kiếm theo nhiều tiêu chí (thương hiệu, giá, cấu hình), xem
chi tiết thông số kỹ thuật, quản lý giỏ hàng và đặt hàng trực tuyến.

\- Phát triển hệ thống quản trị đa cấp với phân quyền rõ ràng (Admin,
Staff, Customer), cho phép quản lý sản phẩm, danh mục, đơn hàng, và tài
khoản người dùng một cách hiệu quả.

\- Triển khai cơ chế xác thực và phân quyền bảo mật, bảo vệ thông tin cá
nhân và dữ liệu giao dịch của người dùng.

**1.2.1 Về kỹ thuật:**

\- Áp dụng kiến trúc phân lớp (3-tier architecture) với sự phân tách rõ
ràng giữa Presentation Layer, Business Logic Layer và Data Access Layer,
giúp code dễ bảo trì và mở rộng.

\- Sử dụng Repository Pattern và Unit of Work Pattern để tách biệt logic
truy cập dữ liệu khỏi business logic, tăng khả năng kiểm thử và tái sử
dụng code.

\- Thiết kế cơ sở dữ liệu chuẩn hóa với Entity Framework Core, đảm bảo
tính toàn vẹn dữ liệu và hỗ trợ migration để dễ dàng cập nhật schema.

2.  **Về đánh giá:**

\- Kiểm thử hệ thống ở các mức độ: unit test cho business logic,
integration test cho data access, và functional test cho các chức năng
end-to-end.

\- Đo lường hiệu năng hệ thống trong các tình huống tải khác nhau để đảm
bảo thời gian phản hồi chấp nhận được.

\- Đánh giá khả năng bảo mật cơ bản của hệ thống thông qua việc kiểm tra
các lỗ hổng phổ biến (SQL Injection, XSS, CSRF).

**1.3 Đối tượng nghiên cứu**

**1.3.1 Đối tượng nghiên cứu:**

Là hệ thống phần mềm thương mại điện tử cho lĩnh vực kinh doanh laptop,
bao gồm hai phần chính:

\- Front-office (Khách hàng): Giao diện dành cho người mua sắm, cho phép
tìm kiếm sản phẩm, xem thông tin chi tiết, quản lý giỏ hàng, đặt hàng và
theo dõi lịch sử mua hàng.

\- Back-office (Quản trị): Giao diện quản lý dành cho nhân viên và quản
trị viên, hỗ trợ các chức năng CRUD (Create, Read, Update, Delete) cho
sản phẩm, danh mục, đơn hàng và người dùng, cùng với các báo cáo thống
kê cơ bản.

**1.3.2 Phạm vi nghiên cứu:**

Các chức năng được triển khai:

\- Quản lý sản phẩm laptop với thông tin chi tiết (thương hiệu, CPU,
RAM, ổ cứng, card đồ họa, giá, hình ảnh).

\- Quản lý danh mục sản phẩm (Laptop Gaming, Laptop Văn phòng, Laptop Đồ
họa, v.v.).

\- Hệ thống giỏ hàng với khả năng cập nhật số lượng và xóa sản phẩm.

\- Quy trình đặt hàng hoàn chỉnh từ checkout đến xác nhận đơn hàng.

\- Phân quyền người dùng theo ba vai trò: Customer (khách hàng), Staff
(nhân viên), Admin (quản trị viên).

\- Xác thực người dùng bằng Cookie Authentication với mã hóa mật khẩu
BCrypt.

\- Dashboard thống kê cơ bản về doanh thu, đơn hàng, sản phẩm.

Các chức năng chưa triển khai (để dành cho hướng phát triển):

\- Tích hợp cổng thanh toán trực tuyến (VNPay, MoMo, ZaloPay).

> \- Hệ thống đánh giá và bình luận sản phẩm.
>
> \- Tính năng so sánh sản phẩm.
>
> \- Khuyến mãi và mã giảm giá.
>
> \- Quản lý tồn kho tự động với cảnh báo.
>
> \- Chatbot hoặc live chat hỗ trợ khách hàng.
>
> \- Ứng dụng mobile (iOS/Android).
>
> \- RESTful API cho tích hợp bên thứ ba.

**1.4 Phương pháp nghiên cứu**

Đồ án được thực hiện theo quy trình phát triển phần mềm lặp (Iterative
Development) kết hợp các nguyên tắc của Agile, chia thành các giai đoạn
ngắn hạn với mục tiêu cụ thể:

Giai đoạn 1: Phân tích yêu cầu

> \- Thu thập và phân tích yêu cầu chức năng từ thực tế kinh doanh
> laptop.
>
> \- Xác định các actor (khách hàng, nhân viên, admin) và use cases
> chính.
>
> \- Liệt kê các yêu cầu phi chức năng (hiệu năng, bảo mật, khả năng mở
> rộng).

Giai đoạn 2: Thiết kế hệ thống

> \- Thiết kế kiến trúc tổng thể theo mô hình 3-tier (Presentation -
> BLL - DAL).
>
> \- Thiết kế cơ sở dữ liệu: xác định các entity, mối quan hệ và ràng
> buộc.
>
> \- Vẽ sơ đồ ER Diagram và Database Schema.
>
> \- Thiết kế luồng xử lý nghiệp vụ (workflow) cho các chức năng chính.

Giai đoạn 3: Triển khai

> \- Cài đặt môi trường phát triển (.NET SDK, SQL Server, Docker).
>
> \- Triển khai lớp Data Access Layer với Entity Framework Core.
>
> \- Xây dựng Business Logic Layer với các Services và DTOs.
>
> \- Phát triển Presentation Layer với Razor Pages và Bootstrap.
>
> \- Tích hợp xác thực và phân quyền.

Giai đoạn 4: Kiểm thử

> \- Kiểm thử chức năng (Functional Testing): kiểm tra từng use case.
>
> \- Kiểm thử tích hợp (Integration Testing): kiểm tra tương tác giữa
> các layer.
>
> \- Kiểm thử bảo mật cơ bản: SQL Injection, XSS, CSRF.
>
> \- Kiểm thử hiệu năng: đo thời gian phản hồi và khả năng xử lý đồng
> thời.

Giai đoạn 5: Tài liệu hóa và triển khai

> \- Viết tài liệu hướng dẫn sử dụng cho end-user.
>
> \- Viết tài liệu kỹ thuật cho developer.
>
> \- Chuẩn bị môi trường production với Docker Compose.
>
> \- Triển khai và cấu hình HTTPS.

Công cụ và công nghệ sử dụng:

> \- Ngôn ngữ lập trình: C# (.NET 9.0)
>
> \- Framework: ASP.NET Core Razor Pages
>
> \- ORM: Entity Framework Core
>
> \- Database: SQL Server
>
> \- Container: Docker & Docker Compose
>
> \- Version Control: Git & GitHub
>
> \- IDE: Visual Studio Code / Rider
>
> \- Testing: xUnit (dự kiến)

**1.5 Ý nghĩa đề tài:**

**1.5.1 Ý nghĩa học thuật:**

Đồ án cung cấp một case study cụ thể về việc áp dụng các nguyên lý thiết
kế phần mềm và design patterns vào xây dựng hệ thống thương mại điện tử.
Việc sử dụng kiến trúc phân lớp kết hợp Repository Pattern và Unit of
Work giúp minh họa rõ ràng cách tổ chức code để đạt được các mục tiêu:
tách biệt concerns, tăng khả năng kiểm thử, và dễ dàng bảo trì. Đồng
thời, đề tài cũng so sánh ưu nhược điểm của Razor Pages so với MVC trong
bối cảnh xây dựng ứng dụng web có cấu trúc rõ ràng.

Về mặt cơ sở dữ liệu, đề tài thể hiện quy trình thiết kế từ mô hình thực
thể quan hệ (ER Model) đến schema vật lý, áp dụng các chuẩn hóa
(normalization) để đảm bảo tính toàn vẹn dữ liệu. Việc sử dụng EF Core
Migrations cũng minh họa cách quản lý phiên bản schema một cách chuyên
nghiệp.

**1.5.2 Ý nghĩa thực tiễn:**

Về góc độ kinh doanh, hệ thống giúp số hóa quy trình bán hàng laptop,
giảm thiểu sai sót trong quản lý thông tin sản phẩm và đơn hàng. Việc có
một nền tảng tập trung cho phép chủ cửa hàng dễ dàng cập nhật giá, theo
dõi tồn kho, và phân tích dữ liệu bán hàng để đưa ra quyết định kinh
doanh.

Đối với khách hàng, hệ thống mang lại trải nghiệm mua sắm trực tuyến
tiện lợi với khả năng tìm kiếm, so sánh thông số kỹ thuật và đặt hàng
nhanh chóng. Thông tin sản phẩm được hiển thị đầy đủ và nhất quán, giúp
khách hàng đưa ra quyết định mua sắm sáng suốt.

**1.5.3 Giá trị tham khảo:**

Đồ án có thể được sử dụng làm tài liệu tham khảo cho các sinh viên khác
có nhu cầu nghiên cứu về phát triển ứng dụng web với .NET Core, đặc biệt
là trong lĩnh vực thương mại điện tử. Source code được tổ chức theo best
practices, có thể làm mẫu cho các dự án tương tự hoặc làm nền tảng để
phát triển thêm các tính năng nâng cao.

Hơn nữa, đồ án cung cấp một workflow hoàn chỉnh từ phân tích, thiết kế,
triển khai đến kiểm thử và triển khai production, giúp người học hiểu rõ
quy trình phát triển phần mềm chuyên nghiệp trong thực tế.

#  {#section-1 .unnumbered}

#  CHƯƠNG 1 : NGHIÊN CỨU LÝ THUYẾT {#chương-1-nghiên-cứu-lý-thuyết .unnumbered}

Chương này trình bày các kiến thức nền tảng về công nghệ, kiến trúc phần
mềm và các design patterns được áp dụng trong việc xây dựng hệ thống
LaptopShopWeb. Nội dung tập trung vào việc phân tích và lựa chọn công
nghệ phù hợp, so sánh các giải pháp thay thế, và giải thích lý do áp
dụng các patterns cụ thể trong bối cảnh dự án.

## Nền tảng ASP.NET Core

ASP.NET Core là framework mã nguồn mở, đa nền tảng để xây dựng ứng dụng
web hiện đại và dịch vụ cloud. Được phát triển bởi Microsoft, ASP.NET
Core là phiên bản tái thiết kế hoàn toàn của ASP.NET Framework truyền
thống, tập trung vào hiệu năng cao, khả năng mở rộng và tính module hóa
\[1\].

Các đặc điểm nổi bật:

\- Cross-platform: Chạy trên Windows, macOS và Linux, cho phép phát
triển và triển khai linh hoạt trên nhiều môi trường.

\- High Performance: Được tối ưu hóa để đạt hiệu năng cao, thường đứng
trong top các framework web nhanh nhất theo TechEmpower Benchmark \[2\].

\- Modular: Kiến trúc middleware pipeline cho phép thêm/bỏ các thành
phần dễ dàng, giảm kích thước ứng dụng.

\- Dependency Injection: Hỗ trợ DI tích hợp sẵn, khuyến khích loose
coupling và testability.

\- Unified programming model: Cung cấp nhiều mô hình phát triển (MVC,
Razor Pages, Web API, Blazor) trong một framework thống nhất.

Lý do chọn Razor Pages cho dự án:

Dự án LaptopShopWeb có đặc điểm là ứng dụng web page-centric với các
trang rõ ràng (trang chủ, danh sách sản phẩm, chi tiết sản phẩm, giỏ
hàng, checkout, admin CRUD). Mỗi trang có logic xử lý tương đối độc lập,
không yêu cầu sharing logic phức tạp giữa nhiều views. Razor Pages giúp
giảm boilerplate code, routing tự động theo cấu trúc thư mục, và dễ dàng
cho developer mới làm quen \[3\].

![](./image1.png)

## Entity Framwork Core

> **Giới thiệu EF Core:**

Entity Framework Core là ORM (Object-Relational Mapper) hiện đại, nhẹ và
mở rộng được cho .NET. EF Core cho phép developer làm việc với database
thông qua các đối tượng .NET, tự động sinh SQL queries và theo dõi thay
đổi của entities \[5\].

Workflow của EF Core:

> 1\. Define Models: Tạo các POCO classes (Product, User, Order, etc.)
>
> 2\. Configure Relationships: Sử dụng Fluent API hoặc Data Annotations
>
> 3\. Create Migration: \`dotnet ef migrations add InitialCreate\`
>
> 4\. Update Database: \`dotnet ef database update\`
>
> 5\. Query Data: Sử dụng LINQ to Entities
>
> 6\. Track Changes: EF Core theo dõi modifications
>
> 7\. Save Changes: \`SaveChanges()\` generates SQL UPDATE/INSERT/DELETE

Lý do chọn Code First:

Dự án bắt đầu từ đầu, chưa có database sẵn. Code First cho phép thiết kế
model dựa trên business logic, sau đó generate database schema.
Migrations giúp quản lý phiên bản database dễ dàng, đặc biệt khi làm
việc nhóm với Git \[6\].

[]{#_Toc216420413 .anchor}**3. SQL Server Database**

> []{#_Toc216420414 .anchor}**3.1 Tổng quan**

SQL Server là hệ quản trị cơ sở dữ liệu quan hệ do Microsoft phát triển,
tuân thủ ACID, với hơn 30 năm phát triển. SQL Server nổi tiếng với độ tin
cậy cao, tích hợp chặt chẽ với hệ sinh thái .NET và khả năng mở rộng
tốt cho các ứng dụng doanh nghiệp \[7\].

Đặc điểm nổi bật:

> \- ACID Compliance: Đảm bảo tính toàn vẹn dữ liệu
>
> \- Tích hợp .NET: Hỗ trợ CLR, tích hợp tốt nhất với Entity Framework Core
>
> \- Advanced Security: Transparent Data Encryption, Row-Level Security, Always Encrypted
>
> \- Full Text Search: Built-in FTS với support cho nhiều ngôn ngữ
>
> \- Business Intelligence: Tích hợp SSRS, SSAS, SSIS cho phân tích dữ liệu
>
> \- Performance: Indexes đa dạng (Clustered, Non-clustered, Columnstore, Full-text)
>
> []{#_Toc216420415 .anchor}**3.2 SQL Server vs PostgreSQL vs MySQL:**

  ---------------------------------------------------------------------------
  **Tiêu chí**         **SQL Server**     **PostgreSQL**      **MySQL**
  -------------------- ------------------ ------------------- ---------------
  **License**          Commercial (Express Open Source (MIT)  Open Source
                       /Developer free)                       (GPL)

  **Cross-platform**   Có (Win, Linux,    Có (Win, Linux,     Có (Win, Linux,
                       Mac via Docker)    Mac)                Mac)

  **.NET Integration** Tốt nhất (native   Tốt (Npgsql        Tốt
                       provider)          provider)           (MySqlConnector)

  **Full Text Search** Built-in,          Built-in, powerful  Limited
                       enterprise

  **Window Functions** Extensive          Extensive           Basic (from
                                                              8.0)

  **Enterprise         Excellent (HA,     Good                Limited
  Features**           clustering)        (extensions)

  **Replication**      Always On, Log     Streaming, logical  Master-slave
                       Shipping

  **Cost               Free (Developer/   Free                Free
  (Development)**      Express)                               (Community)
  ---------------------------------------------------------------------------

**Lý do chọn SQL Server:**

1.  **Tích hợp .NET:** SQL Server là lựa chọn tự nhiên nhất cho ứng dụng ASP.NET Core, với native provider được Microsoft phát triển và hỗ trợ tối ưu
2.  **Docker Support:** Image chính thức từ Microsoft, dễ containerize trên cả Linux và macOS
3.  **Developer Edition:** Miễn phí cho phát triển và testing với đầy đủ tính năng Enterprise
4.  **Entity Framework Core:** EF Core được thiết kế và tối ưu cho SQL Server trước tiên, đảm bảo compatibility tốt nhất
5.  **Tooling:** SQL Server Management Studio (SSMS), Azure Data Studio cung cấp công cụ quản lý mạnh mẽ \[8\]

## Design pattern và kiến trúc

Kiến trúc phân lớp (Layered Architecture) là một trong những
architectural patterns phổ biến nhất trong phát triển phần mềm, đặc biệt
là cho các ứng dụng doanh nghiệp. Kiến trúc này tổ chức hệ thống thành
các tầng (layers) nằm chồng lên nhau, mỗi tầng có một trách nhiệm cụ thể
và chỉ tương tác với tầng liền kề. Trong dự án LaptopShopWeb, kiến trúc
3-tier được áp dụng với ba tầng chính: Presentation Layer, Business
Logic Layer và Data Access Layer.

> ![](./image2.png)

Presentation Layer (Lớp Giao diện) là tầng cao nhất trong kiến trúc,
đóng vai trò giao tiếp trực tiếp với người dùng cuối. Trong dự án, tầng
này được hiện thực bằng ASP.NET Core Razor Pages, bao gồm các PageModels
(chứa logic xử lý request/response), Views (hiển thị giao diện HTML), và
Forms (thu thập input từ người dùng). Presentation Layer chịu trách
nhiệm về validation đầu vào phía client (client-side validation), hiển
thị dữ liệu một cách thân thiện, và điều hướng giữa các trang. Tầng này
không chứa business logic phức tạp hay trực tiếp truy cập database, mà
chỉ gọi các services từ tầng Business Logic bên dưới để xử lý yêu cầu.
Ví dụ, khi người dùng xem danh sách sản phẩm, PageModel sẽ gọi
\`IProductService.GetProductsAsync()\` để lấy dữ liệu, sau đó truyền
sang View để render.

Business Logic Layer (Lớp Nghiệp vụ) nằm ở tầng giữa, đóng vai trò cốt
lõi của hệ thống bằng cách xử lý toàn bộ business logic và quy tắc
nghiệp vụ. Tầng này bao gồm các Services như ProductService,
OrderService, CartService, UserService, mỗi service đảm nhiệm một nhóm
chức năng cụ thể. Business Logic Layer cũng định nghĩa các Data Transfer
Objects (DTOs) để truyền dữ liệu giữa các tầng mà không expose trực tiếp
entities từ database. Các Mappers được sử dụng để chuyển đổi giữa
Entities (từ DAL) và DTOs (dùng trong BLL và Presentation). Tầng này
thực hiện validation nghiệp vụ phức tạp (business rules validation),
tính toán giá, kiểm tra tồn kho, xác thực quyền hạn, và điều phối các
thao tác trên nhiều entities. Ví dụ, khi tạo đơn hàng, OrderService sẽ
kiểm tra giỏ hàng không rỗng, tính tổng giá, kiểm tra tồn kho, và gọi
repository để lưu đơn hàng vào database.

Data Access Layer (Lớp Truy cập Dữ liệu) là tầng thấp nhất, chịu trách
nhiệm tương tác trực tiếp với cơ sở dữ liệu SQL Server. Tầng này bao gồm
Repositories (triển khai các phương thức CRUD cơ bản như GetById,
GetAll, Add, Update, Delete), DbContext của Entity Framework Core (quản
lý kết nối database và change tracking), Entity Configurations (cấu hình
mapping giữa C# classes và database tables thông qua Fluent API), và
Migrations (quản lý phiên bản schema database). Data Access Layer trừu
tượng hóa các chi tiết về cách dữ liệu được lưu trữ và truy xuất, che
giấu SQL queries khỏi các tầng trên. Business Logic Layer chỉ cần gọi
các phương thức repository như \`productRepository.GetByIdAsync(id)\` mà
không cần biết câu SQL thực tế được generate như thế nào. Điều này giúp
dễ dàng thay đổi database provider (ví dụ từ SQL Server sang PostgreSQL chẳng
hạn) mà không ảnh hưởng đến business logic.

Ưu điểm của kiến trúc phân lớp rất rõ ràng trong việc tổ chức code. Thứ
nhất, Separation of Concerns (tách biệt mối quan tâm) được đảm bảo khi
mỗi layer chỉ tập trung vào một trách nhiệm cụ thể: Presentation lo về
UI/UX, Business Logic lo về quy tắc nghiệp vụ, Data Access lo về
persistence. Thứ hai, Maintainability (khả năng bảo trì) được cải thiện
đáng kể vì thay đổi ở một layer ít ảnh hưởng đến các layer khác. Ví dụ,
đổi từ Razor Pages sang MVC chỉ cần sửa Presentation Layer mà Business
Logic và Data Access giữ nguyên. Thứ ba, Testability (khả năng kiểm thử)
tăng lên khi có thể test từng layer độc lập bằng cách mock dependencies.
Business Logic có thể được unit test mà không cần database thật nhờ mock
repositories. Thứ tư, Reusability (tái sử dụng) được tối ưu khi Business
Logic có thể được sử dụng bởi nhiều loại UI khác nhau: Web UI (Razor
Pages), RESTful API (cho mobile app), hoặc Desktop application.

Nhược điểm của kiến trúc này cũng cần được xem xét. Overhead (chi phí
phát sinh) là vấn đề đầu tiên khi số lượng layers tăng đồng nghĩa với
nhiều classes, interfaces và code boilerplate hơn. Một tính năng đơn
giản như \"lấy danh sách sản phẩm\" có thể cần tạo: Entity class,
Repository interface, Repository implementation, Service interface,
Service implementation, DTO class, Mapper, và PageModel. Điều này có thể
cảm thấy \"over-engineering\" cho các dự án nhỏ.

Performance là vấn đề thứ hai khi data phải đi qua nhiều layers, mỗi
layer có thể thực hiện transformations (Entity → DTO → ViewModel), gây
overhead về memory và CPU. Tuy nhiên, với dự án quy mô vừa như
LaptopShopWeb, performance impact này thường không đáng kể so với lợi
ích về maintainability.

Trong bối cảnh dự án LaptopShopWeb, kiến trúc 3-tier được lựa chọn vì
cân bằng tốt giữa tính đơn giản (không quá phức tạp như microservices)
và khả năng mở rộng (dễ thêm features mới). Dự án có thể dễ dàng mở rộng
sang RESTful API cho mobile app trong tương lai bằng cách thêm một
Presentation Layer mới (Web API Controllers) nhưng vẫn sử dụng chung
Business Logic Layer và Data Access Layer hiện có.

## Repository Pattern

Repository Pattern cung cấp một lớp trừu tượng giữa business logic và
data access logic, đóng vai trò như một collection in-memory của các
domain objects. Pattern này tập trung hóa logic truy vấn dữ liệu vào một
nơi, giúp code business logic không phụ thuộc trực tiếp vào cách thức
lưu trữ dữ liệu. Trong dự án LaptopShopWeb, Repository Pattern được
implement thông qua generic interface định nghĩa các phương thức CRUD cơ
bản (GetById, GetAll, Add, Update, Delete) cho tất cả entities. Lợi ích
chính của pattern này là tăng khả năng kiểm thử (testability) vì có thể
dễ dàng mock repository trong unit tests, đồng thời tạo sự linh hoạt khi
muốn thay đổi data source trong tương lai mà không ảnh hưởng đến
business logic.

## Unit of Work {#unit-of-work-1}

Unit of Work Pattern quản lý danh sách các đối tượng bị thay đổi trong
một business transaction và điều phối việc ghi tất cả thay đổi vào
database trong một lần commit duy nhất. Pattern này đảm bảo tính toàn
vẹn dữ liệu (data integrity) bằng cách nhóm nhiều thao tác database
thành một transaction, hoặc tất cả thành công hoặc tất cả rollback nếu
có lỗi. Trong ASP.NET Core với Entity Framework Core, DbContext đã
implement Unit of Work pattern một cách ngầm định thông qua cơ chế
change tracking và phương thức SaveChangesAsync(). Tất cả các thay đổi
trên entities (thêm, sửa, xóa) được theo dõi bởi DbContext và chỉ được
persist vào database khi gọi SaveChangesAsync(), đảm bảo tính atomic của
transaction.

## Bảo mật Cơ bản trong Ứng dụng Web

Hệ thống LaptopShopWeb triển khai bảo mật thông qua cơ chế Cookie
Authentication kết hợp với mã hóa mật khẩu BCrypt và phân quyền dựa trên
vai trò (Role-Based Authorization). Cookie Authentication lưu trữ thông
tin xác thực trong encrypted cookie, phù hợp cho ứng dụng web truyền
thống (non-SPA). Khi người dùng đăng nhập thành công, server tạo
authentication cookie chứa các claims (NameIdentifier, Email, Name,
Role), cookie này được browser tự động gửi kèm theo mọi HTTP request
tiếp theo để server identify user. Thời gian sống của cookie được cấu
hình là 7 ngày với sliding expiration, nghĩa là mỗi lần user active sẽ
gia hạn thêm thời gian.

Về mã hóa mật khẩu, hệ thống sử dụng BCrypt - một thuật toán hash mạnh
với salt tự động và cost factor điều chỉnh được (work factor = 11 trong
dự án). BCrypt được thiết kế chậm một cách cố ý (slow by design) để
chống brute-force attacks, và cost factor có thể tăng theo thời gian khi
phần cứng mạnh hơn, đảm bảo tính bảo mật lâu dài. Phân quyền được thực
hiện thông qua ba vai trò: Customer (khách hàng - xem sản phẩm, đặt
hàng), Staff (nhân viên - xử lý đơn hàng, xem thống kê), và Admin (quản
trị viên - toàn quyền quản lý hệ thống). ASP.NET Core hỗ trợ phân quyền
qua attribute \`\[Authorize(Roles = \"Admin\")\]\` trên PageModels, tự
động chặn truy cập nếu user không có role phù hợp và redirect đến trang
AccessDenied.

4.  []{#_Toc216420420 .anchor}**Docker**

Docker là nền tảng containerization cho phép đóng gói ứng dụng cùng tất
cả dependencies (libraries, runtime, system tools) vào một container độc
lập, đảm bảo môi trường nhất quán từ development đến production. Khác
với virtualization truyền thống (VMware, VirtualBox) chạy toàn bộ hệ
điều hành, Docker containers chia sẻ kernel của host OS, do đó nhẹ hơn,
khởi động nhanh hơn (vài giây) và tiêu tốn ít tài nguyên hơn. Trong dự
án LaptopShopWeb, Docker được sử dụng để containerize SQL Server
database, đảm bảo mọi developer và môi trường testing đều sử dụng cùng
phiên bản SQL Server 2022 với cấu hình giống hệt nhau. Docker Compose được
sử dụng để orchestrate nhiều containers (database, application, cache
trong tương lai) thông qua file cấu hình YAML đơn giản, cho phép khởi
động toàn bộ stack bằng một lệnh duy nhất.

Lợi ích chính của containerization là tính nhất quán môi trường (\"works
on my machine\" syndrome được loại bỏ), isolation (mỗi service chạy độc
lập không ảnh hưởng lẫn nhau), portability (container có thể chạy trên
bất kỳ hệ thống nào hỗ trợ Docker), và khả năng mở rộng dễ dàng (scale
horizontal bằng cách tăng số lượng containers). Đối với dự án, việc sử
dụng Docker giúp đơn giản hóa quy trình setup môi trường phát triển, đảm
bảo database configuration nhất quán giữa các thành viên team, và chuẩn
bị sẵn sàng cho việc triển khai lên cloud platforms (AWS ECS, Azure
Container Instances, Google Cloud Run) trong tương lai mà không cần thay
đổi cấu trúc ứng dụng.

![](./image3.jpeg)

[]{#_Toc216440804 .anchor}CHƯƠNG 2: HIỆN THỰC HOÁ NGHIÊN CỨU

## Phân tích bài toán

Thị trường thương mại điện tử laptop tại Việt Nam đang phát triển mạnh
mẽ với nhu cầu học tập trực tuyến và làm việc từ xa tăng cao. Tuy nhiên,
nhiều cửa hàng laptop quy mô vừa và nhỏ vẫn quản lý thủ công qua Excel,
dẫn đến thông tin không nhất quán, khó kiểm soát tồn kho, xử lý đơn hàng
chậm và thiếu dữ liệu phân tích. Đặc thù của laptop là có nhiều thông số
kỹ thuật phức tạp (CPU, RAM, Storage, GPU, Screen) mà khách hàng cần so
sánh kỹ trước khi mua, đòi hỏi hệ thống hiển thị đầy đủ specifications
và hỗ trợ tìm kiếm/lọc theo nhiều tiêu chí.

Hệ thống LaptopShopWeb được xây dựng nhằm số hóa toàn bộ quy trình kinh
doanh laptop, cung cấp nền tảng web cho khách hàng mua sắm trực tuyến và
hệ thống quản trị tập trung cho admin/staff. Mục tiêu bao gồm: triển
khai phân quyền chặt chẽ (Customer/Staff/Admin), đảm bảo bảo mật với
BCrypt password hashing và cookie authentication, lưu trữ lịch sử đơn
hàng với snapshot giá để đảm bảo tính toàn vẹn dữ liệu, và tối ưu query
để tránh N+1 problem khi load products với nhiều relationships.

## Phân tích yêu cầu

Hệ thống được phân tích thành ba nhóm chức năng chính:

Chức năng Customer: Đăng ký/đăng nhập, duyệt/tìm kiếm sản phẩm với
filters (category, brand, price), xem chi tiết specs, thêm vào giỏ hàng,
checkout với thông tin giao hàng, xem lịch sử đơn hàng và chi tiết.

Chức năng Admin: CRUD sản phẩm với upload hình ảnh, CRUD danh mục, quản
lý đơn hàng với cập nhật trạng thái (Pending → Processing → Shipped →
Delivered), CRUD người dùng với phân quyền, dashboard thống kê (doanh
thu, đơn hàng, top products).

Chức năng System: Cookie Authentication, BCrypt password hashing (work
factor 11), Role-based Authorization, client/server-side validation,
session management cho giỏ hàng, EF Core Migrations cho database
versioning.

Yêu cầu phi chức năng:

\- Performance: Page load \< 2s, eager loading với Include(),
AsNoTracking() cho read-only queries, pagination 20 items/page

\- Security: BCrypt hashing, HttpOnly/Secure cookies, input validation
chống SQL Injection/XSS, authorization attributes

\- Usability: Responsive UI với Bootstrap 5, form validation rõ ràng,
confirmation dialogs

\- Maintainability: Kiến trúc 3-tier, Repository Pattern, Dependency
Injection, naming conventions

\- Scalability: Database chuẩn hóa, services interface hóa, Docker
containerization

## Thiết kế cơ sở dữ liệu

Database gồm 11 bảng chính: Users (Id, Email unique, PasswordHash,
FullName, Role, IsActive), Categories (Id, Name unique, Slug for SEO),
Products (Id, Name, Price, DiscountPrice, Brand, CPU, RAM, Storage, GPU,
Screen, OS, StockQuantity, CategoryId FK), ProductVariants (Id,
ProductId FK, VariantName, AdditionalPrice), ProductImages (Id,
ProductId FK, ImageUrl, IsMainImage), Carts (Id, UserId FK 1-1),
CartItems (Id, CartId FK, ProductId FK, Quantity, Price snapshot),
Orders (Id, OrderNumber unique, UserId FK, TotalAmount, Status,
ShippingAddress, PaymentMethod), OrderDetails (Id, OrderId FK, ProductId
FK, Quantity, UnitPrice snapshot, Subtotal), Reviews (Id, ProductId FK,
UserId FK, Rating, Comment).

Quan hệ chính: User 1-1 Cart, User 1-N Orders/Reviews, Category 1-N
Products, Product 1-N Variants/Images/OrderDetails/CartItems, Order 1-N
OrderDetails. Indexes: Email, OrderNumber, foreign keys, composite
(Order.Status + OrderDate). Ràng buộc: Price \> 0, StockQuantity \>= 0,
Rating 1-Chuẩn hóa 3NF để đảm bảo data integrity. Snapshot pricing trong
OrderDetails/CartItems để giá không thay đổi khi Product.Price update.

![](./image4.png)

1.  []{#_Toc216420425 .anchor}**Bảo mật và xác thực**

Hệ thống LaptopShopWeb triển khai bảo mật toàn diện thông qua Cookie
Authentication kết hợp mã hóa mật khẩu BCrypt và phân quyền dựa trên vai
trò. Cookie Authentication được chọn vì phù hợp với ứng dụng web
server-rendered, trong đó server tạo cookie chứa thông tin người dùng
(UserId, Email, Role) được mã hóa bằng Data Protection API của ASP.NET
Core và gửi về browser với các flags bảo mật như HttpOnly (chống XSS),
Secure (chỉ truyền qua HTTPS), và SameSite=Lax (chống CSRF). Mật khẩu
được hash bằng BCrypt với work factor 11, đảm bảo mỗi password có salt
riêng biệt và quá trình hash đủ chậm để chống brute-force attacks nhưng
vẫn chấp nhận được cho user experience. Hệ thống phân quyền ba cấp
(Customer, Staff, Admin) được triển khai thông qua Role-based
Authorization attributes, trong đó Customer có quyền duyệt sản phẩm và
đặt hàng, Staff xử lý đơn hàng và xem dashboard, còn Admin có toàn quyền
quản lý hệ thống. Input validation được thực hiện ở cả client-side
(HTML5 validation, jQuery) và server-side (Data Annotations,
ModelState), kết hợp với việc Razor tự động HTML encode output để chống
XSS và Entity Framework Core sử dụng parameterized queries để chống SQL
Injection. HTTPS được bắt buộc cho production thông qua middleware
redirect HTTP sang HTTPS và HSTS header yêu cầu browser chỉ dùng kết nối
bảo mật.

2.  []{#_Toc216420426 .anchor}**Chiến lược kiểm thử**

Chiến lược kiểm thử của dự án được thiết kế theo mô hình đa tầng nhằm
đảm bảo chất lượng ở mọi cấp độ từ unit đến integration và functional
testing. Unit testing tập trung vào Business Logic Layer sử dụng
framework xUnit kết hợp Moq để mock dependencies, kiểm tra từng method
độc lập như ProductService.GetProductById hoặc OrderService.CreateOrder
với coverage target trên 80%, đảm bảo logic nghiệp vụ hoạt động đúng
trong mọi trường hợp (happy path, edge cases, error handling).
Integration testing sử dụng WebApplicationFactory để spin up test server
với in-memory database hoặc TestContainers, kiểm tra tương tác giữa các
layers từ Presentation qua BLL đến DAL, ví dụ test workflow đăng nhập
với credentials hợp lệ sẽ redirect về trang chủ hoặc thêm sản phẩm vào
giỏ khi chưa login sẽ redirect đến trang đăng nhập. Functional testing
thực hiện end-to-end workflows từ góc nhìn người dùng, bao gồm scenarios
như đăng ký tài khoản mới, quy trình mua hàng hoàn chỉnh từ duyệt sản
phẩm đến checkout, và các chức năng quản trị như CRUD products với
verification hiển thị ở frontend, có thể được automated bằng Selenium
hoặc Playwright trong tương lai. Security testing kiểm tra các lỗ hổng
phổ biến như SQL Injection (test input với các ký tự đặc biệt), XSS
(test script tags trong comments), CSRF (test submit form từ external
site), và authorization bypass (test truy cập admin pages với customer
role), sử dụng tools như OWASP ZAP cho automated scan và Burp Suite cho
manual penetration testing. Performance testing đo các metrics quan
trọng như response time (mục tiêu dưới 2 giây cho page load), throughput
(requests/second), và số concurrent users hệ thống xử lý được, thông qua
các scenarios load testing (simulate 100 users), stress testing (tăng
dần đến breaking point), và spike testing (đột ngột tăng từ 10 lên 1000
users), sử dụng tools như Apache JMeter hoặc k6, với các optimization
techniques bao gồm database indexing, query optimization với
AsNoTracking, caching với Redis, và CDN cho static assets.

3.  []{#_Toc216420427 .anchor}**Triển khai và môi trường**

Hệ thống được triển khai trên ba môi trường riêng biệt nhằm đảm bảo quy
trình phát triển chuyên nghiệp và giảm thiểu rủi ro khi deploy
production. Development environment chạy trên máy local với .NET 9.0
SDK, Docker Desktop cho SQL Server container, và IDE như VS Code hoặc
Rider, cho phép developer clone repository, start database bằng
docker-compose, apply migrations, và chạy ứng dụng trên
https://localhost:7253 với self-signed certificate.

#  CHƯƠNG 3: KẾT QUẢ NGHIÊN CỨU {#chương-3-kết-quả-nghiên-cứu .unnumbered}

Chương này trình bày chi tiết các chức năng đã được triển khai trong hệ
thống LaptopShopWeb, bao gồm mô tả workflow và hình ảnh minh họa giao
diện thực tế. Nội dung tập trung vào việc hiện thực hóa các yêu cầu chức
năng đã phân tích ở Chương 2, đánh giá kết quả đạt được và những hạn chế
cần khắc phục.

## Chức năng dành cho khách hàng

**Chức năng đăng ký tài khoản**

Mô tả chức năng:

Cho phép người dùng mới tạo tài khoản để sử dụng hệ thống. Quá trình
đăng ký yêu cầu email (unique), password (tối thiểu 6 ký tự), họ tên, và
số điện thoại. Password được hash bằng BCrypt trước khi lưu vào
database, đảm bảo bảo mật.

Luồng thực hiện:

Bước 1 - Truy cập trang đăng ký: Người dùng nhấn vào nút \"Đăng ký\"
trên thanh navigation menu hoặc truy cập trực tiếp URL \`/Register\`. Hệ
thống hiển thị form đăng ký với các trường: Email, Password, Confirm
Password, Full Name, Phone Number.

![](./image5.png)

[]{#_Toc216441376 .anchor}Hình 3. 1 - Form đăng ký rỗng với validation
rules hiển thị

Bước 2 - Nhập thông tin và validation client-side: Người dùng điền thông
tin vào form. Validation client-side được kích hoạt real-time:

> \- Email: Phải đúng format email (kiểm tra @ và domain)
>
> \- Password: Tối thiểu 6 ký tự, nên chứa chữ hoa, chữ thường và số
>
> \- Confirm Password: Phải khớp chính xác với Password
>
> \- Full Name: Required, không được rỗng
>
> \- Phone Number: Required, format số điện thoại Việt Nam (10-11 số)

Nếu có lỗi, message hiển thị màu đỏ ngay dưới input field tương ứng.

![](./image6.png)

[]{#_Toc216441377 .anchor}Hình 3. 2 - Form đăng ký với validation errors
(password không khớp, email sai format)

Bước 3 - Submit form và validation server-side: Người dùng nhấn nút
\"Đăng ký\". Request POST được gửi đến \`Register.cshtml.cs\`.
Server-side validation được thực hiện:

> \- Kiểm tra email đã tồn tại trong database chưa
>
> \- Kiểm tra password và confirm password match
>
> \- Validate format và required fields lần nữa

Nếu email đã tồn tại, ModelState error được thêm vào và form được render
lại với message \"Email đã được sử dụng. Vui lòng chọn email khác.\"

![](./image7.png)

[]{#_Toc216441378 .anchor}Hình 3. 3 - Thông báo lỗi email đã tồn tại

Bước 4 - Tạo tài khoản và auto-login: Nếu validation pass:

1\. Password được hash

2\. User entity được tạo với Role = \"Customer\", IsActive = true

> 3.User được lưu vào database qua
> \`UserService.CreateUserAsync(userDto)\`

4\. Cookie authentication được tạo tự động (auto-login) với claims:
UserId, Email, FullName, Role

5\. Redirect đến trang chủ (\`/Index\`) với success message \"Đăng ký
thành công! Chào mừng bạn đến với LaptopShopWeb.\"

![](./image8.png)

[]{#_Toc216441379 .anchor}Hình 3. 4 - Trang chủ sau đăng ký thành công
với user menu hiển thị tên

**Chức năng đăng nhập**

Mô tả chức năng:

Cho phép người dùng đã có tài khoản đăng nhập vào hệ thống bằng email và
password. Hệ thống xác thực thông tin, tạo cookie authentication và
redirect theo vai trò người dùng (Customer → Home, Admin/Staff →
Dashboard).

Luồng thực hiện:

Bước 1 - Truy cập trang đăng nhập: Người dùng nhấn nút \"Đăng nhập\"
trên menu hoặc bị redirect tự động đến \`/Login\` khi cố truy cập trang
yêu cầu authentication (ví dụ: \`/Cart\`, \`/Checkout\`). Form đăng nhập
hiển thị với 2 fields: Email và Password, plus checkbox \"Remember Me\"
(optional).

![](./image9.png)

[]{#_Toc216441380 .anchor}Hình 3. 5 - Form đăng nhập với returnUrl
parameter

Bước 2 - Nhập credentials: Người dùng nhập email và password, có thể
tick \"Remember Me\" để cookie tồn tại lâu hơn (30 ngày thay vì 7 ngày
default).

Bước 3 - Submit và authenticate: Request POST được gửi đến
\`Login.cshtml.cs\`. Quá trình xác thực:

> 1\. Query user từ database theo email

2\. Nếu user không tồn tại hoặc IsActive = false: return error \"Email
hoặc mật khẩu không đúng\" (generic message để tránh account enumeration
attack)

3\. Verify password bằng \`BCrypt.Net.BCrypt.Verify(inputPassword,
user.PasswordHash)\`

> 4\. Nếu password sai: return error \"Email hoặc mật khẩu không đúng\"

5\. Nếu authentication thành công: update LastLoginAt timestamp, tạo
cookie với claims

![](./image10.png)

[]{#_Toc216441381 .anchor}Hình 3. 6 - Form đăng nhập với error message
\"Email hoặc mật khẩu không đúng\"

Bước 4 - Redirect theo role: Sau khi đăng nhập thành công:

> \- Customer: Redirect về returnUrl (nếu có) hoặc trang chủ \`/Index\`
>
> \- Admin/Staff: Redirect về \`/Admin/Index\` (Dashboard)

User menu trên navbar hiển thị tên người dùng với dropdown: Profile, My
Orders, Logout.

![](./image11.png)

[]{#_Toc216441382 .anchor}Hình 3. 7 - Navbar sau đăng nhập với user
dropdown menu

**Chức năng duyệt danh sách sản phẩm**

Mô tả chức năng:

Hiển thị tất cả sản phẩm laptop có sẵn dạng grid layout responsive. Hỗ
trợ filtering theo category, brand, price range và searching theo
keyword. Pagination được áp dụng với 20 sản phẩm per page.

Luồng thực hiện:

Bước 1 - Truy cập trang Products: Người dùng nhấn menu \"Sản phẩm\" hoặc
truy cập \`/Products\`. Default view hiển thị tất cả sản phẩm (không
filter), sorted theo mới nhất (CreatedAt DESC).

Grid layout: 4 cột trên desktop (≥1200px), 3 cột trên tablet
(768-1199px), 2 cột trên mobile (≤767px). Mỗi product card hiển thị:

\- Hình ảnh chính (main image)

\- Tên sản phẩm

\- Brand (badge nhỏ góc trên)

\- Giá (nếu có DiscountPrice thì hiển thị cả Price gạch ngang +
DiscountPrice màu đỏ)

\- CPU và RAM (thông tin nổi bật)

\- Stock status badge (\"Còn hàng\" màu xanh hoặc \"Hết hàng\" màu đỏ)

\- Nút \"Xem chi tiết\"

![](./image12.png)

[]{#_Toc216441383 .anchor}Hình 3. 8 - Trang Products với grid layout 4
cột và product cards

Bước 2 - Apply filters: Sidebar bên trái (hoặc collapsible panel trên
mobile) hiển thị filter options:

Category Filter:

\- Checkbox list: All, Gaming Laptop, Business Laptop, Workstation,
Ultrabook

\- Mỗi category hiển thị số lượng sản phẩm trong ngoặc (ví dụ: \"Gaming
Laptop (15)\")

Brand Filter:

\- Checkbox list: Dell, HP, Lenovo, Asus, MSI, Acer, Apple

\- Số lượng sản phẩm mỗi brand

Price Range Filter:

\- Radio buttons: Tất cả, Dưới 15 triệu, 15-25 triệu, 25-35 triệu, Trên
35 triệu

Sort Options:

\- Dropdown: Mới nhất, Giá: Thấp → Cao, Giá: Cao → Thấp, Tên: A-Z

Người dùng chọn filters và nhấn \"Áp dụng\". Page reload với query
params (ví
dụ:\`/Products?category=1&brand=Dell&priceMin=15000000&priceMax=25000000&sortBy=price_asc\`).
Số lượng kết quả hiển thị trên top: \"Tìm thấy 12 sản phẩm\".

![](./image13.png)

[]{#_Toc216441384 .anchor}Hình 3. 9 - Products page với filters applied
và results count

Bước 3 - Search: Search bar ở top right cho phép search theo tên sản
phẩm, brand hoặc specs (CPU, RAM). Ví dụ: nhập \"i7 16GB\" sẽ tìm
products có CPU chứa \"i7\" VÀ RAM chứa \"16GB\". Search sử dụng LIKE
query case-insensitive.

![](./image14.png)

[]{#_Toc216441385 .anchor}Hình 3. 10 - Search results cho keyword \"core
i3\"

Bước 4 - View product details: Click vào product card hoặc nút \"Xem chi
tiết\" redirect đến \`/Products/Details?id=123\`.

**Chức năng xem chi tiết và cấu hình sản phẩm**

Mô tả chức năng:

Hiển thị đầy đủ thông tin laptop bao gồm specifications, giá, hình ảnh,
mô tả chi tiết. Cho phép chọn số lượng và thêm vào giỏ hàng.

Luồng thực hiện:

Bước 1 - Load product details: URL format: \`/Products/Details?id=123\`.
PageModel gọi \`\_productService.GetProductByIdAsync(id)\` với eager
loading Category, ProductImages, ProductVariants. Nếu product không tồn
tại hoặc IsActive = false, return 404 Not Found.

Layout chia 2 phần:

Cột trái (40%): Image gallery

> \- Main image lớn (600x450px)
>
> \- Thumbnail strip bên dưới (4-5 thumbnails)
>
> \- Click thumbnail → change main image
>
> \- Lightbox modal nếu click main image (future enhancement)

Cột phải (60%): Product information

> \- Tên sản phẩm (h1 tag for SEO)
>
> \- Brand badge + Category badge
>
> \- Rating stars (nếu có reviews - chưa implement) + số reviews
>
> \- Price display:
>
> \- Nếu có DiscountPrice: \`\<del\>₫35,000,000\</del\> \<span
> class=\"text-danger\"\>₫32,000,000\</span\>\` (tiết kiệm 8%)
>
> \- Nếu không: giá thường
>
> \- Stock status: \"Còn 15 sản phẩm\" hoặc \"Hết hàng\" (disable Add to
> Cart button)
>
> \- Specifications table (dạng 2 cột):
>
> \- CPU: Intel Core i7-12700H
>
> \- RAM: 16GB DDR4
>
> \- Storage: 512GB SSD NVMe
>
> \- Graphics: NVIDIA RTX 3060 6GB
>
> \- Screen: 15.6\" FHD 144Hz IPS
>
> \- Operating System: Windows 11 Home
>
> \- Weight: 2.3 kg
>
> \- Color: Black
>
> \- Mô tả chi tiết (rich text HTML):
>
> \- Giới thiệu sản phẩm
>
> \- Điểm nổi bật
>
> \- Thông tin bảo hành
>
> \- Quantity selector: \`\<input type=\"number\" min=\"1\"
> max=\"{stock}\" value=\"1\"\>\`
>
> \- Nút \"Thêm vào giỏ hàng\" (button primary, disabled nếu out of
> stock)
>
> \- Nút \"Mua ngay\" (button success - shortcut checkout - future)

![](./image15.png)

[]{#_Toc216441386 .anchor}Hình 3. 11 - Product details page với image
gallery và specifications table

Bước 2 - Select quantity: Người dùng tăng/giảm số lượng bằng +/- buttons
hoặc nhập trực tiếp. Validation: không được vượt quá stock, không được
nhỏ hơn 1.

Bước 3 - Add to cart: Click \"Thêm vào giỏ hàng\":

\- Nếu chưa login: Redirect đến
\`/Login?returnUrl=/Products/Details?id=123\` với message \"Vui lòng
đăng nhập để thêm sản phẩm vào giỏ hàng\"

\- Nếu đã login:

> 1\. POST request đến handler \`OnPostAddToCartAsync()\` với productId
> và quantity
>
> 2\. Server call \`\_cartService.AddToCartAsync(userId, productId,
> quantity, price)\`
>
> 3\. Cart service check stock availability: \`if (product.StockQuantity
> \< quantity) return error\`
>
> 4\. Nếu product đã trong cart: cập nhật quantity (cộng thêm)
>
> 5\. Nếu product chưa có: tạo CartItem mới
>
> 6\. Success: show toast notification \"Đã thêm sản phẩm vào giỏ hàng\"

7\. Cart icon badge trên navbar cập nhật số lượng items (AJAX call hoặc
page refresh)

![](./image16.png)

[]{#_Toc216441387 .anchor}Hình 3. 12 - Toast notification \"Đã thêm vào
giỏ hàng\" và cart icon badge showing number

**Chức năng quản lý giỏ hàng**

Mô tả chức năng:

Hiển thị tất cả sản phẩm trong giỏ hàng của user, cho phép cập nhật số
lượng, xóa sản phẩm, và tính tổng tiền tự động.

Luồng thực hiện:

Bước 1 - Truy cập giỏ hàng: User nhấn vào cart icon trên navbar hoặc
truy cập \`/Cart\`. Yêu cầu authentication - nếu chưa login thì redirect
đến \`/Login?returnUrl=/Cart\`.

Page load gọi \`\_cartService.GetUserCartAsync(userId)\` để lấy Cart với
CartItems (eager loading Product, ProductVariant, ProductImages).

![](./image17.png)

[]{#_Toc216441388 .anchor}Hình 3. 13 - Cart page với 2-3 items

Bước 2 - Update quantity: Click nút +/- bên cạnh quantity input:

> \- AJAX POST đến \`OnPostUpdateQuantityAsync(cartItemId,
> newQuantity)\`
>
> \- Server validate: \`newQuantity \<= product.StockQuantity\`
>
> \- Nếu valid: update CartItem.Quantity, recalculate CartItem.Price
> (quantity × unit price)
>
> \- Response trả về: newQuantity, newItemTotal, newCartTotal
>
> \- Client-side JavaScript cập nhật DOM: item total và cart total mà
> không reload page

Nếu quantity vượt stock: show error message \"Số lượng vượt quá tồn kho
(còn {stock})\"

![](./image18.png)

[]{#_Toc216441389 .anchor}Hình 3. 14 - Quantity update với real-time
total calculation

Bước 3 - Remove item: Click icon thùng rác:

\- Show confirmation modal: \"Bạn có chắc muốn xóa {productName} khỏi
giỏ hàng?\"

> \- Nếu confirm: POST đến \`OnPostRemoveItemAsync(cartItemId)\`
>
> \- Server delete CartItem từ database
>
> \- Response: reload page hoặc AJAX remove row khỏi table + cập nhật
> cart total

![](./image19.png)

[]{#_Toc216441390 .anchor}Hình 3. 15 - Confirmation modal \"Xóa sản
phẩm\"

Bước 4 - Empty cart state: Nếu cart rỗng (không có CartItems), hiển thị
empty state:

> \- Icon giỏ hàng lớn (illustration hoặc font-awesome icon)
>
> \- Text: \"Giỏ hàng của bạn đang trống\"
>
> \- Button \"Khám phá sản phẩm\" → redirect to \`/Products\`

![](./image20.png)

[]{#_Toc216441391 .anchor}Hình 3. 16 - Empty cart state với CTA button

**Chức năng đặt hàng**

Mô tả chức năng:

Cho phép khách hàng nhập thông tin giao hàng, chọn phương thức thanh
toán và xác nhận đơn hàng. Sau khi order được tạo thành công, giỏ hàng
được clear và user nhận order confirmation.

Luồng thực hiện:

Bước 1 - Truy cập trang Checkout: Từ Cart page, user nhấn \"Thanh toán\"
→ redirect đến \`/Checkout\`. Preconditions check:

> 1\. User đã đăng nhập (redirect to Login nếu chưa)
>
> 2\. Cart không rỗng (redirect to Cart với error nếu rỗng)
>
> 3\. Tất cả items trong cart còn đủ stock (nếu có item out of stock,
> show error \"Một số sản phẩm trong giỏ hàng đã hết hàng\")
>
> ![](./image21.png)

[]{#_Toc216441392 .anchor}Hình 3. 17 - Checkout page với form và order
summary

Bước 2 - Fill shipping info: User điền hoặc sửa thông tin giao hàng.
Validation real-time:

> \- Họ tên, số điện thoại, địa chỉ là required
>
> \- Số điện thoại phải đúng format (10-11 số)
>
> \- Checkbox \"Tôi đồng ý\...\" phải được check

Bước 3 - View Order Confirmation: Page hiển thị:

> \- Success checkmark icon
>
> \- Message: \"Đơn hàng của bạn đã được đặt thành công!\"
>
> \- Order number: {ORD-XXXXXXXX}
>
> \- Thông tin đơn hàng: sản phẩm, số lượng, tổng tiền
>
> \- Thông tin giao hàng: địa chỉ, số điện thoại
>
> \- Phương thức thanh toán: COD
>
> \- Status: Pending (đang chờ xử lý)
>
> \- Estimated delivery: 3-5 ngày làm việc
>
> \- Buttons: \"Xem chi tiết đơn hàng\" →
> \`/Orders/Details?id={orderId}\`, \"Tiếp tục mua sắm\" → \`/Products\`

![](./image22.png)

[]{#_Toc216441393 .anchor}Hình 3. 18 - Order confirmation với all order
details

**Chức năng xem lịch sử đơn hàng**

Mô tả chức năng:

Cho phép customer xem danh sách tất cả đơn hàng đã đặt, sorted theo thời
gian mới nhất. Hiển thị order number, date, total amount, status. Click
vào order để xem chi tiết.

Luồng thực hiện:

Bước 1 - Truy cập Orders page: User click vào \"My Orders\" trong user
dropdown menu hoặc truy cập \`/Orders\`. Yêu cầu authentication.

PageModel gọi \`\_orderService.GetUserOrdersAsync(userId)\` để lấy danh
sách orders, sorted by OrderDate DESC.

![](./image23.png)

[]{#_Toc216441394 .anchor}Hình 3. 19 - Orders list page với multiple
orders và status badges

Bước 2 - View Order Details: Click \"Xem chi tiết\" → redirect đến
\`/Orders/Details?id={orderId}\`.

Precondition check: \`order.UserId == currentUserId\` (không cho xem
order của người khác).

![](./image24.png)

[]{#_Toc216441395 .anchor}Hình 3. 20 - Order details page với full
information

## Chức năng quản trị

### 2.1 Chức năng quản lí sản phẩm {#chức-năng-quản-lí-sản-phẩm .unnumbered}

Mô tả chức năng:

Cho phép Admin thực hiện CRUD (Create, Read, Update, Delete) đầy đủ cho
products. Quản lý tất cả thông tin sản phẩm bao gồm specs, giá, hình
ảnh, stock quantity.

Preconditions:

> \- User phải đăng nhập với Role = \"Admin\"
>
> \- Trang có attribute \`\[Authorize(Roles = \"Admin\")\]\`

Luồng thực hiện:

Bước 1 - Truy cập Product Management: Admin login → redirect đến
\`/Admin/Index\` (Dashboard) → nhấn menu \"Quản lý sản phẩm\" → redirect
đến \`/Admin/Products\`.

![](./image25.png)

[]{#_Toc216441396 .anchor}Hình 3. 21 - Admin Products list với table và
filters

Bước 2 - Create Product: Click \"Thêm sản phẩm mới\" → redirect đến
\`/Admin/Products/Create\`.

Form hiển thị với các fields:

-   Thông tin cơ bản

-   Thông số kỹ thuật

-   Giá và tồn kho

-   Hình ảnh

-   Trạng thái

![](./image26.png)

[]{#_Toc216441397 .anchor}Hình 3. 22 - Create Product form với tất cả
fields

![](./image27.png)

[]{#_Toc216441398 .anchor}Hình 3. 23 - Edit Product form với data
pre-filled

Bước 4 - Delete Product: Click nút \"Xóa\" → show confirmation modal:

\"Bạn có chắc muốn xóa sản phẩm \'{productName}\'? Hành động này không
thể hoàn tác.\"

![](./image28.png)

[]{#_Toc216441399 .anchor}Hình 3. 24 - Delete confirmation modal

### 2.2 Chức năng quản lý danh mục {#chức-năng-quản-lý-danh-mục .unnumbered}

Mô tả chức năng:

Quản lý categories cho products. CRUD operations đơn giản hơn Product
Management.

Luồng thực hiện:

Bước 1 - View Categories: Admin → \`/Admin/Categories\` → table hiển
thị:

![](./image29.png)

[]{#_Toc216441400 .anchor}Hình 3. 25 - Admin Categories list

Bước 2 - Create/Update Category: Form với fields:

> \- Tên danh mục: \[input\] (required, unique)
>
> \- Mô tả: \[textarea\] (optional)
>
> \- Slug: \[input\] (auto-generated từ tên, editable, unique, for SEO)
>
> \- \[Checkbox\] Kích hoạt

Bước 3 - Delete Category: Kiểm tra nếu category có products:

\- Nếu có: show error \"Không thể xóa danh mục đang chứa sản phẩm. Vui
lòng di chuyển hoặc xóa các sản phẩm trước.\"

\- Nếu không: allow delete

### 2.3 Chức năng quản lý đơn hàng {#chức-năng-quản-lý-đơn-hàng .unnumbered}

Mô tả chức năng:

Cho phép Admin/Staff xem tất cả đơn hàng, filter theo status, và cập
nhật trạng thái đơn hàng.

Luồng thực hiện:

Bước 1 - View All Orders:\*\* Admin/Staff → \`/Admin/Orders\` → table:

![](./image30.png)

[]{#_Toc216441401 .anchor}Hình 3. 26 - Admin Orders list với filters

Bước 2 - View Order Details

Hiển thị tương tự customer order details nhưng thêm:

> \- Thông tin khách hàng chi tiết (email, phone, address)
>
> \- Payment status
>
> \- Notes từ customer
>
> \- Action buttons để update status

Bước 3 - Update Order Status: Dropdown hoặc buttons để chuyển status:

Status transitions allowed:

> \- Pending → Processing (Admin nhấn \"Xác nhận đơn hàng\")
>
> \- Pending → Cancelled (Admin nhấn \"Hủy đơn hàng\")
>
> \- Processing → Shipped (Admin nhấn \"Đánh dấu đã giao cho vận
> chuyển\", nhập ShippedDate)
>
> \- Shipped → Delivered (Admin nhấn \"Đánh dấu đã giao hàng\", nhập
> DeliveredDate)
>
> \- Shipped → Cancelled (Nếu giao hàng thất bại)

![](./image31.png)

[]{#_Toc216441402 .anchor}Hình 3. 27 - Update order status modal

### 2.4 Chức năng dashboard {#chức-năng-dashboard .unnumbered}

Mô tả chức năng:

Trang tổng quan hiển thị các metrics quan trọng và insights về hoạt động
kinh doanh.

Luồng thực hiện:

Bước 1 - Load Dashboard: Admin/Staff login → auto redirect đến
\`/Admin/Index\`.

![](./image32.png)

[]{#_Toc216441403 .anchor}Hình 3. 28 - Dashboard summary cards

## Kết quả đạt được

### 3.1 Đánh giá chất lượng hệ thống {#đánh-giá-chất-lượng-hệ-thống .unnumbered}

Hệ thống LaptopShopWeb sau khi hoàn thành đã đạt được chất lượng tốt về
mặt kỹ thuật và đáp ứng các yêu cầu đã đặt ra ban đầu. Về kiến trúc,
việc áp dụng mô hình 3-tier với sự phân tách rõ ràng giữa Presentation,
Business Logic và Data Access Layer đã tạo ra codebase có cấu trúc rõ
ràng, dễ bảo trì và mở rộng, với coupling thấp giữa các components nhờ
sử dụng Dependency Injection và các design patterns như Repository và
DTO. Database được thiết kế chuẩn hóa ở dạng 3NF với 11 bảng có quan hệ
rõ ràng, indexes được đặt hợp lý trên các cột thường xuyên query (Email,
OrderNumber, foreign keys, composite index cho Order.Status +
OrderDate), và snapshot pricing trong OrderDetails đảm bảo tính toàn vẹn
dữ liệu lịch sử khi giá sản phẩm thay đổi. Về bảo mật, hệ thống đạt được
mức độ an toàn cơ bản với Cookie Authentication được cấu hình HttpOnly
và Secure, mật khẩu hash bằng BCrypt work factor 11, Role-based
Authorization với ba cấp phân quyền rõ ràng, input validation ở cả
client và server side, và Entity Framework Core tự động chống SQL
Injection thông qua parameterized queries. Performance của hệ thống đạt
mức chấp nhận được với thời gian load trang chủ dưới 1.5 giây, trang
danh sách sản phẩm với 20 items load trong 1.8 giây, và các trang chi
tiết sản phẩm hoặc giỏ hàng load dưới 1 giây, nhờ vào việc sử dụng eager
loading với Include() để tránh N+1 problem, AsNoTracking() cho read-only
queries, và pagination hợp lý. Code quality được đảm bảo thông qua
naming conventions nhất quán, comments cho các logic phức tạp, error
handling với try-catch blocks và ModelState validation, và logging với
ILogger để track các actions quan trọng và errors. Responsive design
được triển khai bằng Bootstrap 5 giúp giao diện hoạt động tốt trên
desktop (grid 4 cột), tablet (3 cột) và mobile (2 cột hoặc 1 cột), với
các components như navbar collapse, modal dialogs và form validation đều
adaptive theo kích thước màn hình.

### 3.2 Giải quyết bài toán ban đầu {#giải-quyết-bài-toán-ban-đầu .unnumbered}

Hệ thống đã giải quyết thành công các vấn đề chính được nêu ra trong
phần phân tích bài toán, giúp số hóa toàn bộ quy trình kinh doanh laptop
và khắc phục tình trạng quản lý thủ công không hiệu quả. Về quản lý sản
phẩm, thay vì dùng Excel với thông tin rời rạc và dễ sai sót, hệ thống
cung cấp giao diện quản trị tập trung cho phép admin thêm sản phẩm mới
với đầy đủ thông số kỹ thuật (CPU, RAM, Storage, GPU, Screen, OS),
upload nhiều hình ảnh, set giá và discount, quản lý stock quantity, và
tất cả thông tin được lưu trong database chuẩn hóa đảm bảo tính nhất
quán giữa frontend và backend. Chức năng tìm kiếm và lọc sản phẩm đã
được triển khai toàn diện với filters theo category (Gaming, Business,
Workstation, Ultrabook), brand (Dell, HP, Lenovo, Asus, MSI), price
range (dưới 15 triệu, 15-25 triệu, 25-35 triệu, trên 35 triệu), và
search theo keyword trong tên sản phẩm, brand hoặc specs, giúp khách
hàng dễ dàng tìm được laptop phù hợp với nhu cầu và ngân sách. Quy trình
đặt hàng đã được tự động hóa hoàn toàn từ add to cart, view cart với
real-time total calculation, checkout với form validation đầy đủ, đến
tạo order với status Pending, snapshot giá vào OrderDetails để tránh
thay đổi khi giá sản phẩm update, tự động giảm stock quantity, clear
cart sau khi đặt hàng thành công, và gửi order confirmation cho
customer, thay thế hoàn toàn việc nhận order qua điện thoại hoặc tin
nhắn với nhiều sai sót. Hệ thống phân quyền ba cấp đã giải quyết bài
toán quản lý nhân sự và bảo mật thông tin, trong đó Customer chỉ thấy
sản phẩm và đơn hàng của mình, Staff có thể xem tất cả orders và update
status từ Pending → Processing → Shipped → Delivered nhưng không được
sửa products hay users, còn Admin có full control để manage products,
categories, orders và users, với authorization attributes ngăn chặn truy
cập trái phép. Về quản lý tồn kho, thay vì theo dõi thủ công dễ nhầm
lẫn, hệ thống tự động cập nhật StockQuantity mỗi khi có order mới, hiển
thị stock status (\"Còn X sản phẩm\" hoặc \"Hết hàng\") trên product
details, disable nút Add to Cart khi out of stock, và validate stock
trước khi cho phép checkout để tránh overselling. Dashboard thống kê
cung cấp overview cho admin/staff về tổng doanh thu, số đơn hàng theo
status, top selling products, và low stock alerts, giúp ra quyết định
kinh doanh dựa trên dữ liệu thực tế thay vì ước đoán, đồng thời
migration system cho phép dễ dàng update database schema khi có thay đổi
requirements mà không mất dữ liệu, và Docker containerization đảm bảo
môi trường development nhất quán giữa các developers và dễ dàng deploy
lên production.

#  CHƯƠNG 4: KẾT LUẬN {#chương-4-kết-luận .unnumbered}

## Kết luận

Đồ án \"LaptopShopWeb - Hệ thống Thương mại Điện tử Laptop\" đã hoàn
thành với đầy đủ các chức năng cốt lõi của một nền tảng thương mại điện
tử. Hệ thống được xây dựng trên công nghệ ASP.NET Core 9.0, Entity
Framework Core 9.0 và SQL Server 2022, tuân thủ kiến trúc phân lớp 3-tier
với các design patterns hiện đại (Repository, Dependency Injection,
DTO).

Kết quả đạt được:

\- Triển khai thành công 99% yêu cầu chức năng bao gồm: quản lý người
dùng với phân quyền 3 cấp (Customer/Staff/Admin), duyệt và tìm kiếm sản
phẩm với filters đa tiêu chí, quản lý giỏ hàng persistent, quy trình đặt
hàng hoàn chỉnh với snapshot giá, và hệ thống quản trị tập trung với
dashboard thống kê.

\- Database được thiết kế chuẩn hóa 3NF với 11 bảng, đảm bảo tính toàn
vẹn dữ liệu và hỗ trợ tốt các quan hệ phức tạp giữa entities.

\- Bảo mật đạt mức cơ bản với BCrypt password hashing (work factor 11),
Cookie Authentication với HttpOnly/Secure flags, Role-based
Authorization, và input validation chống SQL Injection/XSS.

\- Performance đạt yêu cầu với page load time dưới 2 giây nhờ eager
loading, AsNoTracking(), indexes và pagination.

\- Responsive UI với Bootstrap 5 hoạt động tốt trên desktop, tablet và
mobile.

Đóng góp:

\- Cung cấp case study điển hình về việc áp dụng kiến trúc phân lớp và
design patterns trong phát triển e-commerce với .NET Core.

\- Minh họa quy trình thiết kế database từ ER modeling đến normalized
schema với snapshot pricing cho historical data accuracy.

\- Giải quyết bài toán số hóa hoạt động kinh doanh laptop cho các cửa
hàng quy mô vừa và nhỏ, thay thế quản lý thủ công bằng hệ thống tự động
hóa.

\- Source code có thể làm tài liệu tham khảo cho sinh viên và developers
học về ASP.NET Core development và e-commerce systems.

Hạn chế:

> \- Chưa tích hợp payment gateway trực tuyến (VNPay, MoMo), chỉ hỗ trợ
> COD.

\- Thiếu chức năng product review, product comparison, wishlist, và
email notifications.

> \- Unit test coverage thấp (\<20%), chưa có CI/CD pipeline.
>
> \- Chưa có caching layer (Redis), logging chưa comprehensive.

\- Một số vấn đề bảo mật cần cải thiện: anti-CSRF tokens, account
lockout, rate limiting, password policy.

## Hướng phát triển

### 2.1 Ngắn hạn (1-3 tháng) {#ngắn-hạn-1-3-tháng .unnumbered}

\- Tích hợp VNPay payment gateway: Research API, implement payment
request generation, handle IPN callbacks, test sandbox và deploy
production.

\- Unit tests và CI/CD: Setup xUnit test project, write tests cho
Services (target \>80% coverage), tích hợp GitHub Actions cho automated
testing và deployment.

\- Email notifications: Implement SendGrid/AWS SES cho order
confirmation, status updates, password reset với Hangfire background
jobs.

\- Redis caching: Cache category list, popular products, user cart để
giảm database load và improve response time.

\- Enhance security: Thêm anti-forgery tokens, account lockout sau
failed logins, rate limiting middleware, stronger password policy.

### 2.2 Trung hạn (3-6 tháng) {#trung-hạn-3-6-tháng .unnumbered}

\- Product review system: Cho phép verified purchasers review, admin
moderation, display ratings/reviews với helpful votes.

\- Advanced search: Tích hợp Elasticsearch cho faceted search,
autocomplete, typo tolerance, và relevance ranking.

\- Wishlist/Favorites: Thêm wishlist functionality để customers lưu sản
phẩm yêu thích.

\- Product comparison: So sánh specs của nhiều laptops side-by-side.

\- Inventory management: Cảnh báo low stock tự động, purchase orders,
supplier management.

\- Promotion engine: Discount codes, flash sales, bundle deals với rules
engine.

### 2.3 Dài hạn (6-12 tháng) {#dài-hạn-6-12-tháng .unnumbered}

\- Mobile app (iOS/Android): Xây dựng RESTful API backend, develop
native mobile apps hoặc React Native/Flutter cross-platform app.

\- AI recommendations: Machine learning model để recommend sản phẩm
based on browsing history, purchase behavior, và collaborative
filtering.

\- Multi-vendor marketplace: Mở rộng từ single-store sang platform cho
nhiều sellers với commission-based revenue model.

\- Chatbot support: Tích hợp AI chatbot (Dialogflow, Azure Bot Service)
cho customer support 24/7.

\- Advanced analytics: Business intelligence dashboard với sales
forecasting, customer segmentation, và inventory optimization.

\- Microservices architecture: Refactor sang microservices cho
scalability (Product Service, Order Service, Payment Service,
Notification Service).

### 2.4 Mở rộng scalability {#mở-rộng-scalability .unnumbered}

\- Cloud deployment: Migrate lên Azure App Service hoặc AWS ECS với
auto-scaling, load balancer và CDN (CloudFront, Azure CDN).

\- Database optimization:Read replicas cho reporting queries, database
sharding nếu cần, query optimization với execution plans.

\- Message queue: RabbitMQ/Azure Service Bus cho asynchronous processing
(order processing, email sending, report generation).

\- Monitoring và observability:Application Insights/New Relic cho APM,
ELK stack cho centralized logging, distributed tracing với
OpenTelemetry.

\- Setup Elasticsearch cluster

\- Index products với full specifications

\- Implement faceted search (filter by brand, CPU, RAM, price
simultaneously)

\- Add autocomplete suggestions

\- Implement search analytics (track popular searches, zero-result
searches)

### 2.5 Scalability improvements {#scalability-improvements .unnumbered}

Infrastructure:

\- Migrate to cloud platform (Azure App Service, AWS ECS, hoặc GKE)

\- Implement auto-scaling based on load

\- Add CDN for static assets (CloudFlare, Azure CDN)

\- Setup multi-region deployment cho high availability

\- Implement disaster recovery plan

Database:

\- Implement read replicas cho read-heavy queries

\- Add database sharding nếu data volume lớn

\- Migrate historical data to data warehouse (BigQuery, Snowflake)

\- Implement connection pooling optimization

\- Add database monitoring và performance tuning

Monitoring:

\- Setup Application Performance Monitoring (APM) với Azure Application
Insights hoặc New Relic

\- Add distributed tracing cho microservices (nếu migrate to
microservices)

\- Implement real-time alerting (PagerDuty, OpsGenie)

\- Add business metrics dashboard (Grafana, Kibana)

\- Setup synthetic monitoring (uptime checks, transaction monitoring)

## Lời kết

Đồ án \"LaptopShopWeb - Hệ thống Thương mại Điện tử Laptop\" đã đạt được
mục tiêu xây dựng một nền tảng web hoàn chỉnh để số hóa hoạt động kinh
doanh laptop. Hệ thống không chỉ đáp ứng được các yêu cầu chức năng cốt
lõi mà còn áp dụng thành công các nguyên lý thiết kế phần mềm hiện đại,
các design patterns và best practices trong software engineering.

Qua quá trình thực hiện đồ án, em đã có cơ hội áp dụng kiến thức lý
thuyết đã học vào giải quyết bài toán thực tế, từ phân tích yêu cầu,
thiết kế database và architecture, implementation với ASP.NET Core và
Entity Framework Core, đến testing và deployment. Em cũng học được cách
làm việc với các công cụ và công nghệ hiện đại như Docker, Git,
SQL Server, và các cloud services.

Dù hệ thống còn một số hạn chế và vẫn có nhiều tính năng có thể phát
triển thêm, đồ án đã chứng minh tính khả thi của việc áp dụng công nghệ
.NET trong xây dựng hệ thống thương mại điện tử. Với roadmap phát triển
rõ ràng được nêu trong phần hướng phát triển, hệ thống hoàn toàn có thể
được mở rộng và đưa vào sử dụng thực tế cho các cửa hàng laptop quy mô
vừa và nhỏ.

Em xin chân thành cảm ơn TS. Đoàn Phước Miền đã tận tình hướng dẫn, quý
Thầy Cô trong Khoa Công nghệ Thông tin đã truyền đạt kiến thức, và gia
đình, bạn bè đã động viên em hoàn thành đồ án này.
