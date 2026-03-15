# 🏨 Otel Yönetim Sistemi — ASP.NET Core 8.0 MVC & API

![.NET](https://img.shields.io/badge/.NET%208.0-512BD4?style=flat-square&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=flat-square&logo=c-sharp&logoColor=white)
![SMTP](https://img.shields.io/badge/SMTP-Email%20Service-orange?style=flat-square&logo=mail.ru&logoColor=white)
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
* **SMTP Email Service:** Kullanıcı bilgilendirmeleri ve sistem mesajları için System.Net.Mail kütüphanesini kullanarak asenkron bir e-posta gönderim altyapısı kurdum.
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

<img width="1920" height="1551" alt="Image" src="https://github.com/user-attachments/assets/1149594c-5eaa-4a03-934e-2a95671aacfa" />
<img width="1920" height="1407" alt="Image" src="https://github.com/user-attachments/assets/57805a9e-51aa-458e-84f7-eb2765b059c0" />
<img width="1920" height="1229" alt="Image" src="https://github.com/user-attachments/assets/3e416a60-6713-44c0-8d22-317ad009520e" />
<img width="1920" height="2452" alt="Image" src="https://github.com/user-attachments/assets/72b7c44a-ac49-4e6c-bf69-7899532bc2a8" />

# 🛠️ Admin Paneli

<img width="1915" height="931" alt="Image" src="https://github.com/user-attachments/assets/a217019e-f814-465d-a280-f6f74313b390" />
<img width="1893" height="873" alt="Image" src="https://github.com/user-attachments/assets/da151525-af7d-4068-91da-46c1f85c985c" />
<img width="1896" height="876" alt="Image" src="https://github.com/user-attachments/assets/535b4a53-4f44-4494-997e-12f11cce53de" />
<img width="1912" height="865" alt="Image" src="https://github.com/user-attachments/assets/6e244951-d0af-4f71-b530-3324076976c1" />
<img width="1895" height="869" alt="Image" src="https://github.com/user-attachments/assets/1fe00e74-ab72-4f6a-b175-da8df2ae7833" />
<img width="1909" height="872" alt="Image" src="https://github.com/user-attachments/assets/3742c674-1add-45dd-a3ed-b7042c3f6ec9" />
<img width="1917" height="866" alt="Image" src="https://github.com/user-attachments/assets/fa2423fa-f9c7-4218-b17b-7603012f0c23" />
<img width="1892" height="865" alt="Image" src="https://github.com/user-attachments/assets/35a07911-c13d-446b-9efb-b87057589a94" />
<img width="1894" height="873" alt="Image" src="https://github.com/user-attachments/assets/9cf433a8-02a6-4320-989f-7481f65ffca7" />
<img width="1913" height="872" alt="Image" src="https://github.com/user-attachments/assets/a449911a-b275-4e2f-8942-0546e49e92b0" />
<img width="1914" height="869" alt="Image" src="https://github.com/user-attachments/assets/036d85c8-7f12-4764-80c9-8380b4ef9009" />
<img width="1905" height="866" alt="Image" src="https://github.com/user-attachments/assets/9f6b3439-6adc-4414-a7e3-71d4dd0b79cd" />
<img width="1895" height="877" alt="Image" src="https://github.com/user-attachments/assets/e94d8d40-b0d9-4c2f-b5ac-23a7842d44c4" />

# 📑 Swagger'da API Endpointleri

<img width="1895" height="932" alt="Image" src="https://github.com/user-attachments/assets/c933af07-6df2-4840-ad6a-81ad596d7617" />
