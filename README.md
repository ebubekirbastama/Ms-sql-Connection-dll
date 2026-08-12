# 🔌 Ms-sql-Connection-dll

**Baglantim**, C# uygulamalarında Microsoft SQL Server bağlantısını ve sık kullanılan veri erişim işlemlerini kolaylaştırmak amacıyla hazırlanmış yardımcı bir .NET Class Library'dir.

Proje; SQL Server bağlantısı açma, bağlantı kapatma, `DataTable` doldurma ve `SqlDataReader` üzerinden form kontrollerine veri aktarma gibi tekrar eden işlemleri tek bir sınıf altında toplamayı amaçlar. Projenin eski açıklama dosyası da bunun C# ile MS SQL bağlantıları ve stored procedure kullanımı için hazırlanmış bir yardımcı DLL olduğunu belirtmektedir. fileciteturn118file0turn120file0

## ✨ Özellikler

- 🔌 SQL Server bağlantısı oluşturma
- 🔐 Windows Integrated Security desteği
- 📊 SQL sorgusunu `DataTable` olarak alma
- 🖥️ `DataGridView` üzerine sorgu sonucunu aktarma
- 📖 `SqlDataReader` ile veri okuma
- 📝 Okunan verileri `TextBox` ve `ComboBox` kontrollerine aktarma
- 🏷️ Yetki bilgisini sorgudan alma
- 🧩 Diğer C# masaüstü projelerinde yeniden kullanılabilir DLL yapısı

Ana sınıf `Baglantim.Class1` içerisinde bu işlemler için yardımcı metotlar bulunmaktadır. fileciteturn120file0

## 🛠️ Teknolojiler

- **C#**
- **.NET Framework 3.5**
- **Class Library / DLL**
- **Microsoft SQL Server**
- **System.Data.SqlClient**
- **Windows Forms**
- **DevComponents DotNetBar**
- **Visual Studio / MSBuild**

Proje dosyası `Baglantim` assembly'sini bir **Class Library** olarak oluşturmakta ve **.NET Framework 3.5** hedeflemektedir. fileciteturn121file0

## 📂 Proje Yapısı

```text
Ms-sql-Connection-dll/
│
├── baglanti.sln
├── LICENSE
├── Beni oku.txt
│
└── Baglantim/
    ├── Baglantim.csproj
    ├── Class1.cs
    └── Properties/
        └── AssemblyInfo.cs
```

## 🔌 Bağlantı Yapısı

Kütüphane SQL Server bağlantı bilgilerini:

```text
C:\ayar.txt
```

dosyasının ilk satırından okumak üzere tasarlanmıştır.

Temel bağlantı yapısı Windows Authentication kullanır:

```text
Server=<SERVER>;
Integrated Security=true;
Database=<DATABASE>
```

Kaynak kodunda örnek veritabanı adı olarak `Uyelik_Basvuru_Kayit_Formu` ve bağlantı kapatma yardımcı metodunda `kutuphane` görülmektedir. Bu değerler sabit örneklerdir ve gerçek projelerde bağlantı bilgilerinin uygulama bazında yapılandırılması gerekir. fileciteturn120file0

## 📖 Kullanım

DLL'yi başka bir C# projesine referans olarak ekledikten sonra `Baglantim.Class1` sınıfı kullanılabilir.

Örneğin:

```csharp
var db = new Baglantim.Class1();
db.ayr();
```

Ardından SQL Server bağlantısı için:

```csharp
var connection = db.baglantim();
```

Sorgu sonucunu `DataGridView` içine almak için:

```csharp
var table = db.Tablo("SELECT * FROM tablo", dataGridView1);
```

`Reader1`, `Reader2`, `Reader3` ve `Reader4` metotları ise farklı UI kontrollerine sorgu sonuçlarını aktarmak için hazırlanmıştır. fileciteturn120file0

## 📊 Sağlanan Temel Metotlar

