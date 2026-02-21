# Entity Framework Migration Komutları

Package Manager Console'da **"Could not load assembly 'HotelManagement.DataAccessLayer'"** veya **"Multiple startup projects set"** hatası alıyorsanız aşağıdakileri uygulayın.

---

## Önce mutlaka: Tek startup proje

PMC bu hatayı çoğu zaman **birden fazla startup proje** seçili olduğu için verir.

1. **Solution Explorer**'da solution'a (en üstteki satır) **sağ tıklayın**.
2. **Properties** seçin.
3. **Startup Project** bölümünde **"Single startup project"** işaretleyin.
4. Açılır listeden **HotelManagement.WebAPILayer** seçin.
5. Kaydedip kapatın.
6. **HotelManagement.WebAPILayer** projesine sağ tıklayıp **"Set as Startup Project"** ile de aynı sonucu alabilirsiniz.

Bundan sonra PMC'de:

- **Default project:** **HotelManagement.DataAccessLayer** seçin.
- Komut:  
  `Update-Database -StartupProject HotelManagement.WebAPILayer -Project HotelManagement.DataAccessLayer`

---

## Yöntem 1: Komut satırından (önerilen)

PMC hâlâ hata veriyorsa **Developer PowerShell / CMD veya Cursor terminalinde**:

```powershell
cd c:\Users\Tuna\Desktop\WebAPI-HotelManagementProject\APIConsume\HotelManagement.WebAPILayer
dotnet ef database update --project ..\HotelManagement.DataAccessLayer\HotelManagement.DataAccessLayer.csproj
```

Yeni migration eklemek için:

```powershell
dotnet ef migrations add MigrationAdi --project ..\HotelManagement.DataAccessLayer\HotelManagement.DataAccessLayer.csproj
```

*(Önce aynı `cd` ile WebAPILayer klasörüne gidin.)*

---

## Yöntem 2: Package Manager Console (tek startup ayarlandıktan sonra)

1. **Default project:** **HotelManagement.DataAccessLayer**.
2. **Build → Rebuild Solution**.
3. PMC'de:

```powershell
Update-Database -StartupProject HotelManagement.WebAPILayer -Project HotelManagement.DataAccessLayer
```

---

## Hata sürerse

- **Build** hata veriyorsa önce `dotnet build` ile projeyi derleyip hataları giderin.
- Connection string’in **HotelManagement.WebAPILayer** içindeki `appsettings.json` (veya `appsettings.Development.json`) dosyasında tanımlı olduğundan emin olun; EF migration çalışırken startup projesinin ayarlarını kullanır.
