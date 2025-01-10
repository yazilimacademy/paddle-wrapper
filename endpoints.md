# Paddle API Endpoint'leri

## Ürünler (Products)

### GET /products
- **Açıklama**: Ürün listesini getirir
- **Parametreler**: 
  - `after` (query, optional): Sayfalama için cursor
  - `id` (query, optional): Belirli ürün ID'leri ile filtreleme
- **Dönüş**: 
  - `data`: Ürün listesi
  - `meta`: Sayfalama bilgileri
    - `request_id`: İstek ID'si
    - `pagination`: Sayfalama detayları
      - `per_page`: Sayfa başına sonuç sayısı
      - `next`: Sonraki sayfa için URL
      - `has_more`: Daha fazla sonuç olup olmadığı
      - `estimated_total`: Tahmini toplam sonuç sayısı

### POST /products
- **Açıklama**: Yeni bir ürün oluşturur
- **İstek Gövdesi**:
  - `name` (required): Ürün adı (max 200 karakter)
  - `tax_category` (required): Vergi kategorisi
  - `description` (optional): Ürün açıklaması (max 2048 karakter)
  - `image_url` (optional): Ürün görseli URL'i
  - `custom_data` (optional): Özel veri alanı
- **Dönüş**:
  - `data`: Oluşturulan ürün bilgileri
  - `meta`: İstek meta bilgileri

### PATCH /products/{id}
- **Açıklama**: Var olan bir ürünü günceller
- **Path Parametreleri**:
  - `id` (required): Güncellenecek ürünün ID'si
- **İstek Gövdesi**:
  - `name` (optional): Yeni ürün adı
  - `description` (optional): Yeni ürün açıklaması
  - `image_url` (optional): Yeni ürün görseli URL'i
  - `custom_data` (optional): Yeni özel veri
- **Dönüş**:
  - `data`: Güncellenmiş ürün bilgileri
  - `meta`: İstek meta bilgileri

## Müşteriler (Customers)

### GET /customers
- **Açıklama**: Müşteri listesini getirir
- **Parametreler**: 
  - `after` (query, optional): Sayfalama için cursor
  - `email` (query, optional): E-posta adresi ile filtreleme
  - `id` (query, optional): Belirli müşteri ID'leri ile filtreleme
  - `order_by` (query, optional): Sıralama kriteri
  - `per_page` (query, optional): Sayfa başına sonuç sayısı
  - `search` (query, optional): Müşteri bilgilerinde arama yapma
- **Dönüş**: 
  - `data`: Müşteri listesi
  - `meta`: Sayfalama bilgileri

### POST /customers
- **Açıklama**: Yeni bir müşteri oluşturur
- **İstek Gövdesi**:
  - `email` (required): Müşteri e-posta adresi
  - `name` (optional): Müşteri tam adı
  - `locale` (optional): Dil tercihi (default: en)
  - `custom_data` (optional): Özel veri alanı
- **Dönüş**:
  - `data`: Oluşturulan müşteri bilgileri
  - `meta`: İstek meta bilgileri

### GET /customers/{customer_id}
- **Açıklama**: Belirli bir müşterinin detaylarını getirir
- **Path Parametreleri**:
  - `customer_id` (required): Müşteri ID'si
- **Dönüş**:
  - `data`: Müşteri detayları
  - `meta`: İstek meta bilgileri

### PATCH /customers/{customer_id}
- **Açıklama**: Var olan bir müşteriyi günceller
- **Path Parametreleri**:
  - `customer_id` (required): Müşteri ID'si
- **İstek Gövdesi**:
  - `name` (optional): Yeni müşteri adı
  - `email` (optional): Yeni e-posta adresi
  - `locale` (optional): Yeni dil tercihi
  - `custom_data` (optional): Yeni özel veri
- **Dönüş**:
  - `data`: Güncellenmiş müşteri bilgileri
  - `meta`: İstek meta bilgileri

### GET /customers/{customer_id}/businesses
- **Açıklama**: Müşteriye ait işletmeleri listeler
- **Path Parametreleri**:
  - `customer_id` (required): Müşteri ID'si
- **Parametreler**:
  - `after` (query, optional): Sayfalama için cursor
  - `id` (query, optional): İşletme ID'leri ile filtreleme
  - `order_by` (query, optional): Sıralama kriteri
  - `per_page` (query, optional): Sayfa başına sonuç sayısı
