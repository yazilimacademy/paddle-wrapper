using System;
using System.Collections.Generic;

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
        /// Müşterinin telefon numarası
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Müşterinin adresleri
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
    }

    /// <summary>
    /// Müşteri lokalizasyon ayarlarını temsil eden sınıf.
    /// </summary>
    public class CustomerLocale
    {
        /// <summary>
        /// Dil kodu
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Ülke kodu
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Para birimi
        /// </summary>
        public string Currency { get; set; }
    }
} 