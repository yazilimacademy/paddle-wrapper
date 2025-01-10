# Paddle API Modelleri

## Ürün (Product)

```csharp
public class Product
{
    /// <summary>
    /// Ürünün benzersiz Paddle ID'si (pro_ öneki ile)
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Ürün adı (1-200 karakter)
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Vergi kategorisi (standard, digital, physical)
    /// </summary>
    public string TaxCategory { get; set; }

    /// <summary>
    /// Ürün tipi (standard, custom)
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// Ürün açıklaması (max 2048 karakter)
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Ürün görseli URL'i
    /// </summary>
    public string ImageUrl { get; set; }

    /// <summary>
    /// Özel veri alanı (JSON formatında)
    /// </summary>
    public object CustomData { get; set; }

    /// <summary>
    /// Ürün durumu (active, archived)
    /// </summary>
    public string Status { get; set; }

    /// <summary>
    /// İçe aktarma meta verileri
    /// </summary>
    public object ImportMeta { get; set; }

    /// <summary>
    /// Oluşturulma tarihi
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Son güncelleme tarihi
    /// </summary>
    public DateTime UpdatedAt { get; set; }
}

/// <summary>
/// Ürün oluşturma isteği modeli
/// </summary>
public class CreateProductRequest
{
    /// <summary>
    /// Ürün adı (required, 1-200 karakter)
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Vergi kategorisi (required)
    /// </summary>
    public string TaxCategory { get; set; }

    /// <summary>
    /// Ürün açıklaması (optional, max 2048 karakter)
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Ürün görseli URL'i (optional)
    /// </summary>
    public string ImageUrl { get; set; }

    /// <summary>
    /// Özel veri alanı (optional, JSON formatında)
    /// </summary>
    public object CustomData { get; set; }
}
```

## Müşteri (Customer)

```csharp
/// <summary>
/// Müşteri varlığını temsil eder
/// </summary>
public class Customer
{
    /// <summary>
    /// Müşterinin benzersiz Paddle ID'si (ctm_ öneki ile)
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Müşterinin tam adı
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Müşterinin e-posta adresi
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Müşterinin pazarlama iletişimine izin verip vermediği
    /// </summary>
    public bool MarketingConsent { get; set; }

    /// <summary>
    /// Müşterinin durumu (active, archived)
    /// </summary>
    public string Status { get; set; }

    /// <summary>
    /// Özel veri alanı (JSON formatında)
    /// </summary>
    public object CustomData { get; set; }

    /// <summary>
    /// Müşterinin dil tercihi (IETF BCP 47 formatında)
    /// </summary>
    public string Locale { get; set; }

    /// <summary>
    /// Oluşturulma tarihi
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Son güncelleme tarihi
    /// </summary>
    public DateTime UpdatedAt { get; set; }

    /// <summary>
    /// İçe aktarma meta verileri
    /// </summary>
    public object ImportMeta { get; set; }
}

/// <summary>
/// Müşteri oluşturma isteği modeli
/// </summary>
public class CreateCustomerRequest
{
    /// <summary>
    /// Müşterinin e-posta adresi (required)
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Müşterinin tam adı (optional)
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Müşterinin dil tercihi (optional, default: en)
    /// </summary>
    public string Locale { get; set; }

    /// <summary>
    /// Özel veri alanı (optional, JSON formatında)
    /// </summary>
    public object CustomData { get; set; }
}

/// <summary>
/// Müşteri işletmesi modeli
/// </summary>
public class Business
{
    /// <summary>
    /// İşletmenin benzersiz Paddle ID'si (biz_ öneki ile)
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// İşletmenin bağlı olduğu müşteri ID'si
    /// </summary>
    public string CustomerId { get; set; }

    /// <summary>
    /// İşletme adı
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// İşletme durumu (active, archived)
    /// </summary>
    public string Status { get; set; }

    /// <summary>
    /// Şirket numarası
    /// </summary>
    public string CompanyNumber { get; set; }

    /// <summary>
    /// Vergi numarası
    /// </summary>
    public string TaxIdentifier { get; set; }

    /// <summary>
    /// İşletme iletişim kişileri
    /// </summary>
    public List<BusinessContact> Contacts { get; set; }

    /// <summary>
    /// Özel veri alanı (JSON formatında)
    /// </summary>
    public object CustomData { get; set; }

    /// <summary>
    /// Oluşturulma tarihi
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Son güncelleme tarihi
    /// </summary>
    public DateTime UpdatedAt { get; set; }

    /// <summary>
    /// İçe aktarma meta verileri
    /// </summary>
    public object ImportMeta { get; set; }
}

/// <summary>
/// İşletme iletişim kişisi modeli
/// </summary>
public class BusinessContact
{
    /// <summary>
    /// İletişim kişisinin tam adı
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// İletişim kişisinin e-posta adresi
    /// </summary>
    public string Email { get; set; }
}
```

## Meta Bilgileri (Meta)

```csharp
public class Meta
{
    /// <summary>
    /// İstek ID'si
    /// </summary>
    public string RequestId { get; set; }

    /// <summary>
    /// Sayfalama bilgileri
    /// </summary>
    public Pagination Pagination { get; set; }
}

public class Pagination
{
    /// <summary>
    /// Sayfa başına sonuç sayısı
    /// </summary>
    public int PerPage { get; set; }

    /// <summary>
    /// Sonraki sayfa için URL
    /// </summary>
    public string Next { get; set; }

    /// <summary>
    /// Daha fazla sonuç olup olmadığı
    /// </summary>
    public bool HasMore { get; set; }

    /// <summary>
    /// Tahmini toplam sonuç sayısı
    /// </summary>
    public int EstimatedTotal { get; set; }
}
```

## Liste Yanıtı (ListResponse)

```csharp
/// <summary>
/// Liste yanıtı için genel model
/// </summary>
public class ListResponse<T>
{
    /// <summary>
    /// Sonuç listesi
    /// </summary>
    public List<T> Data { get; set; }

    /// <summary>
    /// Meta bilgileri
    /// </summary>
    public Meta Meta { get; set; }
}
```

## Abonelik (Subscription)