- **Dönüş**:
  - `data`: İşletme listesi
  - `meta`: Sayfalama bilgileri

## Abonelikler (Subscriptions)

### GET /subscriptions
- **Açıklama**: Abonelik listesini getirir
- **Parametreler**: 
  - `after` (query, optional): Sayfalama için cursor
  - `customer_id` (query, optional): Müşteri ID'si ile filtreleme
  - `id` (query, optional): Belirli abonelik ID'leri ile filtreleme
  - `status` (query, optional): Abonelik durumu ile filtreleme
  - `collection_mode` (query, optional): Tahsilat modu ile filtreleme (automatic/manual)
  - `price_id` (query, optional): Fiyat ID'si ile filtreleme
  - `order_by` (query, optional): Sıralama kriteri
  - `per_page` (query, optional): Sayfa başına sonuç sayısı
- **Dönüş**: 
  - `data`: Abonelik listesi
  - `meta`: Sayfalama bilgileri

### POST /subscriptions/{subscription_id}/cancel
- **Açıklama**: Bir aboneliği iptal eder
- **Path Parametreleri**:
  - `subscription_id` (required): İptal edilecek aboneliğin ID'si
- **İstek Gövdesi**:
  - `effective_from` (required): İptalin ne zaman geçerli olacağı (immediately/next_billing_period)
- **Dönüş**:
  - `data`: İptal edilen abonelik bilgileri
  - `meta`: İstek meta bilgileri

### POST /subscriptions/{subscription_id}/pause
- **Açıklama**: Bir aboneliği duraklatır
- **Path Parametreleri**:
  - `subscription_id` (required): Duraklatılacak aboneliğin ID'si
- **İstek Gövdesi**:
  - `effective_from` (required): Duraklatmanın ne zaman geçerli olacağı (immediately/next_billing_period)
- **Dönüş**:
  - `data`: Duraklatılan abonelik bilgileri
  - `meta`: İstek meta bilgileri

### POST /subscriptions/{subscription_id}/resume
- **Açıklama**: Duraklatılmış bir aboneliği devam ettirir
- **Path Parametreleri**:
  - `subscription_id` (required): Devam ettirilecek aboneliğin ID'si
- **İstek Gövdesi**:
  - `effective_from` (required): Devam ettirmenin ne zaman geçerli olacağı (immediately/next_billing_period)
- **Dönüş**:
  - `data`: Devam ettirilen abonelik bilgileri
  - `meta`: İstek meta bilgileri

### POST /subscriptions/{subscription_id}/activate
- **Açıklama**: Deneme sürecindeki bir aboneliği aktifleştirir
- **Path Parametreleri**:
  - `subscription_id` (required): Aktifleştirilecek aboneliğin ID'si
- **Dönüş**:
  - `data`: Aktifleştirilen abonelik bilgileri
  - `meta`: İstek meta bilgileri

### POST /subscriptions/{subscription_id}/charge
- **Açıklama**: Bir aboneliğe tek seferlik ücret ekler
- **Path Parametreleri**:
  - `subscription_id` (required): Ücret eklenecek aboneliğin ID'si
- **İstek Gövdesi**:
  - `effective_from` (required): Ücretin ne zaman tahsil edileceği (immediately/next_billing_period)
  - `items` (required): Ücret kalemleri listesi
    - `price_id` (required): Fiyat ID'si
    - `quantity` (required): Miktar
- **Dönüş**:
  - `data`: Güncellenen abonelik bilgileri
  - `meta`: İstek meta bilgileri

## Fiyatlar (Prices)

### GET /prices
- **Açıklama**: Fiyat listesini getirir
- **Parametreler**: 
  - `after` (query, optional): Sayfalama için cursor
  - `id` (query, optional): Belirli fiyat ID'leri ile filtreleme
  - `product_id` (query, optional): Ürün ID'si ile filtreleme
  - `status` (query, optional): Fiyat durumu ile filtreleme (active/archived)
  - `type` (query, optional): Fiyat tipi ile filtreleme (standard/custom)
- **Dönüş**: 
  - `data`: Fiyat listesi
  - `meta`: Sayfalama bilgileri

