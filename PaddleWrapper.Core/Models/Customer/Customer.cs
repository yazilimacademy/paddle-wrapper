namespace PaddleWrapper.Core.Models.Customer
{
    /// <summary>
    /// Müşteri bilgilerini temsil eden sınıf.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Müşteri ID'si
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Müşteri e-posta adresi
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Müşteri adı
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Müşterinin telefon numarası (isteğe bağlı)
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Müşterinin varsayılan adresi
        /// </summary>
        public Address DefaultAddress { get; set; }

        /// <summary>
        /// Müşterinin tüm adresleri
        /// </summary>
        public List<Address> Addresses { get; set; } = new List<Address>();

        /// <summary>
        /// Müşterinin işletme bilgileri
        /// </summary>
        public Business Business { get; set; }

        /// <summary>
        /// Müşterinin özel alanları
        /// </summary>
        public Dictionary<string, string> CustomData { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// Müşterinin durumu (active, archived)
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Müşterinin oluşturulma tarihi
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Müşterinin son güncelleme tarihi
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Müşterinin lokalizasyon ayarları
        /// </summary>
        public CustomerLocale Locale { get; set; }

        /// <summary>
        /// Müşterinin vergi kimlik numarası
        /// </summary>
        public string TaxIdentifier { get; set; }
    }

    /// <summary>
    /// Müşteri lokalizasyon ayarlarını temsil eden sınıf.
    /// </summary>
    public class CustomerLocale
    {
        /// <summary>
        /// Dil kodu (ISO 639-1)
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Ülke kodu (ISO 3166-1 alpha-2)
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Para birimi (ISO 4217)
        /// </summary>
        public string Currency { get; set; }
    }
}