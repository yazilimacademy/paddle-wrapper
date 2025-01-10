# Paddle API Enum'ları

## Ürün Durumu (ProductStatus)

```csharp
/// <summary>
/// Ürünün mevcut durumu
/// </summary>
public enum ProductStatus
{
    /// <summary>
    /// Ürün aktif ve satışta
    /// </summary>
    Active,

    /// <summary>
    /// Ürün arşivlenmiş ve satışta değil
    /// </summary>
    Archived
}
```

## Vergi Kategorisi (TaxCategory)

```csharp
/// <summary>
/// Ürünün vergi kategorisi
/// </summary>
public enum TaxCategory
{
    /// <summary>
    /// Dijital ürünler (yazılım hariç) için vergi kategorisi
    /// </summary>
    DigitalGoods,

    /// <summary>
    /// E-kitaplar ve eğitim materyalleri için vergi kategorisi
    /// </summary>
    Ebooks,

    /// <summary>
    /// Uygulama ve entegrasyon hizmetleri için vergi kategorisi
    /// </summary>
    ImplementationServices,

    /// <summary>
    /// Profesyonel hizmetler için vergi kategorisi
    /// </summary>
    ProfessionalServices,

    /// <summary>
    /// SaaS ürünleri için vergi kategorisi
    /// </summary>
    Saas,

    /// <summary>
    /// Yazılım programlama hizmetleri için vergi kategorisi
    /// </summary>
    SoftwareProgrammingServices,

    /// <summary>
    /// Standart yazılım ürünleri için vergi kategorisi
    /// </summary>
    Standard,

    /// <summary>
    /// Eğitim hizmetleri için vergi kategorisi
    /// </summary>
    TrainingServices,

    /// <summary>
    /// Web hosting hizmetleri için vergi kategorisi
    /// </summary>
    WebsiteHosting
}
```

## Ürün Tipi (ProductType)

```csharp
/// <summary>
/// Ürünün tipi
/// </summary>
public enum ProductType
{
    /// <summary>
    /// Standart ürün tipi
    /// </summary>
    Standard,

    /// <summary>
    /// Özelleştirilmiş ürün tipi
    /// </summary>
    Custom
}
```

## Vergi Modu (TaxMode)

```csharp
/// <summary>
/// Fiyatlandırma için vergi hesaplama modu
/// </summary>
public enum TaxMode
{
    /// <summary>
    /// Hesap ayarlarına göre vergi hesaplama
    /// </summary>
    AccountSetting,

    /// <summary>
    /// Fiyatlar vergisiz (vergi hariç)
    /// </summary>
    External,

    /// <summary>
    /// Fiyatlar vergili (vergi dahil)
    /// </summary>
    Internal
}
```

## Varlık Durumu (EntityStatus)

```csharp
/// <summary>
/// Varlıkların (müşteri, işletme, ürün vb.) durumu
/// </summary>
public enum EntityStatus
{
    /// <summary>
    /// Varlık aktif durumda
    /// </summary>
    Active,

    /// <summary>
    /// Varlık arşivlenmiş durumda
    /// </summary>
    Archived
}
```

## Sıralama Yönü (OrderDirection)

```csharp
/// <summary>
/// Liste sonuçlarının sıralama yönü
/// </summary>
public enum OrderDirection
{
    /// <summary>
    /// Artan sıralama (A'dan Z'ye, eskiden yeniye)
    /// </summary>
    Asc,

    /// <summary>
    /// Azalan sıralama (Z'den A'ya, yeniden eskiye)
    /// </summary>
    Desc
}
```

## Para Birimi (CurrencyCode)