### POST /prices
- **Açıklama**: Yeni bir fiyat oluşturur
- **İstek Gövdesi**:
  - `product_id` (required): Ürün ID'si
  - `description` (required): Fiyat açıklaması (2-200 karakter)
  - `name` (optional): Fiyat adı (1-50 karakter)
  - `billing_cycle` (optional): Faturalandırma döngüsü
    - `interval`: Döngü aralığı (day/week/month/year)
    - `frequency`: Döngü frekansı
  - `trial_period` (optional): Deneme süresi
    - `interval`: Döngü aralığı
    - `frequency`: Döngü frekansı
  - `tax_mode` (required): Vergi modu
  - `unit_price` (required): Birim fiyat
    - `amount`: Tutar (string olarak)
    - `currency_code`: Para birimi
  - `unit_price_overrides` (optional): Ülkeye özel fiyat tanımları
  - `quantity` (optional): Miktar sınırları
    - `minimum`: Minimum miktar
    - `maximum`: Maksimum miktar
- **Dönüş**:
  - `data`: Oluşturulan fiyat bilgileri
  - `meta`: İstek meta bilgileri

### GET /prices/{price_id}
- **Açıklama**: Belirli bir fiyatın detaylarını getirir
- **Path Parametreleri**:
  - `price_id` (required): Fiyat ID'si
- **Dönüş**:
  - `data`: Fiyat detayları
  - `meta`: İstek meta bilgileri

### PATCH /prices/{price_id}
- **Açıklama**: Var olan bir fiyatı günceller
- **Path Parametreleri**:
  - `price_id` (required): Fiyat ID'si
- **İstek Gövdesi**:
  - `description` (optional): Yeni fiyat açıklaması
  - `name` (optional): Yeni fiyat adı
  - `status` (optional): Yeni fiyat durumu
  - `quantity` (optional): Yeni miktar sınırları
  - `custom_data` (optional): Yeni özel veri
- **Dönüş**:
  - `data`: Güncellenmiş fiyat bilgileri
  - `meta`: İstek meta bilgileri

### POST /prices/preview
- **Açıklama**: Bir veya daha fazla fiyat için hesaplama önizlemesi yapar
- **İstek Gövdesi**:
  - `items` (required): Fiyat kalemleri
    - `price_id`: Fiyat ID'si
    - `quantity`: Miktar
  - `currency_code` (optional): Para birimi
  - `address` (optional): Adres bilgileri
  - `discount_id` (optional): İndirim ID'si
  - `customer_ip_address` (optional): Müşteri IP adresi
- **Dönüş**:
  - `data`: Hesaplama detayları
    - `items`: Kalem bazında hesaplamalar
    - `totals`: Genel toplamlar
    - `tax_rates_used`: Kullanılan vergi oranları
  - `meta`: İstek meta bilgileri

## İşlemler (Transactions)

### GET /transactions
- **Açıklama**: İşlem listesini getirir
- **Parametreler**: 
  - `after` (query, optional): Sayfalama için cursor
  - `id` (query, optional): Belirli işlem ID'leri ile filtreleme
  - `customer_id` (query, optional): Müşteri ID'si ile filtreleme
  - `subscription_id` (query, optional): Abonelik ID'si ile filtreleme
  - `status` (query, optional): İşlem durumu ile filtreleme
  - `origin` (query, optional): İşlem kaynağı ile filtreleme (api/subscription_charge/subscription_payment_method_change/subscription_recurring/subscription_update/web)
  - `created_at` (query, optional): Oluşturulma tarihine göre filtreleme
  - `currency_code` (query, optional): Para birimine göre filtreleme
- **Dönüş**: 
  - `data`: İşlem listesi
  - `meta`: Sayfalama bilgileri

### POST /transactions
- **Açıklama**: Yeni bir işlem oluşturur
- **İstek Gövdesi**:
  - `items` (required): İşlem kalemleri
    - `price_id` (required): Fiyat ID'si
    - `quantity` (required): Miktar
  - `customer_id` (required): Müşteri ID'si
  - `address_id` (optional): Adres ID'si
  - `business_id` (optional): İşletme ID'si
  - `currency_code` (optional): Para birimi
  - `discount_id` (optional): İndirim ID'si
  - `custom_data` (optional): Özel veri
  - `collection_mode` (optional): Tahsilat modu (automatic/manual)
  - `billing_details` (optional): Faturalandırma detayları
  - `billing_period` (optional): Faturalandırma dönemi
- **Dönüş**:
  - `data`: Oluşturulan işlem bilgileri
  - `meta`: İstek meta bilgileri

### GET /transactions/{transaction_id}
- **Açıklama**: Belirli bir işlemin detaylarını getirir
- **Path Parametreleri**:
  - `transaction_id` (required): İşlem ID'si