```csharp
/// <summary>
/// Abonelik varlığını temsil eder
/// </summary>
public class Subscription
{
    /// <summary>
    /// Aboneliğin benzersiz Paddle ID'si (sub_ öneki ile)
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Aboneliğin durumu
    /// </summary>
    public string Status { get; set; }

    /// <summary>
    /// Aboneliğin bağlı olduğu müşteri ID'si
    /// </summary>
    public string CustomerId { get; set; }

    /// <summary>
    /// Aboneliğin bağlı olduğu adres ID'si
    /// </summary>
    public string AddressId { get; set; }

    /// <summary>
    /// Aboneliğin bağlı olduğu işletme ID'si (opsiyonel)
    /// </summary>
    public string BusinessId { get; set; }

    /// <summary>
    /// Aboneliğin para birimi
    /// </summary>
    public string CurrencyCode { get; set; }

    /// <summary>
    /// Aboneliğin başlangıç tarihi
    /// </summary>
    public DateTime StartedAt { get; set; }

    /// <summary>
    /// İlk faturalandırma tarihi
    /// </summary>
    public DateTime? FirstBilledAt { get; set; }

    /// <summary>
    /// Bir sonraki faturalandırma tarihi
    /// </summary>
    public DateTime? NextBilledAt { get; set; }

    /// <summary>
    /// Duraklatma tarihi
    /// </summary>
    public DateTime? PausedAt { get; set; }

    /// <summary>
    /// İptal tarihi
    /// </summary>
    public DateTime? CanceledAt { get; set; }

    /// <summary>
    /// Tahsilat modu (automatic/manual)
    /// </summary>
    public string CollectionMode { get; set; }

    /// <summary>
    /// Faturalandırma detayları
    /// </summary>
    public BillingDetails BillingDetails { get; set; }

    /// <summary>
    /// Faturalandırma döngüsü
    /// </summary>
    public BillingCycle BillingCycle { get; set; }

    /// <summary>
    /// Planlanan değişiklik
    /// </summary>
    public ScheduledChange ScheduledChange { get; set; }

    /// <summary>
    /// Abonelik kalemleri
    /// </summary>
    public List<SubscriptionItem> Items { get; set; }

    /// <summary>
    /// Özel veri alanı (JSON formatında)
    /// </summary>
    public object CustomData { get; set; }

    /// <summary>
    /// Oluşturulma tarihi
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Son güncelleme tarihi
    /// </summary>
    public DateTime UpdatedAt { get; set; }
}

/// <summary>
/// Abonelik kalemi modeli
/// </summary>
public class SubscriptionItem
{
    /// <summary>
    /// Fiyat bilgileri
    /// </summary>
    public Price Price { get; set; }

    /// <summary>
    /// Miktar
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Tekrarlayan kalem mi?
    /// </summary>
    public bool Recurring { get; set; }

    /// <summary>
    /// Deneme süresi tarihleri
    /// </summary>
    public TrialDates TrialDates { get; set; }

    /// <summary>
    /// Bir sonraki faturalandırma tarihi
    /// </summary>
    public DateTime? NextBilledAt { get; set; }

    /// <summary>
    /// Son faturalandırma tarihi
    /// </summary>
    public DateTime? PreviouslyBilledAt { get; set; }
}

/// <summary>
/// Faturalandırma döngüsü modeli
/// </summary>
public class BillingCycle
{
    /// <summary>
    /// Döngü aralığı (day/week/month/year)
    /// </summary>
    public string Interval { get; set; }

    /// <summary>
    /// Döngü frekansı
    /// </summary>
    public int Frequency { get; set; }
}

/// <summary>
/// Planlanan değişiklik modeli
/// </summary>
public class ScheduledChange
{
    /// <summary>
    /// Değişiklik aksiyonu (cancel/pause/resume)
    /// </summary>
    public string Action { get; set; }

    /// <summary>
    /// Değişikliğin geçerli olacağı tarih
    /// </summary>
    public DateTime EffectiveAt { get; set; }

    /// <summary>
    /// Değişikliğin kaynağı
    /// </summary>
    public string Origin { get; set; }
}

/// <summary>
/// Deneme süresi tarihleri modeli
/// </summary>
public class TrialDates
{
    /// <summary>
    /// Deneme süresinin başlangıç tarihi
    /// </summary>
    public DateTime StartsAt { get; set; }

    /// <summary>
    /// Deneme süresinin bitiş tarihi
    /// </summary>
    public DateTime EndsAt { get; set; }
}

## Fiyat (Price)

```csharp
/// <summary>
/// Fiyat varlığını temsil eder
/// </summary>
public class Price
{
    /// <summary>
    /// Fiyatın benzersiz Paddle ID'si (pri_ öneki ile)
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Fiyatın bağlı olduğu ürün ID'si
    /// </summary>
    public string ProductId { get; set; }

    /// <summary>
    /// Fiyat tipi (standard/custom)
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// Fiyat açıklaması (2-200 karakter)
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Fiyat adı (1-50 karakter)
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Faturalandırma döngüsü
    /// </summary>
    public BillingCycle BillingCycle { get; set; }

    /// <summary>
    /// Deneme süresi
    /// </summary>
    public TrialPeriod TrialPeriod { get; set; }

    /// <summary>
    /// Vergi hesaplama modu
    /// </summary>
    public string TaxMode { get; set; }

    /// <summary>
    /// Birim fiyat
    /// </summary>
    public Money UnitPrice { get; set; }

    /// <summary>
    /// Ülkeye özel fiyat tanımları
    /// </summary>
    public List<UnitPriceOverride> UnitPriceOverrides { get; set; }

    /// <summary>
    /// Özel veri alanı (JSON formatında)
    /// </summary>
    public object CustomData { get; set; }

    /// <summary>
    /// Fiyat durumu (active/archived)
    /// </summary>
    public string Status { get; set; }

    /// <summary>
    /// Miktar sınırları
    /// </summary>
    public PriceQuantity Quantity { get; set; }

    /// <summary>
    /// İçe aktarma meta verileri
    /// </summary>
    public object ImportMeta { get; set; }

    /// <summary>
    /// Oluşturulma tarihi
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Son güncelleme tarihi
    /// </summary>
    public DateTime UpdatedAt { get; set; }
}

/// <summary>
/// Faturalandırma döngüsü
/// </summary>
public class BillingCycle
{
    /// <summary>
    /// Döngü aralığı (day/week/month/year)
    /// </summary>
    public string Interval { get; set; }

    /// <summary>
    /// Döngü frekansı
    /// </summary>
    public int Frequency { get; set; }
}

/// <summary>
/// Deneme süresi
/// </summary>
public class TrialPeriod
{
    /// <summary>
    /// Döngü aralığı (day/week/month/year)
    /// </summary>
    public string Interval { get; set; }

    /// <summary>
    /// Döngü frekansı
    /// </summary>
    public int Frequency { get; set; }
}

/// <summary>
/// Para birimi ve tutar
/// </summary>
public class Money
{
    /// <summary>
    /// Tutar (string olarak)
    /// </summary>
    public string Amount { get; set; }

    /// <summary>
    /// Para birimi
    /// </summary>
    public string CurrencyCode { get; set; }
}

/// <summary>
/// Ülkeye özel fiyat tanımı
/// </summary>
public class UnitPriceOverride
{
    /// <summary>
    /// Ülke kodları listesi
    /// </summary>
    public List<string> CountryCodes { get; set; }

    /// <summary>
    /// Özel fiyat
    /// </summary>
    public Money UnitPrice { get; set; }
}

/// <summary>
/// Miktar sınırları
/// </summary>
public class PriceQuantity
{
    /// <summary>
    /// Minimum miktar
    /// </summary>
    public int Minimum { get; set; }

