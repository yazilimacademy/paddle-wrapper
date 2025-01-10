# Paddle API Hata Kodları

Bu dokümantasyon, Paddle API'sinin döndürebileceği hata tiplerini ve kodlarını açıklar.

## Hata Yanıt Yapısı

Bir hata oluştuğunda, API aşağıdaki yapıda bir yanıt döndürür:

```json
{
    "error": {
        "type": "request_error",
        "code": "not_found",
        "detail": "Entity pro_01gsz97mq9pa4fkyy0wqenepkz not found",
        "documentation_url": "https://developer.paddle.com/errors/shared/not_found"
    }
}
```

## Hata Tipleri

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

## Ödeme Hata Kodları

```csharp
/// <summary>
/// Ödeme denemesi başarısız olduğunda döndürülen hata kodları
/// </summary>
public enum PaymentErrorCode
{
    /// <summary>
    /// Miktar zaten iptal edildiği için iptal işlemi mümkün değil
    /// </summary>
    AlreadyCanceled,

    /// <summary>
    /// Miktar zaten iade edildiği için iade işlemi mümkün değil
    /// </summary>
    AlreadyRefunded,

    /// <summary>
    /// 3DS2 kimlik doğrulaması başarısız oldu
    /// </summary>
    AuthenticationFailed,

    /// <summary>
    /// Kart dondurulmuş, kayıp, hasarlı veya çalıntı olduğu için kullanılamıyor
    /// </summary>
    BlockedCard,

    /// <summary>
    /// Müşteri yinelenen ödemeler için yetkilendirmeyi iptal etti
    /// </summary>
    Canceled,

    /// <summary>
    /// Ödeme yöntemi reddedildi, başka bilgi yok
    /// </summary>
    Declined,

    /// <summary>
    /// Ödeme yöntemi reddedildi ve tekrar denenmemeli
    /// </summary>
    DeclinedNotRetryable,

    /// <summary>
    /// Kart süresi dolmuş
    /// </summary>
    ExpiredCard,

    /// <summary>
    /// Ödeme potansiyel dolandırıcılık olarak işaretlendi
    /// </summary>
    Fraud,

    /// <summary>
    /// Tutar çok yüksek veya düşük
    /// </summary>
    InvalidAmount,

    /// <summary>
    /// Ödeme yöntemi geçersiz (genellikle süresi dolmuş)
    /// </summary>
    InvalidPaymentDetails,

    /// <summary>
    /// Ödeme yöntemi sağlayıcısı, ödeme yöntemi düzenleyicisine ulaşamadı
    /// </summary>
    IssuerUnavailable,

    /// <summary>
    /// Yetersiz bakiye veya limit aşımı
    /// </summary>
    NotEnoughBalance,

    /// <summary>
    /// Ödeme servis sağlayıcısında hata oluştu
    /// </summary>
    PspError,

    /// <summary>
    /// Ödeme yöntemi bilgileri silindiği için işlem yapılamadı
    /// </summary>
    RedactedPaymentMethod,

    /// <summary>
    /// Paddle platformunda bir hata oluştu
    /// </summary>
    SystemError,

    /// <summary>
    /// Hesap limitleri veya yasal/uyumluluk nedenleriyle işleme izin verilmiyor
    /// </summary>
    TransactionNotPermitted,

    /// <summary>
    /// Ödeme başarısız, başka bilgi yok
    /// </summary>
    Unknown
}
```

## Ödeme Deneme Durumları

```csharp
/// <summary>
/// Ödeme denemesinin durumu
/// </summary>
public enum PaymentAttemptStatus
{
    /// <summary>
    /// Yetkilendirildi ama henüz tahsil edilmedi
    /// </summary>
    Authorized,

    /// <summary>
    /// Yetkilendirildi ama potansiyel dolandırıcılık nedeniyle tahsil edilmedi
    /// </summary>
    AuthorizedFlagged,

    /// <summary>
    /// Önceden yetkilendirilmiş ödeme denemesi iptal edildi
    /// </summary>
    Canceled,

    /// <summary>
    /// Ödeme başarıyla tahsil edildi
    /// </summary>
    Captured,

    /// <summary>
    /// Bir hata oluştu, error_code'a bakın
    /// </summary>
    Error,

    /// <summary>
    /// Müşterinin bir işlem yapması gerekiyor (genellikle 3DS)
    /// </summary>
    ActionRequired,

    /// <summary>
    /// Banka veya ödeme sağlayıcısından yanıt bekleniyor
    /// </summary>
    PendingNoActionRequired,

    /// <summary>
    /// Yeni ödeme denemesi oluşturuldu
    /// </summary>
    Created,

    /// <summary>
    /// Ödeme denemesi durumu bilinmiyor
    /// </summary>
    Unknown,

    /// <summary>
    /// Ödeme denemesi Paddle tarafından düşürüldü
    /// </summary>
    Dropped
}
```

## Rapor Durumları

```csharp
/// <summary>
/// Raporun durumu
/// </summary>
public enum ReportStatus
{
    /// <summary>
    /// Rapor oluşturuldu, işleniyor
    /// </summary>
    Pending,

    /// <summary>
    /// Rapor indirilmeye hazır
    /// </summary>
    Ready,

    /// <summary>
    /// Rapor oluşturma başarısız oldu
    /// </summary>
    Failed,

    /// <summary>
    /// Rapor süresi doldu
    /// </summary>
    Expired
}
```

## Doğrulama Hataları

Doğrulama hatalarında, API yanıtı ayrıca bir `errors` dizisi içerir:

```json
{
    "error": {
        "type": "request_error",
        "code": "validation_error",
        "detail": "The request was invalid.",
        "documentation_url": "https://developer.paddle.com/errors/validation",
        "errors": [
            {
                "field": "name",
                "message": "max length of 200 exceeded, provided value length 220"
            },
            {
                "field": "image_url",
                "message": "must be a valid image"
            }
        ]
    }
}
```

Her doğrulama hatası şu bilgileri içerir:
- `field`: Doğrulama hatasının oluştuğu alan
- `message`: Alanın doğrulamayı neden geçemediğine dair açıklama 