- **Dönüş**:
  - `data`: İşlem detayları
  - `meta`: İstek meta bilgileri

### PATCH /transactions/{transaction_id}
- **Açıklama**: Var olan bir işlemi günceller
- **Path Parametreleri**:
  - `transaction_id` (required): İşlem ID'si
- **İstek Gövdesi**:
  - `status` (optional): İşlem durumu (billed/canceled)
  - `customer_id` (optional): Müşteri ID'si
  - `address_id` (optional): Adres ID'si
  - `business_id` (optional): İşletme ID'si
  - `currency_code` (optional): Para birimi
  - `discount_id` (optional): İndirim ID'si
  - `custom_data` (optional): Özel veri
  - `billing_details` (optional): Faturalandırma detayları
  - `items` (optional): İşlem kalemleri
- **Dönüş**:
  - `data`: Güncellenmiş işlem bilgileri
  - `meta`: İstek meta bilgileri

### POST /transactions/preview
- **Açıklama**: Bir işlem için hesaplama önizlemesi yapar
- **İstek Gövdesi**:
  - `items` (required): İşlem kalemleri
    - `price_id` (required): Fiyat ID'si
    - `quantity` (required): Miktar
  - `currency_code` (optional): Para birimi
  - `address` (optional): Adres bilgileri
  - `customer_id` (optional): Müşteri ID'si
  - `discount_id` (optional): İndirim ID'si
- **Dönüş**:
  - `data`: Hesaplama detayları
    - `items`: Kalem bazında hesaplamalar
    - `totals`: Genel toplamlar
    - `tax_rates_used`: Kullanılan vergi oranları
  - `meta`: İstek meta bilgileri

## İndirimler (Discounts)

### GET /discounts
- **Açıklama**: İndirim listesini getirir
- **Parametreler**: 
  - `after` (query, optional): Sayfalama için cursor
  - `id` (query, optional): Belirli indirim ID'leri ile filtreleme
  - `status` (query, optional): İndirim durumu ile filtreleme (active/archived)
  - `order_by` (query, optional): Sıralama kriteri (created_at, id)
  - `per_page` (query, optional): Sayfa başına sonuç sayısı
- **Dönüş**: 
  - `data`: İndirim listesi
  - `meta`: Sayfalama bilgileri

### POST /discounts
- **Açıklama**: Yeni bir indirim oluşturur
- **İstek Gövdesi**:
  - `description` (required): İndirim açıklaması (1-254 karakter)
  - `enabled_for_checkout` (optional): Checkout'ta kullanılabilir mi? (default: true)
  - `code` (required): İndirim kodu (1-32 karakter, sadece harf ve rakam)
  - `type` (required): İndirim tipi (flat/flat_per_seat/percentage)
  - `amount` (required): İndirim tutarı (percentage için 0.01-100 arası, diğerleri için en küçük para birimi cinsinden)
  - `currency_code` (required for flat/flat_per_seat): Para birimi
  - `recur` (optional): Tekrarlayan ödemelere uygulanacak mı? (default: false)
  - `maximum_recurring_intervals` (optional): Maksimum tekrar sayısı
  - `usage_limit` (optional): Maksimum kullanım sayısı
  - `restrict_to` (optional): Ürün veya fiyat ID'leri listesi
  - `expires_at` (optional): Son kullanma tarihi
- **Dönüş**:
  - `data`: Oluşturulan indirim bilgileri
  - `meta`: İstek meta bilgileri

### GET /discounts/{discount_id}
- **Açıklama**: Belirli bir indirimin detaylarını getirir
- **Path Parametreleri**:
  - `discount_id` (required): İndirim ID'si
- **Dönüş**:
  - `data`: İndirim detayları
  - `meta`: İstek meta bilgileri

### PATCH /discounts/{discount_id}
- **Açıklama**: Var olan bir indirimi günceller
- **Path Parametreleri**:
  - `discount_id` (required): İndirim ID'si
- **İstek Gövdesi**:
  - `description` (optional): Yeni indirim açıklaması
  - `enabled_for_checkout` (optional): Checkout'ta kullanılabilir mi?
  - `code` (optional): Yeni indirim kodu
  - `status` (optional): Yeni indirim durumu
  - `restrict_to` (optional): Yeni ürün veya fiyat ID'leri listesi
  - `expires_at` (optional): Yeni son kullanma tarihi
  - `custom_data` (optional): Yeni özel veri