    /// <summary>
    /// Maksimum miktar
    /// </summary>
    public int Maximum { get; set; }
}

/// <summary>
/// Fiyat önizleme isteği
/// </summary>
public class PricePreviewRequest
{
    /// <summary>
    /// Fiyat kalemleri
    /// </summary>
    public List<PricePreviewItem> Items { get; set; }

    /// <summary>
    /// Para birimi
    /// </summary>
    public string CurrencyCode { get; set; }

    /// <summary>
    /// Adres bilgileri
    /// </summary>
    public Address Address { get; set; }

    /// <summary>
    /// İndirim ID'si
    /// </summary>
    public string DiscountId { get; set; }

    /// <summary>
    /// Müşteri IP adresi
    /// </summary>
    public string CustomerIpAddress { get; set; }
}

/// <summary>
/// Fiyat önizleme kalemi
/// </summary>
public class PricePreviewItem
{
    /// <summary>
    /// Fiyat ID'si
    /// </summary>
    public string PriceId { get; set; }

    /// <summary>
    /// Miktar
    /// </summary>
    public int Quantity { get; set; }
}

/// <summary>
/// Fiyat önizleme yanıtı
/// </summary>
public class PricePreviewResponse
{
    /// <summary>
    /// Kalem bazında hesaplamalar
    /// </summary>
    public List<PricePreviewItemDetails> Items { get; set; }

    /// <summary>
    /// Genel toplamlar
    /// </summary>
    public Totals Totals { get; set; }

    /// <summary>
    /// Kullanılan vergi oranları
    /// </summary>
    public List<TaxRate> TaxRatesUsed { get; set; }
}

/// <summary>
/// Fiyat önizleme kalem detayları
/// </summary>
public class PricePreviewItemDetails
{
    /// <summary>
    /// Kalem ID'si
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Kalem toplamları
    /// </summary>
    public Totals Totals { get; set; }

    /// <summary>
    /// Ürün bilgileri
    /// </summary>
    public Product Product { get; set; }

    /// <summary>
    /// Fiyat ID'si
    /// </summary>
    public string PriceId { get; set; }

    /// <summary>
    /// Miktar
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Vergi oranı
    /// </summary>
    public string TaxRate { get; set; }

    /// <summary>
    /// Birim toplamları
    /// </summary>
    public Totals UnitTotals { get; set; }
}

/// <summary>
/// Toplamlar
/// </summary>
public class Totals
{
    /// <summary>
    /// Vergi tutarı
    /// </summary>
    public string Tax { get; set; }

    /// <summary>
    /// Toplam tutar
    /// </summary>
    public string Total { get; set; }

    /// <summary>
    /// İndirim tutarı
    /// </summary>
    public string Discount { get; set; }

    /// <summary>
    /// Ara toplam
    /// </summary>
    public string Subtotal { get; set; }
}

/// <summary>
/// Vergi oranı
/// </summary>
public class TaxRate
{
    /// <summary>
    /// Vergi oranı toplamları
    /// </summary>
    public Totals Totals { get; set; }

    /// <summary>
    /// Vergi oranı
    /// </summary>
    public string Rate { get; set; }
}

## İşlem (Transaction)

```csharp
/// <summary>
/// İşlem varlığını temsil eder
/// </summary>
public class Transaction
{
    /// <summary>
    /// İşlemin benzersiz Paddle ID'si (txn_ öneki ile)
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// İşlem durumu
    /// </summary>
    public string Status { get; set; }

    /// <summary>
    /// İşlemin bağlı olduğu müşteri ID'si
    /// </summary>
    public string CustomerId { get; set; }

    /// <summary>
    /// İşlemin bağlı olduğu adres ID'si
    /// </summary>
    public string AddressId { get; set; }

    /// <summary>
    /// İşlemin bağlı olduğu işletme ID'si
    /// </summary>
    public string BusinessId { get; set; }

    /// <summary>
    /// İşlemin bağlı olduğu abonelik ID'si
    /// </summary>
    public string SubscriptionId { get; set; }

    /// <summary>
    /// İşlemin bağlı olduğu fatura ID'si
    /// </summary>
    public string InvoiceId { get; set; }

    /// <summary>
    /// Fatura numarası
    /// </summary>
    public string InvoiceNumber { get; set; }

    /// <summary>
    /// İşlemin para birimi
    /// </summary>
    public string CurrencyCode { get; set; }

    /// <summary>
    /// İşlemin kaynağı
    /// </summary>
    public string Origin { get; set; }

    /// <summary>
    /// Tahsilat modu (automatic/manual)
    /// </summary>
    public string CollectionMode { get; set; }

    /// <summary>
    /// İndirim ID'si
    /// </summary>
    public string DiscountId { get; set; }

    /// <summary>
    /// Faturalandırma detayları
    /// </summary>
    public BillingDetails BillingDetails { get; set; }

    /// <summary>
    /// Faturalandırma dönemi
    /// </summary>
    public BillingPeriod BillingPeriod { get; set; }

    /// <summary>
    /// İşlem kalemleri
    /// </summary>
    public List<TransactionItem> Items { get; set; }

    /// <summary>
    /// İşlem detayları
    /// </summary>
    public TransactionDetails Details { get; set; }

    /// <summary>
    /// Ödeme denemeleri
    /// </summary>
    public List<PaymentAttempt> Payments { get; set; }

    /// <summary>
    /// Checkout bilgileri
    /// </summary>
    public TransactionCheckout Checkout { get; set; }

    /// <summary>
    /// Özel veri alanı (JSON formatında)
    /// </summary>
    public object CustomData { get; set; }

    /// <summary>
    /// Oluşturulma tarihi
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Son güncelleme tarihi
    /// </summary>
    public DateTime UpdatedAt { get; set; }
}

/// <summary>
/// İşlem kalemi
/// </summary>
public class TransactionItem
{
    /// <summary>
    /// Fiyat bilgileri
    /// </summary>
    public Price Price { get; set; }

    /// <summary>
    /// Miktar
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Orantılama bilgileri
    /// </summary>
    public Proration Proration { get; set; }
}

/// <summary>
/// İşlem detayları
/// </summary>
public class TransactionDetails
{
    /// <summary>
    /// Kalem bazında hesaplamalar
    /// </summary>
    public List<TransactionLineItem> LineItems { get; set; }

    /// <summary>
    /// Genel toplamlar
    /// </summary>
    public TransactionTotals Totals { get; set; }

    /// <summary>
    /// Ödeme toplamları
    /// </summary>
    public PayoutTotals PayoutTotals { get; set; }

    /// <summary>
    /// Kullanılan vergi oranları
    /// </summary>
    public List<TaxRateUsed> TaxRatesUsed { get; set; }

    /// <summary>
    /// Düzeltilmiş toplamlar
    /// </summary>
    public AdjustedTotals AdjustedTotals { get; set; }
}

/// <summary>
/// İşlem satırı
/// </summary>
public class TransactionLineItem
{
    /// <summary>
    /// Satır ID'si
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Satır toplamları
    /// </summary>
    public Totals Totals { get; set; }

    /// <summary>
    /// Ürün bilgileri
    /// </summary>
    public Product Product { get; set; }

    /// <summary>
    /// Fiyat ID'si
    /// </summary>
    public string PriceId { get; set; }

    /// <summary>
    /// Miktar
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Vergi oranı
    /// </summary>
    public string TaxRate { get; set; }

    /// <summary>
    /// Birim toplamları
    /// </summary>
    public Totals UnitTotals { get; set; }
}

/// <summary>
/// İşlem toplamları
/// </summary>
public class TransactionTotals : Totals
{
    /// <summary>
    /// Uygulanan kredi tutarı
    /// </summary>
    public string Credit { get; set; }

    /// <summary>
    /// Bakiyeye aktarılan kredi tutarı
    /// </summary>
    public string CreditToBalance { get; set; }

    /// <summary>
    /// Kalan bakiye
    /// </summary>
    public string Balance { get; set; }
}

/// <summary>
/// Ödeme denemesi
/// </summary>
public class PaymentAttempt
{
    /// <summary>
    /// Ödeme tutarı
    /// </summary>
    public string Amount { get; set; }

    /// <summary>
    /// Ödeme durumu
    /// </summary>
    public string Status { get; set; }

    /// <summary>
    /// Oluşturulma tarihi
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Hata kodu
    /// </summary>
    public string ErrorCode { get; set; }

    /// <summary>
    /// Tahsilat tarihi
    /// </summary>
    public DateTime? CapturedAt { get; set; }

    /// <summary>
    /// Ödeme yöntemi detayları
    /// </summary>
    public PaymentMethodDetails MethodDetails { get; set; }
}

/// <summary>
/// Ödeme yöntemi detayları
/// </summary>
public class PaymentMethodDetails
{
    /// <summary>
    /// Kart bilgileri
    /// </summary>
    public CardDetails Card { get; set; }

    /// <summary>
    /// Ödeme yöntemi tipi
    /// </summary>
    public string Type { get; set; }
}

/// <summary>
/// Kart detayları
/// </summary>
public class CardDetails
{
    /// <summary>
    /// Kart tipi
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// Son 4 hane
    /// </summary>
    public string Last4 { get; set; }

    /// <summary>
    /// Son kullanma yılı
    /// </summary>
    public int ExpiryYear { get; set; }

    /// <summary>
    /// Son kullanma ayı
    /// </summary>
    public int ExpiryMonth { get; set; }

    /// <summary>
    /// Kart sahibinin adı
    /// </summary>
    public string CardholderName { get; set; }
}

/// <summary>
/// İşlem checkout bilgileri
/// </summary>
public class TransactionCheckout
{
    /// <summary>
    /// Checkout URL'i
    /// </summary>
    public string Url { get; set; }
}

## İndirim (Discount)

```csharp
/// <summary>
/// İndirim varlığını temsil eder
/// </summary>
public class Discount
{
    /// <summary>
    /// İndirimin benzersiz Paddle ID'si (dsc_ öneki ile)
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// İndirim durumu (active/archived)
    /// </summary>
    public string Status { get; set; }

