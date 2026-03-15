# 🏨 WebAPI Otel Yönetim Sistemi

![.NET](https://img.shields.io/badge/.NET%208.0-512BD4?style=flat-square&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=flat-square&logo=c-sharp&logoColor=white)
![Microsoft SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=flat-square&logo=microsoft-sql-server&logoColor=white)
![Entity Framework Core](https://img.shields.io/badge/EF%20Core-512BD4?style=flat-square&logo=nuget&logoColor=white)
![JWT](https://img.shields.io/badge/JWT-black?style=flat-square&logo=JSON%20web%20tokens)
![AutoMapper](https://img.shields.io/badge/AutoMapper-8A2BE2?style=flat-square&logo=nuget&logoColor=white)
![FluentValidation](https://img.shields.io/badge/FluentValidation-42A5F5?style=flat-square&logo=nuget&logoColor=white)
![Swagger](https://img.shields.io/badge/Swagger-85EA2D?style=flat-square&logo=swagger&logoColor=black)
![Bootstrap](https://img.shields.io/badge/Bootstrap-7952B3?style=flat-square&logo=bootstrap&logoColor=white)

## 📖 Proje Hakkında

Proje, otel yönetimi senaryosu üzerine kurulu olup bir yanda RESTful Web API, diğer yanda ise bu API’yi tüketen ASP.NET Core MVC (Razor) tabanlı Admin Panel ve arayüz (UI) katmanlarından oluşuyor. Otel yönetimiyle ilgili temel operasyonları (oda, rezervasyon, mesaj, hizmet, abonelik vb.) API üzerinden yönetilebilir hale getirdim. Admin paneli API'ye bağlayarak dinamik veri gösterimi, listelemelerde sayfalama ve CRUD işlemlerini gerçekleştirdim. Projeyi geliştirirken çok katmanlı mimari, Repository ve Service katmanı tasarımı, DTO kullanımı gibi pratikleri uyguladım.

## 🚀 Kullanılan Teknolojiler ve Desenler

### ⚙️ Web API Katmanı (Backend)
Veritabanı işlemleri, iş kuralları ve dış dünyaya veri sunumu için yapılandırdığım arka plan servisidir;

* **Entity Framework Core:** SQL Server üzerindeki veritabanı işlemlerini ve tabloları C# nesneleri üzerinden yönetmek için kullandım.
* **ASP.NET Core Identity & JWT:** Kullanıcı (AppUser) ve rol (AppRole) yönetimini sağladım. Kimlik doğrulama işlemleri için sisteme JWT Bearer Authentication yapısını entegre ettim.
* **AutoMapper:** Veritabanı nesneleri (Entity) ile dışarıya açtığım DTO'lar arasındaki dönüşümleri otomatikleştirerek kod tekrarını engelledim.
* **FluentValidation:** DTO modellerinin doğrulama kurallarını iş mantığından ayırarak temiz bir şekilde yazdım.
* **Swashbuckle (Swagger):** Geliştirdiğim endpoint'leri test edebilmek amacıyla projeye dahil ettim.
* **Repository & Service Layer Pattern:** Veritabanı işlemlerini generic bir yapıda (`GenericRepository<T>`) soyutladım ve temel iş kurallarını Manager sınıfları içerisinde uyguladım.
* **CORS Policy:** UI ile API arasında gerekli izinleri sağlamak için yapılandırdım.

### 🎨 Web UI Katmanı (Frontend)
Kullanıcıların ve yöneticilerin sistemi kullandığı web arayüzüdür;

* **ASP.NET Core MVC (Razor):** Kullanıcı arayüzünü ve modüler bir yapıda (Areas) tasarladığım Admin panelini geliştirmek için kullandım.
* **IHttpClientFactory & DelegatingHandler:** Web UI katmanının Web API ile iletişimini sağlamak için kullandım. `TokenHandler` sınıfı oluşturarak, oturumdaki JWT token'ı giden isteklerin `Authorization` başlığına otomatik olarak ekledim.
* **X.PagedList:** Admin panelindeki mesaj, rezervasyon ve abonelik listesi gibi sayfalarda sayfalama (pagination) işlemlerini gerçekleştirdim.
* **Session & Cookie Authentication:** Web UI tarafında kullanıcı girişlerini yönetmek ve API'den gelen token'ı saklamak için kullandım.

---

## 📂 Dosya ve Mimari Yapısı

Projeyi N-Tier (çok katmanlı) mimari prensiplerine uygun olarak tasarladım ve iki ana klasöre böldüm:

### 1- `APIConsume/` (Web API ve Backend)
* **`HotelManagement.EntityLayer`**: Veritabanı tablolarının (Room, Booking, vb.) karşılığı olan domain nesnelerini ve JWT üretimi için yardımcı sınıfları tuttuğum katman.
* **`HotelManagement.DataAccessLayer`**: EF Core `DbContext` yapılandırmasını, DAL arayüzlerini ve `GenericRepository<T>` ile veritabanı sorgularını yazdığım katman.
* **`HotelManagement.BusinessLayer`**: İş kurallarını (Manager sınıfları) ve DTO'lar için FluentValidation kurallarını yazdığım katman.
* **`HotelManagement.DataTransferObjectLayer`**: API ve UI arasında taşınan Insert/Update/Result DTO nesnelerini barındıran katman.
* **`HotelManagement.WebAPILayer`**: Gelen HTTP isteklerini karşılayan Controller'ları, AutoMapper profillerini, Swagger ve yetkilendirme ayarlarını yapılandırdığım API katmanı.

### 2- `Frontend/` (İstemci / UI)
* **`HotelManagement.WebUILayer`**: API'yi tüketerek son kullanıcıya ve yöneticiye sunduğum katman.
* **`Areas/Admin`**: Admin paneline ait Controller ve View'ları (dashboard, oda yönetimi, kullanıcı/rol atamaları vb.) ana projeden bağımsız bir şekilde organize ettiğim klasör.

# 🏠 Kullanıcı Sayfası
# 🛠️ Admin Paneli
# 📑 Swagger'da API Endpointleri