- **Dönüş**:
  - `data`: Güncellenmiş indirim bilgileri
  - `meta`: İstek meta bilgileri

## Bildirimler (Notifications)

### GET /notifications

Bildirimleri listeler.

**Query Parametreleri:**
- `per_page` (optional): Sayfa başına sonuç sayısı (default: 10)
- `after` (optional): Bu ID'den sonraki sonuçları getirir
- `status` (optional): Bildirim durumuna göre filtreler (delivered/failed)
- `notification_setting_id` (optional): Bildirim ayarı ID'sine göre filtreler
- `event_type` (optional): Olay tipine göre filtreler
- `from` (optional): Bu tarihten sonraki bildirimleri getirir (ISO 8601)
- `to` (optional): Bu tarihten önceki bildirimleri getirir (ISO 8601)

**Yanıt:**
```json
{
  "data": [
    {
      "id": "ntf_...",
      "type": "transaction.created",
      "status": "delivered",
      "payload": { ... },
      "event_id": "evt_...",
      "notification_setting_id": "ntfset_...",
      "created_at": "2023-01-01T12:00:00Z",
      "updated_at": "2023-01-01T12:00:00Z"
    }
  ],
  "meta": {
    "request_id": "...",
    "pagination": {
      "per_page": 10,
      "next": "ntf_..."
    }
  }
}
```

### GET /notifications/{notification_id}

Belirli bir bildirimin detaylarını getirir.

**Path Parametreleri:**
- `notification_id` (required): Bildirim ID'si

**Yanıt:**
```json
{
  "data": {
    "id": "ntf_...",
    "type": "transaction.created",
    "status": "delivered",
    "payload": { ... },
    "event_id": "evt_...",
    "notification_setting_id": "ntfset_...",
    "created_at": "2023-01-01T12:00:00Z",
    "updated_at": "2023-01-01T12:00:00Z"
  },
  "meta": {
    "request_id": "..."
  }
}
```

### GET /notification-settings

Bildirim ayarlarını listeler.

**Query Parametreleri:**
- `per_page` (optional): Sayfa başına sonuç sayısı (default: 10)
- `after` (optional): Bu ID'den sonraki sonuçları getirir
- `active` (optional): Aktiflik durumuna göre filtreler (true/false)
- `type` (optional): Bildirim tipine göre filtreler (email/url)

**Yanıt:**
```json
{
  "data": [
    {
      "id": "ntfset_...",
      "description": "My webhook endpoint",
      "type": "url",
      "destination": "https://example.com/webhook",
      "active": true,
      "api_version": 1,
      "include_sensitive_fields": false,
      "subscribed_events": ["transaction.created"],
      "endpoint_secret_key": "pdl_ntfset_...",
      "traffic_source": "platform"
    }
  ],
  "meta": {
    "request_id": "...",
    "pagination": {
      "per_page": 10,
      "next": "ntfset_..."
    }
  }
}
```

### POST /notification-settings

Yeni bir bildirim ayarı oluşturur.

**Request Body:**
```json
{
  "description": "My webhook endpoint",
  "type": "url",
  "destination": "https://example.com/webhook",
  "active": true,
  "api_version": 1,
  "include_sensitive_fields": false,
  "subscribed_events": ["transaction.created"],
  "traffic_source": "platform"
}
```

**Yanıt:**
```json
{
  "data": {
    "id": "ntfset_...",
    "description": "My webhook endpoint",
    "type": "url",
    "destination": "https://example.com/webhook",
    "active": true,
    "api_version": 1,
    "include_sensitive_fields": false,
    "subscribed_events": ["transaction.created"],
    "endpoint_secret_key": "pdl_ntfset_...",
    "traffic_source": "platform"
  },
  "meta": {
    "request_id": "..."
  }
}
```

### GET /notification-settings/{notification_setting_id}

Belirli bir bildirim ayarının detaylarını getirir.

**Path Parametreleri:**
- `notification_setting_id` (required): Bildirim ayarı ID'si

**Yanıt:**
```json
{
  "data": {
    "id": "ntfset_...",
    "description": "My webhook endpoint",
    "type": "url",
    "destination": "https://example.com/webhook",
    "active": true,
    "api_version": 1,
    "include_sensitive_fields": false,
    "subscribed_events": ["transaction.created"],
    "endpoint_secret_key": "pdl_ntfset_...",
    "traffic_source": "platform"
  },
  "meta": {
    "request_id": "..."
  }
}
```