    /// <summary>
    /// İndirim açıklaması (1-254 karakter)
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Checkout'ta kullanılabilir mi?
    /// </summary>
    public bool EnabledForCheckout { get; set; }

    /// <summary>
    /// İndirim kodu (1-32 karakter, sadece harf ve rakam)
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// İndirim tipi (flat/flat_per_seat/percentage)
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// İndirim tutarı (percentage için 0.01-100 arası, diğerleri için en küçük para birimi cinsinden)
    /// </summary>
    public string Amount { get; set; }

    /// <summary>
    /// Para birimi (flat ve flat_per_seat için gerekli)
    /// </summary>
    public string CurrencyCode { get; set; }

    /// <summary>
    /// Tekrarlayan ödemelere uygulanacak mı?
    /// </summary>
    public bool Recur { get; set; }

    /// <summary>
    /// Maksimum tekrar sayısı
    /// </summary>
    public int? MaximumRecurringIntervals { get; set; }

    /// <summary>
    /// Maksimum kullanım sayısı
    /// </summary>
    public int? UsageLimit { get; set; }

    /// <summary>
    /// Kullanım sayısı
    /// </summary>
    public int TimesUsed { get; set; }

    /// <summary>
    /// Ürün veya fiyat ID'leri listesi
    /// </summary>
    public List<string> RestrictTo { get; set; }

    /// <summary>
    /// Son kullanma tarihi
    /// </summary>
    public DateTime? ExpiresAt { get; set; }

    /// <summary>
    /// Özel veri alanı (JSON formatında)
    /// </summary>
    public object CustomData { get; set; }

    /// <summary>
    /// İçe aktarma meta verileri
    /// </summary>
    public object ImportMeta { get; set; }

    /// <summary>
    /// Oluşturulma tarihi
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Son güncelleme tarihi
    /// </summary>
    public DateTime UpdatedAt { get; set; }
}

/// <summary>
/// İndirim oluşturma isteği modeli
/// </summary>
public class CreateDiscountRequest
{
    /// <summary>
    /// İndirim açıklaması (required, 1-254 karakter)
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Checkout'ta kullanılabilir mi? (optional, default: true)
    /// </summary>
    public bool? EnabledForCheckout { get; set; }

    /// <summary>
    /// İndirim kodu (required, 1-32 karakter, sadece harf ve rakam)
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// İndirim tipi (required, flat/flat_per_seat/percentage)
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// İndirim tutarı (required)
    /// </summary>
    public string Amount { get; set; }

    /// <summary>
    /// Para birimi (flat ve flat_per_seat için required)
    /// </summary>
    public string CurrencyCode { get; set; }

    /// <summary>
    /// Tekrarlayan ödemelere uygulanacak mı? (optional, default: false)
    /// </summary>
    public bool? Recur { get; set; }

    /// <summary>
    /// Maksimum tekrar sayısı (optional)
    /// </summary>
    public int? MaximumRecurringIntervals { get; set; }

    /// <summary>
    /// Maksimum kullanım sayısı (optional)
    /// </summary>
    public int? UsageLimit { get; set; }

    /// <summary>
    /// Ürün veya fiyat ID'leri listesi (optional)
    /// </summary>
    public List<string> RestrictTo { get; set; }

    /// <summary>
    /// Son kullanma tarihi (optional)
    /// </summary>
    public DateTime? ExpiresAt { get; set; }
}

/// <summary>
/// İndirim güncelleme isteği modeli
/// </summary>
public class UpdateDiscountRequest
{
    /// <summary>
    /// İndirim açıklaması (optional)
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Checkout'ta kullanılabilir mi? (optional)
    /// </summary>
    public bool? EnabledForCheckout { get; set; }

