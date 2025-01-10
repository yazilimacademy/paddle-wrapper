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
    
    // Retry ayarları (opsiyonel)
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

### 3. Webhook İşlemleri

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

### 4. Hata Yönetimi

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

- **Retry Mekanizması**: Geçici hatalar için otomatik yeniden deneme
- **Circuit Breaker**: Ardışık hataları izleme ve sistemi koruma
- **Webhook Doğrulama**: HMAC-SHA256 ile webhook güvenliği
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