🗺️ Basketbol API - "Junior'dan Senior'a" Yol Haritası
Adım 1: Veri Kalıcılığı (Entity Framework Core & MSSQL) 📍 (Şu an buradayız)

Ne yapacağız: RAM üzerindeki geçici MockDataStore yapısını sileceğiz. Yerine projeyi yerel bir SQL Server'a bağlayacağız.

Kazanım: Bilgisayarı kapatsan da veriler kaybolmayacak. EF Core sayesinde SQL sorgusu (SELECT, INSERT) yazmadan C# koduyla veritabanını yöneteceğiz.

Adım 2: Mimariyi Güçlendirme (Repository Pattern & Dependency Injection)

Ne yapacağız: Controller'ların doğrudan veritabanı (AppDbContext) ile konuşmasını engelleyeceğiz. Araya "Repository" adında bir katman koyacağız.

Kazanım: Kod tekrarı azalacak. İleride MSSQL yerine başka bir veritabanına geçmek istersen sadece bu katmanı değiştirmen yetecek. Tam bir kurumsal mimari standardı.

Adım 3: Güvenli Veri Transferi ve Doğrulama (DTO & AutoMapper & FluentValidation)

Ne yapacağız: Veritabanı modellerimizi (Entity) doğrudan dış dünyaya (kullanıcıya) göstermeyeceğiz. Bunun yerine DTO (Data Transfer Object) sınıfları oluşturacağız. AutoMapper ile bunları eşleştirip, FluentValidation ile katı kurallar yazacağız (Örn: Forma numarası 0'dan küçük olamaz).

Kazanım: Gereksiz verilerin internette dolaşmasını engelleyip, API'nin güvenliğini ve hızını artıracağız.

Adım 4: Güvenlik Duvarı (Authentication & Authorization - JWT)

Ne yapacağız: Sisteme "Login" ve "Register" uç noktaları ekleyeceğiz. Başarılı giriş yapanlara bir JSON Web Token (JWT) vereceğiz.

Kazanım: API'ni sokaktan geçen herkes kullanamayacak. Sadece token'ı olanlar maç ekleyebilecek veya silebilecek. Hatta "Admin" ve "Standart Kullanıcı" rolleri belirleyeceğiz.

Adım 5: Kalite Güvencesi (Unit Testing)

Ne yapacağız: Yazdığımız kodları test eden başka kodlar (xUnit veya NUnit ile) yazacağız.

Kazanım: Projeye yeni bir özellik eklediğinde eski özelliklerin bozulup bozulmadığını tek tıkla göreceksin. Sektördeki en kritik mühendislik pratiklerinden biri.

Adım 6: Konteyner Mimarisi (Docker)

Ne yapacağız: Hazırladığımız bu .NET Core API'sini ve MSSQL veritabanını izole bir Docker ortamına alacağız.

Kazanım: Projeyi başka bir bilgisayara (veya sunucuya) taşıdığında "Benim bilgisayarımda çalışıyordu" bahanesini tamamen ortadan kaldıracak, tek bir docker-compose up komutuyla tüm sistemi ayağa kaldıracaksın.

Adım 7: İstemci Tarafı (Frontend / Arayüz Entegrasyonu)

Ne yapacağız: Sadece siyah ekranda ve JSON formatında duran bu sistemi görselleştireceğiz. React/Angular veya masaüstü teknolojileri kullanarak bir arayüz yazıp, verileri bu API'den çekeceğiz.

Kazanım: Artık arkada çalışan karmaşık mimariyi son kullanıcının tıklayabileceği bir ekrana bağlamış olacaksın. Tam teşekküllü, "Full-Stack" bir ürün ortaya çıkacak.