    /// <summary>
    /// İndirim kodu (optional)
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// İndirim durumu (optional)
    /// </summary>
    public string Status { get; set; }

    /// <summary>
    /// Ürün veya fiyat ID'leri listesi (optional)
    /// </summary>
    public List<string> RestrictTo { get; set; }

    /// <summary>
    /// Son kullanma tarihi (optional)
    /// </summary>
    public DateTime? ExpiresAt { get; set; }

    /// <summary>
    /// Özel veri alanı (optional, JSON formatında)
    /// </summary>
    public object CustomData { get; set; }
}

## Bildirim (Notification)

```csharp
/// <summary>
/// Bildirim varlığını temsil eder
/// </summary>
public class Notification
{
    /// <summary>
    /// Bildirimin benzersiz Paddle ID'si (ntf_ öneki ile)
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Bildirim tipi (örn. transaction.created, subscription.updated)
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// Bildirim durumu (delivered/failed)
    /// </summary>
    public string Status { get; set; }

    /// <summary>
    /// Bildirim içeriği (JSON formatında)
    /// </summary>
    public object Payload { get; set; }

    /// <summary>
    /// Bildirimin bağlı olduğu olay ID'si
    /// </summary>
    public string EventId { get; set; }

    /// <summary>
    /// Bildirimin gönderildiği bildirim ayarı ID'si
    /// </summary>
    public string NotificationSettingId { get; set; }

    /// <summary>
    /// Oluşturulma tarihi
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Son güncelleme tarihi
    /// </summary>
    public DateTime UpdatedAt { get; set; }
}

/// <summary>
/// Bildirim kaydı varlığını temsil eder
/// </summary>
public class NotificationLog
{
    /// <summary>
    /// Bildirim kaydının benzersiz Paddle ID'si (ntflog_ öneki ile)
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Sunucudan alınan HTTP yanıt kodu
    /// </summary>
    public int ResponseCode { get; set; }

    /// <summary>
    /// Sunucudan alınan yanıt içerik tipi
    /// </summary>
    public string ResponseContentType { get; set; }

    /// <summary>
    /// Sunucudan alınan yanıt gövdesi
    /// </summary>
    public string ResponseBody { get; set; }

    /// <summary>
    /// Gönderim denemesi tarihi
    /// </summary>
    public DateTime AttemptedAt { get; set; }
}

/// <summary>
/// Bildirim ayarı varlığını temsil eder
/// </summary>
public class NotificationSetting
{
    /// <summary>
    /// Bildirim ayarının benzersiz Paddle ID'si (ntfset_ öneki ile)
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Bildirim ayarı açıklaması (1-256 karakter)
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Bildirim tipi (email/url)
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// Webhook URL'i veya e-posta adresi
    /// </summary>
    public string Destination { get; set; }

    /// <summary>
    /// Bildirim ayarı aktif mi?
    /// </summary>
    public bool Active { get; set; }

    /// <summary>
    /// API versiyonu
    /// </summary>
    public int ApiVersion { get; set; }

    /// <summary>
    /// Hassas alanlar dahil edilsin mi?
    /// </summary>
    public bool IncludeSensitiveFields { get; set; }

    /// <summary>
    /// Abone olunan olay tipleri listesi
    /// </summary>
    public List<EventType> SubscribedEvents { get; set; }

    /// <summary>
    /// Webhook endpoint gizli anahtarı (pdl_ntfset_ öneki ile)
    /// </summary>
    public string EndpointSecretKey { get; set; }

    /// <summary>
    /// Trafik kaynağı (platform/simulation/all)
    /// </summary>
    public string TrafficSource { get; set; }
}

/// <summary>
/// Olay tipi varlığını temsil eder
/// </summary>
public class EventType
{
    /// <summary>
    /// Olay tipi adı (örn. transaction.created)
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Olay tipi açıklaması
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Olay tipi grubu (Transaction, Subscription vb.)
    /// </summary>
    public string Group { get; set; }

    /// <summary>
    /// Kullanılabilir API versiyonları
    /// </summary>
    public List<int> AvailableVersions { get; set; }
}

/// <summary>
/// Bildirim ayarı oluşturma isteği modeli
/// </summary>
public class CreateNotificationSettingRequest
{
    /// <summary>
    /// Bildirim ayarı açıklaması (required, 1-256 karakter)
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Bildirim tipi (required, email/url)
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// Webhook URL'i veya e-posta adresi (required)
    /// </summary>
    public string Destination { get; set; }

    /// <summary>
    /// Bildirim ayarı aktif mi? (optional, default: true)
    /// </summary>
    public bool? Active { get; set; }

    /// <summary>
    /// API versiyonu (optional)
    /// </summary>
    public int? ApiVersion { get; set; }

    /// <summary>
    /// Hassas alanlar dahil edilsin mi? (optional, default: false)
    /// </summary>
    public bool? IncludeSensitiveFields { get; set; }

    /// <summary>
    /// Abone olunan olay tipleri listesi (required)
    /// </summary>
    public List<string> SubscribedEvents { get; set; }

    /// <summary>
    /// Trafik kaynağı (optional, platform/simulation/all)
    /// </summary>
    public string TrafficSource { get; set; }
}

/// <summary>
/// Bildirim ayarı güncelleme isteği modeli
/// </summary>
public class UpdateNotificationSettingRequest
{
    /// <summary>
    /// Yeni açıklama (optional)
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Yeni webhook URL'i veya e-posta adresi (optional)
    /// </summary>
    public string Destination { get; set; }

    /// <summary>
    /// Yeni aktiflik durumu (optional)
    /// </summary>
    public bool? Active { get; set; }

    /// <summary>
    /// Yeni API versiyonu (optional)
    /// </summary>
    public int? ApiVersion { get; set; }

    /// <summary>
    /// Yeni hassas alan tercihi (optional)
    /// </summary>
    public bool? IncludeSensitiveFields { get; set; }

    /// <summary>
    /// Yeni olay tipleri listesi (optional)
    /// </summary>
    public List<string> SubscribedEvents { get; set; }

    /// <summary>
    /// Yeni trafik kaynağı (optional)
    /// </summary>
    public string TrafficSource { get; set; }
}

## Adres (Address)

```csharp
/// <summary>
/// Adres varlığını temsil eder
/// </summary>
public class Address
{
    /// <summary>
    /// Adresin benzersiz Paddle ID'si (add_ öneki ile)
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Adresin bağlı olduğu müşteri ID'si
    /// </summary>
    public string CustomerId { get; set; }

    /// <summary>
    /// Adres açıklaması (max 200 karakter)
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Adres satırı 1 (max 200 karakter)
    /// </summary>
    public string FirstLine { get; set; }

    /// <summary>
    /// Adres satırı 2 (max 200 karakter)
    /// </summary>
    public string SecondLine { get; set; }

