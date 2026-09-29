# 🚗 CarBook - Araç Kiralama ve Yönetim Sistemi

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet)
![C#](https://img.shields.io/badge/C%23-239120?logo=csharp&logoColor=white)
![EF Core](https://img.shields.io/badge/EF%20Core-8.0-512BD4)
![SQL Server](https://img.shields.io/badge/MSSQL-CC2927?logo=microsoftsqlserver&logoColor=white)
![JWT](https://img.shields.io/badge/Auth-JWT-000000?logo=jsonwebtokens)
![OpenAI](https://img.shields.io/badge/AI-OpenAI-412991?logo=openai&logoColor=white)
![Architecture](https://img.shields.io/badge/Architecture-Clean%20Architecture-blue)

CarBook, modern web teknolojileri ve **Clean Architecture (Temiz Mimari)** ilkeleriyle geliştirilmiş; araç kiralama, blog ve yapay zeka entegrasyonunu tek çatı altında toplayan kapsamlı bir yönetim platformudur.

Kullanıcılar sistem üzerinden araç kiralayabilir, blog yazılarını inceleyip yorum yapabilir, admin ile iletişime geçebilir ve **OpenAI destekli Yapay Zeka Asistanı** ile sohbet edebilir. Admin tarafında ise yapay zeka; rezervasyon onay mesajlarını ve iletişim mesajlarına verilecek cevapları otomatik olarak hazırlar.

---

## 📸 Ekran Görüntüleri (Screenshots)

<details>
<summary><b>👤 Kullanıcı Arayüzü (User Interface) - Login, Register ve Kullanıcı Sayfaları - Görselleri Görmek İçin Tıklayın</b></summary>
<br>

---

<img width="965" height="925" alt="image" src="https://github.com/user-attachments/assets/0a3849be-248b-4784-b260-88492fe0fcf9" />

---

<img width="657" height="704" alt="image" src="https://github.com/user-attachments/assets/480e760f-b2d3-4a0a-8db6-83ff4d29848e" />

---

<img width="1512" height="552" alt="image" src="https://github.com/user-attachments/assets/2ca40f93-547c-4e4e-a675-b586c06085b6" />

---

<img width="1155" height="938" alt="image" src="https://github.com/user-attachments/assets/daf75fff-05dc-476f-b1e4-0d5b7c285e6e" />

---

<img width="1128" height="874" alt="image" src="https://github.com/user-attachments/assets/d93179c1-8a73-441d-b12b-bc3fd60c17af" />

---

<img width="1226" height="573" alt="image" src="https://github.com/user-attachments/assets/ce75696b-59c3-4926-877f-074360506e00" />

---

<img width="1073" height="648" alt="image" src="https://github.com/user-attachments/assets/df8e08c6-1485-4973-943f-09c3753d2cd9" />

---

<img width="982" height="870" alt="image" src="https://github.com/user-attachments/assets/5a88c8ff-f903-4c9d-a171-89527c673482" />

---

<img width="1058" height="880" alt="image" src="https://github.com/user-attachments/assets/e53da04b-ee96-4e3a-af1c-9c3fbedc70d0" />

---

<img width="1284" height="916" alt="image" src="https://github.com/user-attachments/assets/7d975223-9f78-446f-b21a-ada90b5b1b80" />

---

<img width="1243" height="521" alt="image" src="https://github.com/user-attachments/assets/54ea85ed-edac-4598-9a4f-7d59c40ef979" />

---

<img width="905" height="690" alt="image" src="https://github.com/user-attachments/assets/786005bd-5300-4daf-b972-d5317d562913" />

---

<img width="741" height="669" alt="image" src="https://github.com/user-attachments/assets/cdeb630f-52df-466f-b36d-5c6a1cb87285" />

---

<img width="865" height="674" alt="image" src="https://github.com/user-attachments/assets/3c6004c7-a388-45da-a41d-db8db285fb5e" />

---

<img width="628" height="773" alt="image" src="https://github.com/user-attachments/assets/a37e068c-e8bd-42e9-9fc2-45dcb55d8a04" />

---

</details>

<details>
<summary><b>👨‍💼 Admin Paneli (Admin Interface) - Görselleri Görmek İçin Tıklayın</b></summary>
<br>

---

<img width="1896" height="462" alt="image" src="https://github.com/user-attachments/assets/cd6f1da9-382d-4a2f-ac33-923b40640e7c" />

---

<img width="1617" height="632" alt="image" src="https://github.com/user-attachments/assets/16c732a9-6702-42da-ae59-800dfbc894ca" />

---

<img width="1689" height="399" alt="image" src="https://github.com/user-attachments/assets/e1a04f18-4fc2-4246-9b42-0fe3b2fc3dd1" />

---

<img width="754" height="610" alt="image" src="https://github.com/user-attachments/assets/1fffd2f0-b79c-46ae-98a2-a44c61a0785b" />

</details>

---

## 🏗️ Proje Mimarisi (Solution Structure)

Proje, katmanlı mimarinin endişelerin ayrılması (separation of concerns) prensibine tam uygun olarak geliştirilmiştir:

```text
Solution 'CarBook'
│
├── Core
│   ├── CarBook.Application    # İş mantığı, CQRS Handlers, DTOs, Validations, Behaviors, Interfaces
│   └── CarBook.Domain         # Varlıklar (Entities) ve temel nesneler
│
├── Frontends
│   ├── CarBook.Dto            # Veri taşıma nesneleri (Data Transfer Objects)
│   └── CarBook.WebUI          # Kullanıcı Arayüzü (ASP.NET Core MVC / Razor Views)
│
├── Infrastructure
│   ├── CarBook.Infrastructure # Harici servisler, Repository implementasyonları, Options
│   └── CarBook.Persistence    # Veritabanı context, Migrations, Seeders ve Entity Configurations
│
└── Presentation
    └── CarBook.WebApi         # Web API katmanı (Endpoints, Controllers, Custom Middlewares)
```

---

## 🔀 Katmanlar Arası Bağımlılık

Bağımlılıklar her zaman **dıştan içe** doğrudur. `Domain` katmanı hiçbir katmana bağımlı değildir.

```mermaid
flowchart LR
    WebUI[CarBook.WebUI<br/>MVC] -->|HTTP + JWT| WebApi[CarBook.WebApi]
    WebUI --> Dto[CarBook.Dto]
    WebApi --> Application[CarBook.Application]
    WebApi --> Infrastructure[CarBook.Infrastructure]
    WebApi --> Persistence[CarBook.Persistence]
    Infrastructure --> Application
    Persistence --> Application
    Application --> Domain[CarBook.Domain]
    Persistence --> Domain

    style Domain fill:#512BD4,color:#fff
    style Application fill:#7B5CE0,color:#fff
```

---

## 🚀 Kullanılan Teknolojiler

| Alan | Teknoloji | Amaç |
|---|---|---|
| Platform | **.NET 8 / C#** | Ölçeklenebilir ve sürdürülebilir backend altyapısı |
| Web API | **ASP.NET Core Web API** | Servis katmanı ve endpoint yönetimi |
| Kullanıcı Arayüzü | **ASP.NET Core MVC (Razor Views)** | Kullanıcı ve admin arayüzleri |
| ORM | **Entity Framework Core 8** | Nesne-ilişkisel eşleme, migration yönetimi |
| Veritabanı | **Microsoft SQL Server (MSSQL)** | İlişkisel veri depolama |
| Tasarım Deseni | **CQRS + MediatR** | Okuma/yazma ayrımı, gevşek bağlı handler yapısı |
| Mimari | **Clean Architecture** | Test edilebilir, bağımlılığı yönetilen katmanlı yapı |
| Doğrulama | **FluentValidation** | Gelen verinin kurallarla doğrulanması |
| Hata Yönetimi | **Custom Exception Middleware** | Hataların merkezi olarak yönetilmesi |
| Kimlik Doğrulama | **JWT (JSON Web Token)** | Token tabanlı login ve claim bazlı yetkilendirme |
| Yapay Zeka | **OpenAI API** | Asistan sohbeti, otomatik mesaj ve cevap üretimi |
| E-posta | **SMTP (MailSettings)** | Sistem e-postaları |

---

## 🚘 Öne Çıkan Özellikler

### 🚗 Araç Kiralama Modülü
Gelişmiş araç listeleme, filtreleme ve esnek rezervasyon yönetimi. Kullanıcılar uygun araçları inceleyip rezervasyon oluşturabilir; admin rezervasyonları panelden yönetir.

### 📝 Blog Sistemi
Kullanıcıların blog yazılarını okuyabildiği, detay inceleyebildiği ve yorum yapabildiği interaktif alanlar.

### 📬 İletişim & Destek
Son kullanıcılar ile admin arasında mesajlaşma ve iletişim yönetimi. Admin, gelen mesajlara yapay zeka yardımıyla hazırlanan cevap metniyle hızlıca dönüş yapabilir.

### 🤖 Yapay Zeka Asistanı
Giriş yapan kullanıcıların sistem içerisinde doğrudan sohbet edebildiği, OpenAI destekli akıllı asistan modülü.

### 👤 Kullanıcı Paneli
Kullanıcıların kendi rezervasyonlarını, profillerini ve yaptıkları yorumları düzenleyebildiği, yetkilendirilmiş güvenli alanlar.

### 👨‍💼 Admin Paneli
Araç, rezervasyon, blog, yorum ve iletişim mesajlarının tek yerden yönetilmesi.

---

## 🔐 Kimlik Doğrulama Akışı

Sistem **JWT tabanlı** kimlik doğrulama kullanır:

1. Kullanıcı login olduğunda ilgili **CQRS Handler** içinde JWT token üretilir.
2. Kullanıcıya ait bazı bilgiler (kullanıcı adı, rol, id vb.) **claim** olarak token'a yüklenir.
3. `WebUI` tarafında, controller aşamasında token'a **ek claim'ler** dahil edilir.
4. Sonraki isteklerde token ile yetkilendirme yapılır.

---

## 🧠 Yapay Zeka Entegrasyonu

Projede **OpenAI API** üç farklı senaryoda kullanılır:

| Senaryo | Kullanıcı | Açıklama |
|---|---|---|
| **Rezervasyon onay mesajı** | Admin | Onaylanan rezervasyon için müşteriye gidecek mesaj otomatik üretilir |
| **İletişim mesajı cevabı** | Admin | Gelen iletişim mesajları için cevap metni taslağı hazırlanır |
| **Yapay Zeka Asistanı** | Giriş yapmış kullanıcı | Kullanıcı asistanla sohbet ederek soru sorabilir |

---

## 🛡️ Güvenlik Notları

- API anahtarları, connection string ve JWT ayarları **GitHub'a yüklenmez**; yerel geliştirmede `secrets.json` içinde tutulur.
- Canlı ortamda bu değerler **ortam değişkenleri (environment variables)** veya bir secret manager (Azure Key Vault vb.) ile sağlanmalıdır.
- Gelen tüm istekler **FluentValidation** ile doğrulanır.
- Hatalar, özel middleware ile merkezi olarak yakalanır ve istemciye güvenli biçimde döndürülür.

---

## 📬 İletişim

- **GitHub:** [Yiğit Örücü](https://github.com/YgtOrucu)
- **LinkedIn:** [Yiğit Örücü](https://www.linkedin.com/in/muhsin-yi%C4%9Fit-%C3%B6r%C3%BCc%C3%BC-09214911a/)
- **E-posta:** orucuyigit@gmail.com

> Projeyi beğendiysen ⭐ vermeyi unutma!
