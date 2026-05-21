# 🏀 EuroLeague Yönetim Sistemi

EuroLeague basketbol takımlarını, oyuncu kadrolarını ve maç fikstürlerini yönetmek için geliştirilmiş tam kapsamlı (full-stack) bir web uygulaması. Bu proje, .NET ekosistemine sağlam bir giriş niteliğinde olup, RESTful API ve modern bir arayüz ile çok katmanlı (decoupled) bir mimariyi sergilemektedir.

## 🚀 Teknoloji Yığını (Tech Stack)

**Arka Plan (Backend - API):**
* C# & ASP.NET Core Web API
* Entity Framework Core (Code-First Yaklaşımı)
* Microsoft SQL Server (MSSQL)
* JWT (JSON Web Token) ile Kimlik Doğrulama ve Yetkilendirme

**Ön Yüz (Frontend - İstemci):**
* Blazor WebAssembly (WASM)
* Duyarlı (responsive) UI/UX tasarımı için Bootstrap 5
* RESTful API iletişimi için HttpClient

## ✨ Öne Çıkan Özellikler

* **Güvenli Admin Paneli:** Yönetim arayüzüne erişim için geçerli bir token (kimlik doğrulama) gerektiren JWT korumalı rotalar.
* **Takım Yönetimi (CRUD):** Şehir, başantrenör ve kuruluş yılı gibi detaylarla EuroLeague takımlarını ekleme, güncelleme, listeleme ve silme.
* **Oyuncu Kadroları (CRUD):** Yüzlerce oyuncuyu yönetme, onları forma numaraları ve pozisyonlarıyla spesifik takımlara atama.
* **Fikstür ve Maç Yönetimi:** Takımlar arası maçları planlama ve sistem üzerinden maç skorlarını kaydetme.
* **Toplu Veri İşleme (Bulk Insert):** Tüm lig kadrolarını (20 takımda 300'e yakın oyuncu) ve lig fikstürünü tek bir tıklamayla veritabanına sorunsuz bir şekilde yüklemek için tasarlanmış özel metotlar.
* **İlişkisel Veritabanı Mimarisi:** Takımlar, Oyuncular ve Maçlar tabloları arasında veri bütünlüğünü sağlayan sağlam Foreign Key (Yabancı Anahtar) bağlantıları.

## 🛠️ Proje Mimarisi

Proje, veri erişim katmanı, API uç noktaları ve kullanıcı arayüzü (UI) arasındaki sorumlulukları birbirinden ayıran N-Katmanlı (N-Tier) mimari felsefesini benimser.
* `BasketbolAPI`: Veritabanı işlemlerini, iş mantığını, yönlendirmeyi ve güvenlik token'ı üretimini yönetir.
* `BasketbolFrontend`: API'yi tüketen, arka plandaki iş mantığından tamamen bağımsız çalışan (decoupled) modern bir Blazor uygulamasıdır.

## ⚙️ Kendi Bilgisayarınızda Çalıştırma (Kurulum)

Projeyi indirip çalıştırmak için terminalinizde aşağıdaki komut akışını izleyebilirsiniz. SQL Server'ın (veya Docker üzerindeki MSSQL'in) çalıştığından emin olduktan sonra:

```bash
# 1. Projeyi bilgisayarınıza indirin
git clone [https://github.com/tuonde/EuroLeague-Management-System.git](https://github.com/tuonde/EuroLeague-Management-System.git)

# 2. API klasörüne girin, veritabanını oluşturun ve API'yi başlatın
cd EuroLeague-Management-System/BasketbolAPI
dotnet ef database update
dotnet run

(API çalıştıktan sonra terminalde yeni bir sekme açın)

# 3. Frontend klasörüne girip arayüzü başlatın
cd ../BasketbolFrontend
dotnet run

İşlemler tamamlandıktan sonra tarayıcınızı açıp terminalde ekrana gelen adrese (örneğin http://localhost:5090) giderek uygulamayı kullanmaya başlayabilirsiniz.

👤 Geliştirici
Tunahan Onursal Demiral - Bilgisayar Mühendisliği Öğrencisi