| Metot | Amaç |
|---|---|
| `ayr()` | `C:\ayar.txt` üzerinden SQL Server adını okur |
| `baglantim()` | SQL Server veritabanı bağlantısı açar |
| `baglantim_kapat()` | Bağlantıyı kapatma amacıyla kullanılır |
| `Tablo()` | SQL sonucunu `DataTable` ve `DataGridView` ile işler |
| `Reader1()` | Reader sonucunu ComboBox'a aktarır |
| `Reader2()` | Reader sonucunu TextBox/ComboBoxEx kontrollerine aktarır |
| `Reader3()` | Reader sonucunu üç TextBox'a aktarır |
| `Reader4()` | Sorgudan yetki bilgisini alır |

## ⚙️ Kurulum

### Gereksinimler

- Visual Studio
- .NET Framework 3.5 geliştirme/çalıştırma desteği
- Microsoft SQL Server
- `DevComponents.DotNetBar2` bağımlılığı

### 1. Repoyu klonlayın

```bash
git clone https://github.com/ebubekirbastama/Ms-sql-Connection-dll.git
cd Ms-sql-Connection-dll
```

### 2. Solution'ı açın

Visual Studio ile:

```text
baglanti.sln
```

dosyasını açın.

### 3. Bağımlılıkları kontrol edin

Proje `DevComponents.DotNetBar2` referansına sahiptir. Geliştirme ortamında bu bağımlılığın erişilebilir olması gerekir. fileciteturn121file0

### 4. DLL'yi derleyin

**Build Solution** işlemi sonucunda `Baglantim.dll` Class Library çıktısı oluşturulacaktır.

## 🔐 Güvenlik Notları

Bu proje eski bir veri erişim yardımcı kütüphanesidir. Güncel uygulamalarda aşağıdaki konular özellikle gözden geçirilmelidir:

- `C:\ayar.txt` yerine güvenli yapılandırma kullanın.
- SQL sorgularını doğrudan string birleştirme ile çalıştırmaktan kaçının.
- Kullanıcı girdilerinde SQL injection riskini önleyin.
- `SqlDataReader` ve `SqlConnection` nesnelerini `using` bloklarıyla güvenli şekilde yönetin.
- Güncel projelerde `Microsoft.Data.SqlClient` değerlendirin.
- Veritabanı kullanıcılarının minimum yetki prensibine göre yapılandırılmasını sağlayın.

> Özellikle bu kütüphane ham SQL cümlelerini parametre almadan çalıştıran metotlara sahip olduğu için, kullanıcı girdisinin doğrudan SQL cümlesine eklenmemesi önemlidir. fileciteturn120file0

## 🚧 Proje Durumu

Bu repository eski C# projelerinde tekrar kullanılmak üzere hazırlanmış bir yardımcı DLL örneğidir. Kaynak kodunun güncel .NET ekosistemine taşınması planlanıyorsa API tasarımı ve bağlantı yönetiminin modernize edilmesi önerilir.

Olası geliştirmeler:

- Modern .NET / .NET 8+ Class Library'ye geçiş
- `Microsoft.Data.SqlClient` kullanımı
- Dependency Injection desteği
- Async `OpenAsync` / `ExecuteReaderAsync` / `ExecuteNonQueryAsync` API'leri
- Parametreli sorgu yardımcıları
- `IDisposable` ve `using` tabanlı bağlantı yönetimi
- Connection string'in dış yapılandırmadan alınması
- NuGet paketi olarak dağıtım
- XML documentation ve örnek test projesi

## 📄 Lisans

Repository içerisinde `LICENSE` dosyası bulunmaktadır. Eski `Beni oku.txt` dosyasına göre proje **MIT lisansı** ile ücretsiz olarak dağıtılmaktadır. fileciteturn118file0

## 👨‍💻 Geliştirici

**Ebubekir Baştama**

GitHub: https://github.com/ebubekirbastama
