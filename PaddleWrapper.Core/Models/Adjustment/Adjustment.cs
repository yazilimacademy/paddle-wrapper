namespace PaddleWrapper.Core.Models.Adjustment
{
    /// <summary>
    /// Ayarlama bilgilerini temsil eden sınıf.
    /// </summary>
    public class Adjustment
    {
        /// <summary>
        /// Ayarlama ID'si
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Ayarlama tipi (kredi, borç vb.)
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Ayarlama işlemi (ekleme, çıkarma vb.)
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// Ayarlama miktarı
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Para birimi
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// İlgili abonelik ID'si
        /// </summary>
        public string SubscriptionId { get; set; }

        /// <summary>
        /// İlgili müşteri ID'si
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// Ayarlama açıklaması
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Ayarlamanın durumu
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Ayarlamanın oluşturulma tarihi
        /// </summary>
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Ayarlamanın son güncelleme tarihi
        /// </summary>
        public DateTimeOffset UpdatedAt { get; set; }

        /// <summary>
        /// Ayarlamanın uygulanma tarihi
        /// </summary>
        public DateTimeOffset? AppliedAt { get; set; }

        /// <summary>
        /// Ayarlamayı yapan kullanıcı ID'si
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Ayarlamanın özel alanları
        /// </summary>
        public AdjustmentMetadata Metadata { get; set; }
    }

    /// <summary>
    /// Ayarlama meta verilerini temsil eden sınıf.
    /// </summary>
    public class AdjustmentMetadata
    {
        /// <summary>
        /// Ayarlama nedeni
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// İlgili fatura ID'si
        /// </summary>
        public string InvoiceId { get; set; }

        /// <summary>
        /// İlgili işlem ID'si
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// Özel notlar
        /// </summary>
        public string Notes { get; set; }
    }
}