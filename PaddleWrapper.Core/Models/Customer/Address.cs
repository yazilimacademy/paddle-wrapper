using System;

namespace PaddleWrapper.Core.Models.Customer
{
    /// <summary>
    /// Adres bilgilerini temsil eden sınıf.
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Adres ID'si
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Adres satırı 1
        /// </summary>
        public string Line1 { get; set; }

        /// <summary>
        /// Adres satırı 2
        /// </summary>
        public string Line2 { get; set; }

        /// <summary>
        /// Şehir
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Eyalet/Bölge
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Posta kodu
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Ülke kodu (ISO 3166-1 alpha-2)
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Adres tipi (fatura, teslimat vb.)
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Adresin varsayılan olup olmadığı
        /// </summary>
        public bool IsDefault { get; set; }

        /// <summary>
        /// Adresin oluşturulma tarihi
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Adresin son güncelleme tarihi
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }
} 