    /// <summary>
    /// Şehir (max 200 karakter)
    /// </summary>
    public string City { get; set; }

    /// <summary>
    /// Posta kodu (max 200 karakter)
    /// </summary>
    public string PostalCode { get; set; }

    /// <summary>
    /// Bölge/Eyalet (max 200 karakter)
    /// </summary>
    public string Region { get; set; }

    /// <summary>
    /// Ülke kodu (ISO 3166-1 alpha-2)
    /// </summary>
    public string CountryCode { get; set; }

    /// <summary>
    /// Adres durumu (active/archived)
    /// </summary>
    public string Status { get; set; }

    /// <summary>
    /// Özel veri alanı (JSON formatında)
    /// </summary>
    public object CustomData { get; set; }

    /// <summary>
    /// Oluşturulma tarihi
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Son güncelleme tarihi
    /// </summary>
    public DateTime UpdatedAt { get; set; }
}

/// <summary>
/// Adres oluşturma isteği modeli
/// </summary>
public class CreateAddressRequest
{
    /// <summary>
    /// Müşteri ID'si (required)
    /// </summary>
    public string CustomerId { get; set; }

    /// <summary>
    /// Adres açıklaması (optional, max 200 karakter)
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Adres satırı 1 (required, max 200 karakter)
    /// </summary>
    public string FirstLine { get; set; }

    /// <summary>
    /// Adres satırı 2 (optional, max 200 karakter)
    /// </summary>
    public string SecondLine { get; set; }

    /// <summary>
    /// Şehir (required, max 200 karakter)
    /// </summary>
    public string City { get; set; }

    /// <summary>
    /// Posta kodu (required, max 200 karakter)
    /// </summary>
    public string PostalCode { get; set; }

    /// <summary>
    /// Bölge/Eyalet (optional, max 200 karakter)
    /// </summary>
    public string Region { get; set; }

    /// <summary>
    /// Ülke kodu (required, ISO 3166-1 alpha-2)
    /// </summary>
    public string CountryCode { get; set; }

    /// <summary>
    /// Özel veri alanı (optional, JSON formatında)
    /// </summary>
    public object CustomData { get; set; }
}

/// <summary>
/// Adres güncelleme isteği modeli
/// </summary>
public class UpdateAddressRequest
{
    /// <summary>
    /// Yeni adres açıklaması (optional)
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Yeni adres satırı 1 (optional)
    /// </summary>
    public string FirstLine { get; set; }

    /// <summary>
    /// Yeni adres satırı 2 (optional)
    /// </summary>
    public string SecondLine { get; set; }

    /// <summary>
    /// Yeni şehir (optional)
    /// </summary>
    public string City { get; set; }

    /// <summary>
    /// Yeni posta kodu (optional)
    /// </summary>
    public string PostalCode { get; set; }

    /// <summary>
    /// Yeni bölge/eyalet (optional)
    /// </summary>
    public string Region { get; set; }

    /// <summary>
    /// Yeni ülke kodu (optional)
    /// </summary>
    public string CountryCode { get; set; }

    /// <summary>
    /// Yeni adres durumu (optional)
    /// </summary>
    public string Status { get; set; }

    /// <summary>
    /// Yeni özel veri (optional)
    /// </summary>
    public object CustomData { get; set; }
}

## Katalog (Catalog)

```csharp
/// <summary>
/// Katalog ürününü temsil eder
/// </summary>
public class CatalogProduct
{
    /// <summary>
    /// Ürünün benzersiz Paddle ID'si (pro_ öneki ile)
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Ürün adı (max 255 karakter)
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Vergi kategorisi (standard/digital/physical)
    /// </summary>
    public string TaxCategory { get; set; }

    /// <summary>
    /// Ürün tipi (standard/custom)
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// Ürün açıklaması (max 2000 karakter)
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Ürün görseli URL'i (max 2000 karakter)
    /// </summary>
    public string ImageUrl { get; set; }

    /// <summary>
    /// Özel veri alanı (JSON formatında)
    /// </summary>
    public object CustomData { get; set; }

    /// <summary>
    /// Ürün durumu (active/archived)
    /// </summary>
    public string Status { get; set; }

    /// <summary>
    /// Oluşturulma tarihi
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Son güncelleme tarihi
    /// </summary>
    public DateTime UpdatedAt { get; set; }
}

/// <summary>
/// Katalog fiyatını temsil eder
/// </summary>
public class CatalogPrice
{
    /// <summary>
    /// Fiyatın benzersiz Paddle ID'si (pri_ öneki ile)
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Fiyatın bağlı olduğu ürün ID'si
    /// </summary>
    public string ProductId { get; set; }

    /// <summary>
    /// Fiyat açıklaması (max 2000 karakter)
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Fiyat adı (max 255 karakter)
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Faturalandırma döngüsü
    /// </summary>
    public BillingCycle BillingCycle { get; set; }

    /// <summary>
    /// Deneme süresi
    /// </summary>
    public TrialPeriod TrialPeriod { get; set; }

    /// <summary>
    /// Vergi modu (account_setting/external/internal)
    /// </summary>
    public string TaxMode { get; set; }

    /// <summary>
    /// Birim fiyat
    /// </summary>
    public UnitPrice UnitPrice { get; set; }

    /// <summary>
    /// Ülkeye özel fiyat tanımları
    /// </summary>
    public List<UnitPriceOverride> UnitPriceOverrides { get; set; }

    /// <summary>
    /// Miktar sınırları
    /// </summary>
    public Quantity Quantity { get; set; }

    /// <summary>
    /// Fiyat tipi (standard/custom)
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// Fiyat durumu (active/archived)
    /// </summary>
    public string Status { get; set; }

    /// <summary>
    /// Özel veri alanı (JSON formatında)
    /// </summary>
    public object CustomData { get; set; }

    /// <summary>
    /// Oluşturulma tarihi
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Son güncelleme tarihi
    /// </summary>
    public DateTime UpdatedAt { get; set; }
}

/// <summary>
/// Faturalandırma döngüsünü temsil eder
/// </summary>
public class BillingCycle
{
    /// <summary>
    /// Döngü süresi (1-365)
    /// </summary>
    public int Interval { get; set; }

    /// <summary>
    /// Döngü birimi (day/week/month/year)
    /// </summary>
    public string Frequency { get; set; }
}

/// <summary>
/// Deneme süresini temsil eder
/// </summary>
public class TrialPeriod
{
    /// <summary>
    /// Deneme süresi (1-365)
    /// </summary>
    public int Interval { get; set; }

    /// <summary>
    /// Deneme süresi birimi (day/week/month/year)
    /// </summary>
    public string Frequency { get; set; }
}

/// <summary>
/// Birim fiyatı temsil eder
/// </summary>
public class UnitPrice
{
    /// <summary>
    /// Fiyat tutarı (1-999999999)
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Para birimi (ISO 4217)
    /// </summary>
    public string CurrencyCode { get; set; }
}

/// <summary>
/// Ülkeye özel fiyat tanımını temsil eder
/// </summary>
public class UnitPriceOverride
{
    /// <summary>
    /// Ülke kodu (ISO 3166-1 alpha-2)
    /// </summary>
    public string CountryCode { get; set; }

    /// <summary>
    /// Fiyat tutarı (1-999999999)
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Para birimi (ISO 4217)
    /// </summary>
    public string CurrencyCode { get; set; }
}

/// <summary>
/// Miktar sınırlarını temsil eder
/// </summary>
public class Quantity
{
    /// <summary>
    /// Minimum miktar (1-999999999)
    /// </summary>
    public int Minimum { get; set; }

    /// <summary>
    /// Maksimum miktar (1-999999999)
    /// </summary>
    public int Maximum { get; set; }
}

## Simülasyonlar (Simulations)

```csharp
/// <summary>
/// Bildirim simülasyonu isteğini temsil eder
/// </summary>
public class NotificationSimulationRequest
{
    /// <summary>
    /// Simüle edilecek bildirim tipi
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// Simülasyon için gerekli veri
    /// </summary>
    public object Data { get; set; }

