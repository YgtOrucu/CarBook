# 🚗 CarBook - Araç Kiralama ve Yönetim Sistemi

CarBook, modern web teknolojileri ve **Clean Architecture (Temiz Mimari)** ilkeleriyle geliştirilmiş, kapsamlı bir araç kiralama, blog ve yapay zeka entegre yönetim platformudur. Kullanıcılar sistem üzerinden araç kiralayabilir, blog yazgılarını inceleyip yorum yapabilir, admin ile iletişime geçebilir ve dahili **Yapay Zeka Asistanı** ile sohbet edebilirler.

---

## 📸 Ekran Görüntüleri (Screenshots)

<details>
<summary><b>👤 Kullanıcı Arayüzü (User Interface) - Görselleri Görmek İçin Tıklayın</b></summary>
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

## 🚀 Kullanılan Teknolojiler & Teknik Detaylar

- **Backend** — .NET / C# ile geliştirilmiş robust ve ölçeklenebilir altyapı.
- **ASP.NET Core Web API & MVC (WebUI)** — Sunucu tarafında servis yönetimi (API) ve kullanıcı etkileşimi için modern MVC mimarisi.
- **Entity Framework Core (ORM)** — Veritabanı işlemleri ve nesne-ilişkisel eşleme için güçlü ORM desteği.
- **CQRS (Command Query Responsibility Segregation)** — Okuma ve yazma işlemlerinin birbirinden ayrılarak performansın ve yönetilebilirliğin artırıldığı tasarım deseni.
- **MediatR Kütüphanesi** — Katmanlar arası gevşek bağlı (loosely coupled) iletişim ve CQRS handler'larının yönetimi.
- **Clean Architecture** — Bağımlılıkların dışarıdan içeriye doğru olduğu, sürdürülebilir ve test edilebilir katmanlı mimari prensibi.
- **FluentValidation & Custom Exception Handling** — Gelen verilerin güçlü kurallarla doğrulanması ve hataların özel middleware mekanizmalarıyla merkezi olarak yönetilmesi.

---

## 🚘 Öne Çıkan Özellikler

- **Araç Kiralama Modülü** — Gelişmiş araç listeleme, filtreleme ve esnek rezervasyon yönetimi.
- **Blog Sistemi** — Kullanıcıların blog yazılarını okuyabildiği, detay inceleyebildiği ve interaktif yorum yapabildiği alanlar.
- **İletişim & Destek** — Son kullanıcılar ile admin arasında güçlü mesajlaşma ve iletişim yönetimi.
- **Yapay Zeka Asistanı** — Kullanıcıların sistem içerisinde doğrudan etkileşime geçebileceği akıllı asistan modülü.
- **Kullanıcı Paneli** — Kullanıcıların kendi rezervasyonlarını, profillerini ve yaptıkları yorumları kolayca düzenleyebileceği yetkilendirilmiş güvenli alanlar.