### PATCH /notification-settings/{notification_setting_id}

Belirli bir bildirim ayarını günceller.

**Path Parametreleri:**
- `notification_setting_id` (required): Bildirim ayarı ID'si

**Request Body:**
```json
{
  "description": "Updated webhook endpoint",
  "destination": "https://example.com/new-webhook",
  "active": false,
  "api_version": 2,
  "include_sensitive_fields": true,
  "subscribed_events": ["transaction.created", "subscription.updated"],
  "traffic_source": "all"
}
```

**Yanıt:**
```json
{
  "data": {
    "id": "ntfset_...",
    "description": "Updated webhook endpoint",
    "type": "url",
    "destination": "https://example.com/new-webhook",
    "active": false,
    "api_version": 2,
    "include_sensitive_fields": true,
    "subscribed_events": ["transaction.created", "subscription.updated"],
    "endpoint_secret_key": "pdl_ntfset_...",
    "traffic_source": "all"
  },
  "meta": {
    "request_id": "..."
  }
}
```

### GET /event-types

Kullanılabilir olay tiplerini listeler.

**Yanıt:**
```json
{
  "data": [
    {
      "name": "transaction.created",
      "description": "Fired when a transaction is created",
      "group": "Transaction",
      "available_versions": [1, 2]
    }
  ],
  "meta": {
    "request_id": "..."
  }
}
```

## Adresler (Addresses)

### GET /addresses
- **Açıklama**: Adres listesini getirir
- **Parametreler**: 
  - `after` (query, optional): Sayfalama için cursor
  - `id` (query, optional): Belirli adres ID'leri ile filtreleme
  - `customer_id` (query, optional): Müşteri ID'si ile filtreleme
  - `status` (query, optional): Adres durumu ile filtreleme (active/archived)
  - `country_code` (query, optional): Ülke kodu ile filtreleme
  - `postal_code` (query, optional): Posta kodu ile filtreleme
- **Dönüş**: 
  - `data`: Adres listesi
  - `meta`: Sayfalama bilgileri

### POST /addresses
- **Açıklama**: Yeni bir adres oluşturur
- **İstek Gövdesi**:
  - `customer_id` (required): Müşteri ID'si
  - `description` (optional): Adres açıklaması
  - `first_line` (required): Adres satırı 1
  - `second_line` (optional): Adres satırı 2
  - `city` (required): Şehir
  - `postal_code` (required): Posta kodu
  - `region` (optional): Bölge/Eyalet
  - `country_code` (required): Ülke kodu (ISO 3166-1 alpha-2)
  - `custom_data` (optional): Özel veri alanı
- **Dönüş**:
  - `data`: Oluşturulan adres bilgileri
  - `meta`: İstek meta bilgileri

### GET /addresses/{address_id}
- **Açıklama**: Belirli bir adresin detaylarını getirir
- **Path Parametreleri**:
  - `address_id` (required): Adres ID'si
- **Dönüş**:
  - `data`: Adres detayları
  - `meta`: İstek meta bilgileri

### PATCH /addresses/{address_id}
- **Açıklama**: Var olan bir adresi günceller
- **Path Parametreleri**:
  - `address_id` (required): Adres ID'si
- **İstek Gövdesi**:
  - `description` (optional): Yeni adres açıklaması
  - `first_line` (optional): Yeni adres satırı 1
  - `second_line` (optional): Yeni adres satırı 2
  - `city` (optional): Yeni şehir
  - `postal_code` (optional): Yeni posta kodu
  - `region` (optional): Yeni bölge/eyalet
  - `country_code` (optional): Yeni ülke kodu
  - `status` (optional): Yeni adres durumu
  - `custom_data` (optional): Yeni özel veri
- **Dönüş**:
  - `data`: Güncellenmiş adres bilgileri
  - `meta`: İstek meta bilgileri

## Katalog (Catalog)

### GET /catalog/products
- **Açıklama**: Katalog ürünlerini listeler
- **Parametreler**: 
  - `after` (query, optional): Sayfalama için cursor
  - `id` (query, optional): Belirli ürün ID'leri ile filtreleme
  - `status` (query, optional): Ürün durumu ile filtreleme (active/archived)
  - `type` (query, optional): Ürün tipi ile filtreleme (standard/custom)
  - `tax_category` (query, optional): Vergi kategorisi ile filtreleme
  - `include` (query, optional): İlişkili varlıkları dahil etme (prices)