    /// <summary>
    /// Bildirim ayarları
    /// </summary>
    public NotificationSettings NotificationSettings { get; set; }
}

/// <summary>
/// Bildirim ayarlarını temsil eder
/// </summary>
public class NotificationSettings
{
    /// <summary>
    /// Bildirim URL'i
    /// </summary>
    public string Destination { get; set; }

    /// <summary>
    /// API anahtarı
    /// </summary>
    public string ApiKey { get; set; }

    /// <summary>
    /// Hassas alanları dahil etme
    /// </summary>
    public bool IncludeSensitiveFields { get; set; }
}

/// <summary>
/// İşlem önizleme isteğini temsil eder
/// </summary>
public class TransactionPreviewRequest
{
    /// <summary>
    /// İşlem kalemleri
    /// </summary>
    public List<TransactionPreviewItem> Items { get; set; }

    /// <summary>
    /// Müşteri ID'si
    /// </summary>
    public string CustomerId { get; set; }

    /// <summary>
    /// Adres ID'si
    /// </summary>
    public string AddressId { get; set; }

    /// <summary>
    /// İşletme ID'si
    /// </summary>
    public string BusinessId { get; set; }

    /// <summary>
    /// Para birimi (ISO 4217)
    /// </summary>
    public string CurrencyCode { get; set; }

    /// <summary>
    /// İndirim ID'si
    /// </summary>
    public string DiscountId { get; set; }

    /// <summary>
    /// Özel veri alanı (JSON formatında)
    /// </summary>
    public object CustomData { get; set; }
}

/// <summary>
/// İşlem önizleme kalemini temsil eder
/// </summary>
public class TransactionPreviewItem
{
    /// <summary>
    /// Fiyat ID'si
    /// </summary>
    public string PriceId { get; set; }

    /// <summary>
    /// Miktar
    /// </summary>
    public int Quantity { get; set; }
}

/// <summary>
/// İşlem önizleme sonucunu temsil eder
/// </summary>
public class TransactionPreviewResult
{
    /// <summary>
    /// İşlem detayları
    /// </summary>
    public TransactionDetails Details { get; set; }

    /// <summary>
    /// Faturalandırma bilgileri
    /// </summary>
    public BillingInfo Billing { get; set; }

    /// <summary>
    /// Fiyat ayarlamaları
    /// </summary>
    public List<Adjustment> Adjustments { get; set; }

    /// <summary>
    /// Vergi hesaplamaları
    /// </summary>
    public TaxCalculation Tax { get; set; }
}

/// <summary>
/// Fiyat önizleme isteğini temsil eder
/// </summary>
public class PricePreviewRequest
{
    /// <summary>
    /// Fiyat kalemleri
    /// </summary>
    public List<PricePreviewItem> Items { get; set; }

    /// <summary>
    /// Adres bilgileri
    /// </summary>
    public PreviewAddress Address { get; set; }

    /// <summary>
    /// Para birimi (ISO 4217)
    /// </summary>
    public string CurrencyCode { get; set; }
}

/// <summary>
/// Fiyat önizleme kalemini temsil eder
/// </summary>
public class PricePreviewItem
{
    /// <summary>
    /// Fiyat ID'si
    /// </summary>
    public string PriceId { get; set; }

    /// <summary>
    /// Miktar
    /// </summary>
    public int Quantity { get; set; }
}

/// <summary>
/// Önizleme adresi bilgilerini temsil eder
/// </summary>
public class PreviewAddress
{
    /// <summary>
    /// Ülke kodu (ISO 3166-1 alpha-2)
    /// </summary>
    public string CountryCode { get; set; }

    /// <summary>
    /// Posta kodu
    /// </summary>
    public string PostalCode { get; set; }
}

/// <summary>
/// Fiyat önizleme sonucunu temsil eder
/// </summary>
public class PricePreviewResult
{
    /// <summary>
    /// Kalem bazında hesaplamalar
    /// </summary>
    public List<PricePreviewItemResult> Items { get; set; }

    /// <summary>
    /// Toplam tutarlar
    /// </summary>
    public PriceTotals Totals { get; set; }

    /// <summary>
    /// Vergi hesaplamaları
    /// </summary>
    public TaxCalculation Tax { get; set; }
}

/// <summary>
/// Fiyat önizleme kalem sonucunu temsil eder
/// </summary>
public class PricePreviewItemResult
{
    /// <summary>
    /// Fiyat ID'si
    /// </summary>
    public string PriceId { get; set; }

    /// <summary>
    /// Miktar
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Birim fiyat
    /// </summary>
    public UnitPrice UnitPrice { get; set; }

    /// <summary>
    /// Toplam tutar
    /// </summary>
    public decimal Total { get; set; }
}

/// <summary>
/// Fiyat toplamlarını temsil eder
/// </summary>
public class PriceTotals
{
    /// <summary>
    /// Ara toplam
    /// </summary>
    public decimal Subtotal { get; set; }

    /// <summary>
    /// Vergi tutarı
    /// </summary>
    public decimal Tax { get; set; }

    /// <summary>
    /// Genel toplam
    /// </summary>
    public decimal Total { get; set; }
}

## Zaman Periyotları (Time Periods)