```csharp
/// <summary>
/// Desteklenen para birimleri
/// </summary>
public enum CurrencyCode
{
    /// <summary>
    /// Arjantin Pesosu
    /// </summary>
    ARS,

    /// <summary>
    /// Avustralya Doları
    /// </summary>
    AUD,

    /// <summary>
    /// Brezilya Reali
    /// </summary>
    BRL,

    /// <summary>
    /// Kanada Doları
    /// </summary>
    CAD,

    /// <summary>
    /// İsviçre Frangı
    /// </summary>
    CHF,

    /// <summary>
    /// Çin Yuanı
    /// </summary>
    CNY,

    /// <summary>
    /// Kolombiya Pesosu
    /// </summary>
    COP,

    /// <summary>
    /// Çek Korunası
    /// </summary>
    CZK,

    /// <summary>
    /// Danimarka Kronu
    /// </summary>
    DKK,

    /// <summary>
    /// Euro
    /// </summary>
    EUR,

    /// <summary>
    /// İngiliz Sterlini
    /// </summary>
    GBP,

    /// <summary>
    /// Macar Forinti
    /// </summary>
    HUF,

    /// <summary>
    /// İsrail Şekeli
    /// </summary>
    ILS,

    /// <summary>
    /// Hint Rupisi
    /// </summary>
    INR,

    /// <summary>
    /// Güney Kore Wonu
    /// </summary>
    KRW,

    /// <summary>
    /// Meksika Pesosu
    /// </summary>
    MXN,

    /// <summary>
    /// Norveç Kronu
    /// </summary>
    NOK,

    /// <summary>
    /// Yeni Zelanda Doları
    /// </summary>
    NZD,

    /// <summary>
    /// Polonya Zlotisi
    /// </summary>
    PLN,

    /// <summary>
    /// Rus Rublesi
    /// </summary>
    RUB,

    /// <summary>
    /// İsveç Kronu
    /// </summary>
    SEK,

    /// <summary>
    /// Tayland Bahtı
    /// </summary>
    THB,

    /// <summary>
    /// Türk Lirası
    /// </summary>
    TRY,

    /// <summary>
    /// Yeni Tayvan Doları
    /// </summary>
    TWD,

    /// <summary>
    /// Ukrayna Grivnası
    /// </summary>
    UAH,

    /// <summary>
    /// Amerikan Doları
    /// </summary>
    USD,

    /// <summary>
    /// Vietnam Dongu
    /// </summary>
    VND,

    /// <summary>
    /// Güney Afrika Randı
    /// </summary>
    ZAR
}
```

## Abonelik Durumu (SubscriptionStatus)

```csharp
/// <summary>
/// Aboneliğin mevcut durumu
/// </summary>
public enum SubscriptionStatus
{
    /// <summary>
    /// Abonelik aktif ve faturalandırılıyor
    /// </summary>
    Active,

    /// <summary>
    /// Abonelik deneme sürecinde
    /// </summary>
    Trialing,

    /// <summary>
    /// Abonelik duraklatılmış
    /// </summary>
    Paused,

    /// <summary>
    /// Abonelik ödeme bekliyor
    /// </summary>
    PastDue,

    /// <summary>
    /// Abonelik iptal edilmiş
    /// </summary>
    Canceled
}
```

## Kart Tipi (CardType)

```csharp
/// <summary>
/// Ödeme kartı tipi
/// </summary>
public enum CardType
{
    /// <summary>
    /// American Express
    /// </summary>
    AmericanExpress,

    /// <summary>
    /// Diners Club
    /// </summary>
    DinersClub,

    /// <summary>
    /// Discover Card
    /// </summary>
    Discover,

    /// <summary>
    /// JCB Card (Japonya'da yaygın)
    /// </summary>
    JCB,

    /// <summary>
    /// Mada Card (Suudi Arabistan'da yaygın)
    /// </summary>
    Mada,

    /// <summary>
    /// Maestro (banka kartı)
    /// </summary>
    Maestro,

    /// <summary>
    /// Mastercard
    /// </summary>
    Mastercard,

    /// <summary>
    /// UnionPay (Çin'de yaygın)
    /// </summary>
    UnionPay,

    /// <summary>
    /// Bilinmeyen kart tipi
    /// </summary>
    Unknown,

    /// <summary>
    /// Visa
    /// </summary>
    Visa
}
```

## Rapor Tipi (ReportType)

```csharp
/// <summary>
/// Rapor tipi
/// </summary>
public enum ReportType
{
    /// <summary>
    /// Düzeltme raporları
    /// </summary>
    Adjustments,

    /// <summary>
    /// Düzeltme satır öğeleri raporları
    /// </summary>
    AdjustmentLineItems,

    /// <summary>
    /// İşlem raporları
    /// </summary>
    Transactions,

    /// <summary>
    /// İşlem satır öğeleri raporları
    /// </summary>
    TransactionLineItems
}
```

## Olay Tipi (EventType)

