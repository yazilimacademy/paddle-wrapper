using System;
using System.Collections.Generic;

namespace PaddleWrapper.Core.Models.Price
{
    /// <summary>
    /// Fiyatlandırma bilgilerini temsil eden sınıf.
    /// </summary>
    public class Price
    {
        /// <summary>
        /// Fiyat ID'si
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Ürün ID'si
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// Fiyat açıklaması
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Birim fiyat
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Para birimi
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Fiyatlandırma tipi (one_time, recurring)
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Faturalama aralığı (month, year vb.)
        /// </summary>
        public string BillingPeriod { get; set; }

        /// <summary>
        /// Faturalama sıklığı
        /// </summary>
        public int? BillingFrequency { get; set; }

        /// <summary>
        /// Deneme süresi (gün)
        /// </summary>
        public int? TrialDays { get; set; }

        /// <summary>
        /// Fiyatın aktif olup olmadığı
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Fiyatın geçerli olduğu bölgeler
        /// </summary>
        public List<string> AvailableCountries { get; set; } = new List<string>();

        /// <summary>
        /// Özel vergi oranları
        /// </summary>
        public Dictionary<string, decimal> TaxRates { get; set; } = new Dictionary<string, decimal>();

        /// <summary>
        /// Fiyatın oluşturulma tarihi
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Fiyatın son güncelleme tarihi
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }
} 