- **Dönüş**: 
  - `data`: Katalog ürünleri listesi
  - `meta`: Sayfalama bilgileri

### GET /catalog/prices
- **Açıklama**: Katalog fiyatlarını listeler
- **Parametreler**: 
  - `after` (query, optional): Sayfalama için cursor
  - `id` (query, optional): Belirli fiyat ID'leri ile filtreleme
  - `product_id` (query, optional): Ürün ID'si ile filtreleme
  - `status` (query, optional): Fiyat durumu ile filtreleme (active/archived)
  - `type` (query, optional): Fiyat tipi ile filtreleme (standard/custom)
  - `billing_cycle` (query, optional): Faturalandırma döngüsü ile filtreleme
  - `trial_period` (query, optional): Deneme süresi ile filtreleme
- **Dönüş**: 
  - `data`: Katalog fiyatları listesi
  - `meta`: Sayfalama bilgileri

### GET /catalog/products/{product_id}/prices
- **Açıklama**: Belirli bir ürünün fiyatlarını listeler
- **Path Parametreleri**:
  - `product_id` (required): Ürün ID'si
- **Parametreler**: 
  - `after` (query, optional): Sayfalama için cursor
  - `status` (query, optional): Fiyat durumu ile filtreleme
  - `type` (query, optional): Fiyat tipi ile filtreleme
- **Dönüş**: 
  - `data`: Ürün fiyatları listesi
  - `meta`: Sayfalama bilgileri

### POST /catalog/products
- **Açıklama**: Yeni bir katalog ürünü oluşturur
- **İstek Gövdesi**:
  - `name` (required): Ürün adı
  - `tax_category` (required): Vergi kategorisi
  - `description` (optional): Ürün açıklaması
  - `image_url` (optional): Ürün görseli URL'i
  - `custom_data` (optional): Özel veri alanı
  - `type` (optional): Ürün tipi (default: standard)
- **Dönüş**:
  - `data`: Oluşturulan ürün bilgileri
  - `meta`: İstek meta bilgileri

### POST /catalog/prices
- **Açıklama**: Yeni bir katalog fiyatı oluşturur
- **İstek Gövdesi**:
  - `product_id` (required): Ürün ID'si
  - `description` (required): Fiyat açıklaması
  - `name` (optional): Fiyat adı
  - `billing_cycle` (optional): Faturalandırma döngüsü
  - `trial_period` (optional): Deneme süresi
  - `tax_mode` (required): Vergi modu
  - `unit_price` (required): Birim fiyat
  - `unit_price_overrides` (optional): Ülkeye özel fiyat tanımları
  - `quantity` (optional): Miktar sınırları
  - `type` (optional): Fiyat tipi (default: standard)
- **Dönüş**:
  - `data`: Oluşturulan fiyat bilgileri
  - `meta`: İstek meta bilgileri

### PATCH /catalog/products/{product_id}
- **Açıklama**: Var olan bir katalog ürününü günceller
- **Path Parametreleri**:
  - `product_id` (required): Ürün ID'si
- **İstek Gövdesi**:
  - `name` (optional): Yeni ürün adı
  - `description` (optional): Yeni ürün açıklaması
  - `image_url` (optional): Yeni ürün görseli URL'i
  - `custom_data` (optional): Yeni özel veri
  - `status` (optional): Yeni ürün durumu
- **Dönüş**:
  - `data`: Güncellenmiş ürün bilgileri
  - `meta`: İstek meta bilgileri

### PATCH /catalog/prices/{price_id}
- **Açıklama**: Var olan bir katalog fiyatını günceller
- **Path Parametreleri**:
  - `price_id` (required): Fiyat ID'si
- **İstek Gövdesi**:
  - `description` (optional): Yeni fiyat açıklaması
  - `name` (optional): Yeni fiyat adı
  - `status` (optional): Yeni fiyat durumu
  - `quantity` (optional): Yeni miktar sınırları
  - `custom_data` (optional): Yeni özel veri
- **Dönüş**:
  - `data`: Güncellenmiş fiyat bilgileri
  - `meta`: İstek meta bilgileri

## Simülasyonlar (Simulations)

### POST /notifications/simulate
- **Açıklama**: Webhook bildirimlerini simüle eder
- **İstek Gövdesi**:
  - `type` (required): Simüle edilecek bildirim tipi
  - `data` (required): Simülasyon için gerekli veri
  - `notification_settings` (optional): Bildirim ayarları
    - `destination` (optional): Bildirim URL'i
    - `api_key` (optional): API anahtarı
    - `include_sensitive_fields` (optional): Hassas alanları dahil etme