```csharp
/// <summary>
/// Webhook olay tipi
/// </summary>
public enum EventType
{
    /// <summary>
    /// Adres oluşturuldu
    /// </summary>
    AddressCreated,

    /// <summary>
    /// Adres içe aktarıldı
    /// </summary>
    AddressImported,

    /// <summary>
    /// Adres güncellendi
    /// </summary>
    AddressUpdated,

    /// <summary>
    /// Düzeltme oluşturuldu
    /// </summary>
    AdjustmentCreated,

    /// <summary>
    /// Düzeltme güncellendi
    /// </summary>
    AdjustmentUpdated,

    /// <summary>
    /// İşletme oluşturuldu
    /// </summary>
    BusinessCreated,

    /// <summary>
    /// İşletme içe aktarıldı
    /// </summary>
    BusinessImported,

    /// <summary>
    /// İşletme güncellendi
    /// </summary>
    BusinessUpdated,

    /// <summary>
    /// Müşteri oluşturuldu
    /// </summary>
    CustomerCreated,

    /// <summary>
    /// Müşteri içe aktarıldı
    /// </summary>
    CustomerImported,

    /// <summary>
    /// Müşteri güncellendi
    /// </summary>
    CustomerUpdated,

    /// <summary>
    /// İndirim oluşturuldu
    /// </summary>
    DiscountCreated,

    /// <summary>
    /// İndirim içe aktarıldı
    /// </summary>
    DiscountImported,

    /// <summary>
    /// İndirim güncellendi
    /// </summary>
    DiscountUpdated,

    /// <summary>
    /// Ödeme oluşturuldu
    /// </summary>
    PayoutCreated,

    /// <summary>
    /// Ödeme yapıldı
    /// </summary>
    PayoutPaid,

    /// <summary>
    /// Fiyat oluşturuldu
    /// </summary>
    PriceCreated,

    /// <summary>
    /// Fiyat içe aktarıldı
    /// </summary>
    PriceImported,

    /// <summary>
    /// Fiyat güncellendi
    /// </summary>
    PriceUpdated,

    /// <summary>
    /// Ürün oluşturuldu
    /// </summary>
    ProductCreated,

    /// <summary>
    /// Ürün içe aktarıldı
    /// </summary>
    ProductImported,

    /// <summary>
    /// Ürün güncellendi
    /// </summary>
    ProductUpdated,

    /// <summary>
    /// Rapor oluşturuldu
    /// </summary>
    ReportCreated,

    /// <summary>
    /// Rapor güncellendi
    /// </summary>
    ReportUpdated,

    /// <summary>
    /// Abonelik aktifleştirildi
    /// </summary>
    SubscriptionActivated,

    /// <summary>
    /// Abonelik iptal edildi
    /// </summary>
    SubscriptionCanceled,

    /// <summary>
    /// Abonelik oluşturuldu
    /// </summary>
    SubscriptionCreated,

    /// <summary>
    /// Abonelik içe aktarıldı
    /// </summary>
    SubscriptionImported,

    /// <summary>
    /// Abonelik ödeme gecikti
    /// </summary>
    SubscriptionPastDue,

    /// <summary>
    /// Abonelik duraklatıldı
    /// </summary>
    SubscriptionPaused,

    /// <summary>
    /// Abonelik devam ettirildi
    /// </summary>
    SubscriptionResumed,

    /// <summary>
    /// Abonelik deneme sürecinde
    /// </summary>
    SubscriptionTrialing,

    /// <summary>
    /// Abonelik güncellendi
    /// </summary>
    SubscriptionUpdated,

    /// <summary>
    /// İşlem faturalandırıldı
    /// </summary>
    TransactionBilled,

    /// <summary>
    /// İşlem iptal edildi
    /// </summary>
    TransactionCanceled,

    /// <summary>
    /// İşlem tamamlandı
    /// </summary>
    TransactionCompleted,

    /// <summary>
    /// İşlem oluşturuldu
    /// </summary>
    TransactionCreated,

    /// <summary>
    /// İşlem ödendi
    /// </summary>
    TransactionPaid,

    /// <summary>
    /// İşlem ödeme gecikti
    /// </summary>
    TransactionPastDue,

    /// <summary>
    /// İşlem ödeme başarısız
    /// </summary>
    TransactionPaymentFailed,

    /// <summary>
    /// İşlem hazır
    /// </summary>
    TransactionReady,

    /// <summary>
    /// İşlem güncellendi
    /// </summary>
    TransactionUpdated
}
```