```csharp
/// <summary>
/// Zaman periyodunu temsil eder
/// </summary>
public class TimePeriod
{
    /// <summary>
    /// Periyot süresi (1-365)
    /// </summary>
    public int Interval { get; set; }

    /// <summary>
    /// Periyot birimi (day/week/month/year)
    /// </summary>
    public string Frequency { get; set; }
}

/// <summary>
/// Faturalandırma döngüsünü temsil eder
/// </summary>
public class BillingCycleInfo : TimePeriod
{
    /// <summary>
    /// Döngü başlangıç tarihi
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// Döngü bitiş tarihi
    /// </summary>
    public DateTime EndDate { get; set; }
}

/// <summary>
/// Deneme süresini temsil eder
/// </summary>
public class TrialPeriodInfo : TimePeriod
{
    /// <summary>
    /// Deneme başlangıç tarihi
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// Deneme bitiş tarihi
    /// </summary>
    public DateTime EndDate { get; set; }
}

/// <summary>
/// Abonelik döngüsünü temsil eder
/// </summary>
public class SubscriptionPeriod
{
    /// <summary>
    /// Döngü başlangıç tarihi
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// Döngü bitiş tarihi
    /// </summary>
    public DateTime EndDate { get; set; }

    /// <summary>
    /// Faturalandırma döngüsü
    /// </summary>
    public BillingCycleInfo BillingCycle { get; set; }

    /// <summary>
    /// Deneme süresi (varsa)
    /// </summary>
    public TrialPeriodInfo TrialPeriod { get; set; }
}

/// <summary>
/// Faturalandırma tarihlerini temsil eder
/// </summary>
public class BillingDates
{
    /// <summary>
    /// Bir sonraki faturalandırma tarihi
    /// </summary>
    public DateTime NextBillingDate { get; set; }

    /// <summary>
    /// Son faturalandırma tarihi
    /// </summary>
    public DateTime LastBillingDate { get; set; }

    /// <summary>
    /// Bir sonraki faturalandırma dönemi
    /// </summary>
    public SubscriptionPeriod NextBillingPeriod { get; set; }

    /// <summary>
    /// Mevcut faturalandırma dönemi
    /// </summary>
    public SubscriptionPeriod CurrentBillingPeriod { get; set; }
}

/// <summary>
/// Zaman bazlı kısıtlamaları temsil eder
/// </summary>
public class TimeConstraints
{
    /// <summary>
    /// Başlangıç tarihi
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// Bitiş tarihi
    /// </summary>
    public DateTime EndDate { get; set; }

    /// <summary>
    /// Zaman dilimi (UTC offset)
    /// </summary>
    public string TimeZone { get; set; }

    /// <summary>
    /// Geçerlilik süresi (saniye cinsinden)
    /// </summary>
    public int ValidityDuration { get; set; }
}

## İşlem Revizyonları (Transaction Revisions)

```csharp
/// <summary>
/// İşlem revizyonunu temsil eder
/// </summary>
public class TransactionRevision
{
    /// <summary>
    /// Revizyonun benzersiz Paddle ID'si (txr_ öneki ile)
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// İşlem ID'si
    /// </summary>
    public string TransactionId { get; set; }

    /// <summary>
    /// Revizyon nedeni
    /// </summary>
    public string Reason { get; set; }

    /// <summary>
    /// Revizyon detayları
    /// </summary>
    public RevisionDetails Details { get; set; }

    /// <summary>
    /// Revizyon notları
    /// </summary>
    public string Notes { get; set; }

    /// <summary>
    /// Revizyon durumu (pending/approved/rejected)
    /// </summary>
    public string Status { get; set; }

    /// <summary>
    /// Oluşturulma tarihi
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Son güncelleme tarihi
    /// </summary>
    public DateTime UpdatedAt { get; set; }
}

/// <summary>
/// Revizyon detaylarını temsil eder
/// </summary>
public class RevisionDetails
{
    /// <summary>
    /// Yeni müşteri ID'si
    /// </summary>
    public string CustomerId { get; set; }

    /// <summary>
    /// Yeni adres ID'si
    /// </summary>
    public string AddressId { get; set; }

    /// <summary>
    /// Yeni işletme ID'si
    /// </summary>
    public string BusinessId { get; set; }

    /// <summary>
    /// Güncellenmiş işlem kalemleri
    /// </summary>
    public List<RevisionItem> Items { get; set; }

    /// <summary>
    /// Güncellenmiş faturalandırma bilgileri
    /// </summary>
    public RevisionBilling Billing { get; set; }

    /// <summary>
    /// Güncellenmiş fiyat ayarlamaları
    /// </summary>
    public List<RevisionAdjustment> Adjustments { get; set; }

    /// <summary>
    /// Güncellenmiş özel veri
    /// </summary>
    public object CustomData { get; set; }
}

/// <summary>
/// Revizyon kalemini temsil eder
/// </summary>
public class RevisionItem
{
    /// <summary>
    /// Kalem ID'si
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Fiyat ID'si
    /// </summary>
    public string PriceId { get; set; }

    /// <summary>
    /// Miktar
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Birim fiyat
    /// </summary>
    public UnitPrice UnitPrice { get; set; }

    /// <summary>
    /// Toplam tutar
    /// </summary>
    public decimal Total { get; set; }
}

/// <summary>
/// Revizyon faturalandırma bilgilerini temsil eder
/// </summary>
public class RevisionBilling
{
    /// <summary>
    /// Faturalandırma adresi
    /// </summary>
    public Address BillingAddress { get; set; }

    /// <summary>
    /// Faturalandırma işletmesi
    /// </summary>
    public Business BillingBusiness { get; set; }

    /// <summary>
    /// Faturalandırma döngüsü
    /// </summary>
    public BillingCycleInfo BillingCycle { get; set; }

    /// <summary>
    /// Faturalandırma tarihleri
    /// </summary>
    public BillingDates BillingDates { get; set; }
}

/// <summary>
/// Revizyon fiyat ayarlamasını temsil eder
/// </summary>
public class RevisionAdjustment
{
    /// <summary>
    /// Ayarlama ID'si
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Ayarlama tipi (discount/credit/debit)
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// Ayarlama tutarı
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Para birimi (ISO 4217)
    /// </summary>
    public string CurrencyCode { get; set; }

    /// <summary>
    /// Ayarlama açıklaması
    /// </summary>
    public string Description { get; set; }
}

/// <summary>
/// Revizyon oluşturma isteğini temsil eder
/// </summary>
public class CreateTransactionRevisionRequest
{
    /// <summary>
    /// Revizyon nedeni (required)
    /// </summary>
    public string Reason { get; set; }

    /// <summary>
    /// Revizyon detayları (required)
    /// </summary>
    public RevisionDetails Details { get; set; }

    /// <summary>
    /// Revizyon notları (optional)
    /// </summary>
    public string Notes { get; set; }
}

/// <summary>
/// Revizyon güncelleme isteğini temsil eder
/// </summary>
public class UpdateTransactionRevisionRequest
{
    /// <summary>
    /// Yeni revizyon nedeni (optional)
    /// </summary>
    public string Reason { get; set; }

    /// <summary>
    /// Yeni revizyon notları (optional)
    /// </summary>
    public string Notes { get; set; }

    /// <summary>
    /// Yeni revizyon durumu (optional)
    /// </summary>
    public string Status { get; set; }
}
```