- **Dönüş**:
  - `data`: Simülasyon sonucu
  - `meta`: İstek meta bilgileri

### POST /transactions/preview
- **Açıklama**: İşlem hesaplamalarını simüle eder
- **İstek Gövdesi**:
  - `items` (required): İşlem kalemleri
    - `price_id` (required): Fiyat ID'si
    - `quantity` (required): Miktar
  - `customer_id` (optional): Müşteri ID'si
  - `address_id` (optional): Adres ID'si
  - `business_id` (optional): İşletme ID'si
  - `currency_code` (optional): Para birimi
  - `discount_id` (optional): İndirim ID'si
  - `custom_data` (optional): Özel veri
- **Dönüş**:
  - `data`: Hesaplama sonuçları
    - `details`: İşlem detayları
    - `billing`: Faturalandırma bilgileri
    - `adjustments`: Fiyat ayarlamaları
    - `tax`: Vergi hesaplamaları
  - `meta`: İstek meta bilgileri

### POST /prices/preview
- **Açıklama**: Fiyat hesaplamalarını simüle eder
- **İstek Gövdesi**:
  - `items` (required): Fiyat kalemleri
    - `price_id` (required): Fiyat ID'si
    - `quantity` (required): Miktar
  - `address` (optional): Adres bilgileri
    - `country_code` (required): Ülke kodu
    - `postal_code` (optional): Posta kodu
  - `currency_code` (optional): Para birimi
- **Dönüş**:
  - `data`: Hesaplama sonuçları
    - `items`: Kalem bazında hesaplamalar
    - `totals`: Toplam tutarlar
    - `tax`: Vergi hesaplamaları
  - `meta`: İstek meta bilgileri

## İşlem Revizyonları (Transaction Revisions)

### GET /transactions/{transaction_id}/revisions
- **Açıklama**: Bir işlemin revizyon geçmişini listeler
- **Path Parametreleri**:
  - `transaction_id` (required): İşlem ID'si
- **Parametreler**: 
  - `after` (query, optional): Sayfalama için cursor
  - `include` (query, optional): İlişkili varlıkları dahil etme
- **Dönüş**: 
  - `data`: Revizyon listesi
  - `meta`: Sayfalama bilgileri

### GET /transactions/{transaction_id}/revisions/{revision_id}
- **Açıklama**: Belirli bir işlem revizyonunun detaylarını getirir
- **Path Parametreleri**:
  - `transaction_id` (required): İşlem ID'si
  - `revision_id` (required): Revizyon ID'si
- **Parametreler**: 
  - `include` (query, optional): İlişkili varlıkları dahil etme
- **Dönüş**: 
  - `data`: Revizyon detayları
  - `meta`: İstek meta bilgileri

### POST /transactions/{transaction_id}/revisions
- **Açıklama**: Bir işlem için yeni bir revizyon oluşturur
- **Path Parametreleri**:
  - `transaction_id` (required): İşlem ID'si
- **İstek Gövdesi**:
  - `reason` (required): Revizyon nedeni
  - `details` (required): Revizyon detayları
    - `customer_id` (optional): Yeni müşteri ID'si
    - `address_id` (optional): Yeni adres ID'si
    - `business_id` (optional): Yeni işletme ID'si
    - `items` (optional): Güncellenmiş işlem kalemleri
    - `billing` (optional): Güncellenmiş faturalandırma bilgileri
    - `adjustments` (optional): Güncellenmiş fiyat ayarlamaları
    - `custom_data` (optional): Güncellenmiş özel veri
  - `notes` (optional): Revizyon notları
- **Dönüş**:
  - `data`: Oluşturulan revizyon bilgileri
  - `meta`: İstek meta bilgileri

### PATCH /transactions/{transaction_id}/revisions/{revision_id}
- **Açıklama**: Var olan bir işlem revizyonunu günceller
- **Path Parametreleri**:
  - `transaction_id` (required): İşlem ID'si
  - `revision_id` (required): Revizyon ID'si
- **İstek Gövdesi**:
  - `reason` (optional): Yeni revizyon nedeni
  - `notes` (optional): Yeni revizyon notları
  - `status` (optional): Yeni revizyon durumu
- **Dönüş**:
  - `data`: Güncellenmiş revizyon bilgileri
  - `meta`: İstek meta bilgileri