## Tahsilat Modu (CollectionMode)

```csharp
/// <summary>
/// Ödeme tahsilat modu
/// </summary>
public enum CollectionMode
{
    /// <summary>
    /// Otomatik tahsilat
    /// </summary>
    Automatic,

    /// <summary>
    /// Manuel tahsilat
    /// </summary>
    Manual
}
```

## Döngü Aralığı (IntervalType)

```csharp
/// <summary>
/// Faturalandırma döngüsü aralık tipi
/// </summary>
public enum IntervalType
{
    /// <summary>
    /// Günlük döngü
    /// </summary>
    Day,

    /// <summary>
    /// Haftalık döngü
    /// </summary>
    Week,

    /// <summary>
    /// Aylık döngü
    /// </summary>
    Month,

    /// <summary>
    /// Yıllık döngü
    /// </summary>
    Year
}
```

## Değişiklik Aksiyonu (ChangeAction)

```csharp
/// <summary>
/// Abonelik değişiklik aksiyonu
/// </summary>
public enum ChangeAction
{
    /// <summary>
    /// Aboneliği iptal et
    /// </summary>
    Cancel,

    /// <summary>
    /// Aboneliği duraklat
    /// </summary>
    Pause,

    /// <summary>
    /// Aboneliği devam ettir
    /// </summary>
    Resume
}
```

## Değişiklik Zamanlaması (EffectiveFrom)

```csharp
/// <summary>
/// Değişikliğin ne zaman geçerli olacağı
/// </summary>
public enum EffectiveFrom
{
    /// <summary>
    /// Hemen geçerli olsun
    /// </summary>
    Immediately,

    /// <summary>
    /// Bir sonraki faturalandırma döneminde geçerli olsun
    /// </summary>
    NextBillingPeriod
}
```

## Fiyat Durumu (PriceStatus)

```csharp
/// <summary>
/// Fiyatın mevcut durumu
/// </summary>
public enum PriceStatus
{
    /// <summary>
    /// Fiyat aktif ve kullanılabilir
    /// </summary>
    Active,

    /// <summary>
    /// Fiyat arşivlenmiş ve kullanılamaz
    /// </summary>
    Archived
}
```

## Fiyat Tipi (PriceType)

```csharp
/// <summary>
/// Fiyatın tipi
/// </summary>
public enum PriceType
{
    /// <summary>
    /// Standart fiyat tipi
    /// </summary>
    Standard,

    /// <summary>
    /// Özelleştirilmiş fiyat tipi
    /// </summary>
    Custom
}
```

## Fiyat Döngü Aralığı (PriceIntervalType)

```csharp
/// <summary>
/// Fiyat döngüsü aralık tipi
/// </summary>
public enum PriceIntervalType
{
    /// <summary>
    /// Günlük döngü
    /// </summary>
    Day,

    /// <summary>
    /// Haftalık döngü
    /// </summary>
    Week,

    /// <summary>
    /// Aylık döngü
    /// </summary>
    Month,

    /// <summary>
    /// Yıllık döngü
    /// </summary>
    Year
}
```

## İşlem Durumu (TransactionStatus)

```csharp
/// <summary>
/// İşlemin mevcut durumu
/// </summary>
public enum TransactionStatus
{
    /// <summary>
    /// İşlem oluşturuldu
    /// </summary>
    Draft,

    /// <summary>
    /// İşlem ödeme için hazır
    /// </summary>
    Ready,

    /// <summary>
    /// İşlem faturalandırıldı
    /// </summary>
    Billed,

    /// <summary>
    /// İşlem tamamlandı
    /// </summary>
    Completed,

    /// <summary>
    /// İşlem iptal edildi
    /// </summary>
    Canceled,

    /// <summary>
    /// İşlem başarısız oldu
    /// </summary>
    Failed
}
```

## İşlem Kaynağı (TransactionOrigin)

