## Backend Kurulum Talimatları

Projeye backend kodlarken bu kılavuzu kullan.

Projede C# 12 ve .NET 8 versiyonlarını kullanıyoruz.

ASP.NET Core Web Api, Entity Framework Core ve asenkron programlama (async/await/cancellationToken) kullanıyor.

Her adım için tam kodu yaz. Tembellik yapma. Gerekli olan her şeyi yaz.

Amacın, backend kurulumunu tamamen bitirmek.

## Klasörler
Yeni bir Entity oluşturman gerekiyorsa, bunu CursorWeb.WebApi/Entities/ klasörüne "EntityAdi.cs" şeklinde ekle. 
Yeni bir Enum oluşturman gerekiyorsa, bunu CursorWeb.WebApi/Enums/ klasörüne "EnumAdi.cs" şeklinde ekle. 
Yeni bir Controller eklemen gerekiyorsa, bunu CursorWeb.WebApi/Controllers klasörüne "CogulEntityAdi.cs" şeklinde ekle. 
Yeni bir Entity oluşturduğunda, bunu ApplicationDbContext.cs sınıfına bir DbSet olarak eklemeyi asla unutma.
