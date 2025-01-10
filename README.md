# PaddleWrapper

PaddleWrapper, Paddle ödeme sistemi için .NET tabanlı bir istemci kütüphanesidir. Bu kütüphane, Paddle API'si ile kolay entegrasyon sağlar.

## Özellikler

- ✨ Paddle API 2.0 desteği
- 🚀 Async/await desteği
- 💉 .NET Core DI entegrasyonu
- 🔒 Tip güvenli modeller
- 📝 Kapsamlı dokümantasyon
- 🔄 Otomatik retry mekanizması
- 🛡️ Circuit breaker pattern
- 📡 Webhook desteği
- 🧪 Kapsamlı unit testler
- 🗜️ HTTP sıkıştırma desteği
- 💾 Cache mekanizması
- 🔍 Detaylı loglama
- 🌐 Çoklu para birimi desteği

## Desteklenen Servisler

- 📦 Ürün Yönetimi
- 💰 Fiyatlandırma
- 👥 Müşteri Yönetimi
- 📅 Abonelik Yönetimi
- 💳 Ödeme İşlemleri
- 🎫 İndirim Kodları
- 📊 Raporlama
- 📢 Bildirimler
- 📝 Ayarlamalar
- 🔔 Olay Takibi
- 📨 Webhook Yönetimi

## Kurulum

NuGet üzerinden paketi yükleyin:

```bash
dotnet add package PaddleWrapper.Core
```

## Kullanım

### 1. Servisleri Kaydetme

```csharp
services.AddPaddleServices(options =>
{
    options.ApiKey = "YOUR_API_KEY";
    options.VendorId = "YOUR_VENDOR_ID";
    options.WebhookSecret = "YOUR_WEBHOOK_SECRET";
    
    // HTTP sıkıştırma ayarları
    options.CompressionOptions.EnableRequestCompression = true;
    options.CompressionOptions.EnableResponseCompression = true;
    options.CompressionOptions.MinimumSizeToCompress = 1024;
    
    // Retry ayarları
    options.RetryOptions.MaxRetries = 3;
    options.RetryOptions.CircuitBreakerThreshold = 5;
    options.RetryOptions.CircuitBreakerDurationSeconds = 30;
});
```

### 2. Ürün İşlemleri

```csharp
public class ProductManager
{
    private readonly IProductService _productService;

    public ProductManager(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<Product> GetProductAsync(int productId)
    {
        var response = await _productService.GetProductAsync(productId);
        return response.Response;
    }

    public async Task<Product[]> ListProductsAsync()
    {
        var response = await _productService.ListProductsAsync();
        return response.Response;
    }
}
```

### 3. Müşteri İşlemleri

```csharp
public class CustomerManager
{
    private readonly ICustomerService _customerService;

    public CustomerManager(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public async Task<Customer> CreateCustomerAsync(Customer customer)
    {
        var response = await _customerService.CreateCustomerAsync(customer);
        return response.Response;
    }

    public async Task<Customer> UpdateCustomerAsync(string customerId, Customer customer)
    {
        var response = await _customerService.UpdateCustomerAsync(customerId, customer);
        return response.Response;
    }
}
```

### 4. Webhook İşlemleri

```csharp
public class CustomWebhookHandler : WebhookHandler
{
    public CustomWebhookHandler(IOptions<PaddleOptions> options)
        : base(options)
    {
    }

    protected override async Task HandlePaymentSucceededAsync(WebhookEvent webhookEvent)
    {
        // Başarılı ödeme işlemlerini burada yönetin
        var paymentData = webhookEvent.Data;
        await ProcessPaymentAsync(paymentData);
    }

    protected override async Task HandleSubscriptionCreatedAsync(WebhookEvent webhookEvent)
    {
        // Yeni abonelik işlemlerini burada yönetin
        var subscriptionData = webhookEvent.Data;
        await ProcessSubscriptionAsync(subscriptionData);
    }
}
```

### 5. Raporlama İşlemleri

```csharp
public class ReportManager
{
    private readonly IReportService _reportService;

    public ReportManager(IReportService reportService)
    {
        _reportService = reportService;
    }

    public async Task<Report> CreateRevenueReportAsync(DateTime startDate, DateTime endDate)
    {
        var response = await _reportService.CreateRevenueReportAsync(startDate, endDate, "day");
        return response.Response;
    }

    public async Task<byte[]> DownloadReportAsync(string reportId)
    {
        var response = await _reportService.DownloadReportAsync(reportId);
        return response.Response;
    }
}
```

### 6. Hata Yönetimi

```csharp
try
{
    var product = await _productService.GetProductAsync(123);
}
catch (PaddleAuthenticationException ex)
{
    // API kimlik doğrulama hatası
}
catch (PaddleValidationException ex)
{
    // İstek doğrulama hatası
}
catch (PaddleApiException ex)
{
    // Genel API hatası
    Console.WriteLine($"Error Code: {ex.ErrorCode}");
    Console.WriteLine($"Error Type: {ex.ErrorType}");
}
```

## Özellikler ve Limitler

- **HTTP Sıkıştırma**: GZIP ve Deflate desteği
- **Cache Mekanizması**: In-memory cache desteği
- **Retry Mekanizması**: Geçici hatalar için otomatik yeniden deneme
- **Circuit Breaker**: Ardışık hataları izleme ve sistemi koruma
- **Webhook Doğrulama**: HMAC-SHA256 ile webhook güvenliği
- **Bulk İşlemler**: Toplu işlem desteği
- **Loglama**: Detaylı hata ve işlem logları
- **Thread Safety**: Thread-safe implementasyon

## Katkıda Bulunma

1. Fork edin
2. Feature branch oluşturun (`git checkout -b feature/amazing-feature`)
3. Değişikliklerinizi commit edin (`git commit -m 'Add some amazing feature'`)
4. Branch'inizi push edin (`git push origin feature/amazing-feature`)
5. Pull Request oluşturun

## Test

Unit testleri çalıştırmak için:

```bash
dotnet test
```

## Lisans

MIT

## Destek

Sorunlarınız için GitHub Issues kullanabilir veya doğrudan iletişime geçebilirsiniz.