```csharp
/// <summary>
/// İşlemin kaynağı
/// </summary>
public enum TransactionOrigin
{
    /// <summary>
    /// API üzerinden oluşturuldu
    /// </summary>
    Api,

    /// <summary>
    /// Abonelik tek seferlik ücreti
    /// </summary>
    SubscriptionCharge,

    /// <summary>
    /// Abonelik ödeme yöntemi değişikliği
    /// </summary>
    SubscriptionPaymentMethodChange,

    /// <summary>
    /// Abonelik yenileme
    /// </summary>
    SubscriptionRecurring,

    /// <summary>
    /// Abonelik güncelleme
    /// </summary>
    SubscriptionUpdate,

    /// <summary>
    /// Web üzerinden oluşturuldu
    /// </summary>
    Web
}
```

## Ödeme Durumu (PaymentStatus)

```csharp
/// <summary>
/// Ödeme denemesinin durumu
/// </summary>
public enum PaymentStatus
{
    /// <summary>
    /// Ödeme bekleniyor
    /// </summary>
    Pending,

    /// <summary>
    /// Ödeme başarılı
    /// </summary>
    Succeeded,

    /// <summary>
    /// Ödeme başarısız
    /// </summary>
    Failed,

    /// <summary>
    /// Ödeme hatası
    /// </summary>
    Error,

    /// <summary>
    /// Ödeme iade edildi
    /// </summary>
    Refunded,

    /// <summary>
    /// Ödeme kısmen iade edildi
    /// </summary>
    PartiallyRefunded
}
```

## Ödeme Yöntemi (PaymentMethodType)

```csharp
/// <summary>
/// Ödeme yöntemi tipi
/// </summary>
public enum PaymentMethodType
{
    /// <summary>
    /// Kredi/Banka kartı
    /// </summary>
    Card,

    /// <summary>
    /// PayPal
    /// </summary>
    PayPal,

    /// <summary>
    /// Apple Pay
    /// </summary>
    ApplePay,

    /// <summary>
    /// Google Pay
    /// </summary>
    GooglePay,

    /// <summary>
    /// Alipay
    /// </summary>
    Alipay
}
```

## İndirim Durumu (DiscountStatus)

```csharp
/// <summary>
/// İndirimin mevcut durumu
/// </summary>
public enum DiscountStatus
{
    /// <summary>
    /// İndirim aktif ve kullanılabilir
    /// </summary>
    Active,

    /// <summary>
    /// İndirim arşivlenmiş ve kullanılamaz
    /// </summary>
    Archived
}
```

## İndirim Tipi (DiscountType)

```csharp
/// <summary>
/// İndirim tipi
/// </summary>
public enum DiscountType
{
    /// <summary>
    /// Sabit tutar indirimi (örn. -$100)
    /// </summary>
    Flat,

    /// <summary>
    /// Birim başına sabit tutar indirimi (örn. -$100 per user)
    /// </summary>
    FlatPerSeat,

    /// <summary>
    /// Yüzde indirimi (örn. -%10)
    /// </summary>
    Percentage
}
```

## Bildirim Enum'ları

### NotificationStatus

```csharp
/// <summary>
/// Bildirim durumunu temsil eder
/// </summary>
public enum NotificationStatus
{
    /// <summary>
    /// Bildirim başarıyla iletildi
    /// </summary>
    Delivered,

    /// <summary>
    /// Bildirim iletilemedi
    /// </summary>
    Failed
}
```

### NotificationType

```csharp
/// <summary>
/// Bildirim tipini temsil eder
/// </summary>
public enum NotificationType
{
    /// <summary>
    /// E-posta bildirimi
    /// </summary>
    Email,

    /// <summary>
    /// Webhook URL bildirimi
    /// </summary>
    Url
}
```

### TrafficSource

```csharp
/// <summary>
/// Bildirim trafik kaynağını temsil eder
/// </summary>
public enum TrafficSource
{
    /// <summary>
    /// Sadece platform trafiği
    /// </summary>
    Platform,

    /// <summary>
    /// Sadece simülasyon trafiği
    /// </summary>
    Simulation,

    /// <summary>
    /// Tüm trafik
    /// </summary>
    All
}
```

### EventGroup

```csharp
/// <summary>
/// Olay grubu tipini temsil eder
/// </summary>
public enum EventGroup
{
    /// <summary>
    /// İşlem olayları
    /// </summary>
    Transaction,

    /// <summary>
    /// Abonelik olayları
    /// </summary>
    Subscription,

    /// <summary>
    /// Müşteri olayları
    /// </summary>
    Customer,

    /// <summary>
    /// Ürün olayları
    /// </summary>
    Product,

    /// <summary>
    /// Fiyat olayları
    /// </summary>
    Price,

    /// <summary>
    /// İndirim olayları
    /// </summary>
    Discount,

    /// <summary>
    /// Adres olayları
    /// </summary>
    Address,

    /// <summary>
    /// İşletme olayları
    /// </summary>
    Business
}
```

## Hata Tipi (ErrorType)

```csharp
/// <summary>
/// API hata tipi
/// </summary>
public enum ErrorType
{
    /// <summary>
    /// İstek hatası - genellikle yapılan istekle ilgili bir sorun olduğunu gösterir
    /// </summary>
    RequestError,

    /// <summary>
    /// API hatası - genellikle Paddle API'sinde bir sorun olduğunu gösterir
    /// </summary>
    ApiError
}
```

## Ülke Kodu (CountryCode)

```csharp
/// <summary>
/// ISO 3166-1 alpha-2 ülke kodları
/// </summary>
public enum CountryCode
{
    /// <summary>
    /// Andorra
    /// </summary>
    AD,

    /// <summary>
    /// Birleşik Arap Emirlikleri
    /// </summary>
    AE,

    /// <summary>
    /// Antigua ve Barbuda
    /// </summary>
    AG,

    /// <summary>
    /// Anguilla
    /// </summary>
    AI,

    /// <summary>
    /// Arnavutluk
    /// </summary>
    AL,

    /// <summary>
    /// Ermenistan
    /// </summary>
    AM,

    /// <summary>
    /// Angola
    /// </summary>
    AO,

    /// <summary>
    /// Arjantin
    /// </summary>
    AR,

    /// <summary>
    /// Amerikan Samoası
    /// </summary>
    AS,

    /// <summary>
    /// Avusturya
    /// </summary>
    AT,

    /// <summary>
    /// Avustralya
    /// </summary>
    AU,

    // ... Diğer ülke kodları benzer şekilde eklenecek
}
```

## Faturalama Zamanlaması (BillingTiming)

```csharp
/// <summary>
/// Abonelik değişikliklerinin ne zaman faturalandırılacağı
/// </summary>
public enum BillingTiming
{
    /// <summary>
    /// Mevcut fatura döngüsüne göre orantılı hesaplanır ve hemen tahsil edilir
    /// </summary>
    ProratedImmediately,

    /// <summary>
    /// Mevcut fatura döngüsüne göre orantılı hesaplanır ve bir sonraki yenilemede tahsil edilir
    /// </summary>
    ProratedNextBillingPeriod,

    /// <summary>
    /// Orantılı hesaplama yapılmaz, tam tutar hemen tahsil edilir
    /// </summary>
    FullImmediately,

    /// <summary>
    /// Orantılı hesaplama yapılmaz, tam tutar bir sonraki yenilemede tahsil edilir
    /// </summary>
    FullNextBillingPeriod,

    /// <summary>
    /// Değişiklikler için fatura kesilmez
    /// </summary>
    DoNotBill
}
```

## İçerik Dahil Etme (IncludeQuery)

```csharp
/// <summary>
/// API yanıtına dahil edilecek ilişkili varlıklar
/// </summary>
public enum IncludeQuery
{
    /// <summary>
    /// Ürünle ilgili fiyatları dahil et
    /// </summary>
    Prices,

    /// <summary>
    /// Simülasyon çalıştırmasıyla ilgili olayları dahil et
    /// </summary>
    Events,

    /// <summary>
    /// Bir sonraki işlemi dahil et
    /// </summary>
    NextTransaction,

    /// <summary>
    /// Yinelenen işlem detaylarını dahil et
    /// </summary>
    RecurringTransactionDetails
}
```

## Simülasyon Tipi (SimulationType)

```csharp
/// <summary>
/// Webhook simülasyon tipi
/// </summary>
public enum SimulationType
{
    /// <summary>
    /// Abonelik oluşturma simülasyonu
    /// </summary>
    SubscriptionCreation,

    /// <summary>
    /// Abonelik yenileme simülasyonu
    /// </summary>
    SubscriptionRenewal
}