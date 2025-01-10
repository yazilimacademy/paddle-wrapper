namespace PaddleWrapper.Core.Models.Event
{
    /// <summary>
    /// Olay bilgilerini temsil eden sınıf.
    /// </summary>
    public class Event
    {
        /// <summary>
        /// Olay ID'si
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Olay tipi
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Olayın gerçekleşme tarihi
        /// </summary>
        public DateTime OccurredAt { get; set; }

        /// <summary>
        /// Olayın kaynağı
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// İlgili müşteri ID'si
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// İlgili abonelik ID'si
        /// </summary>
        public string SubscriptionId { get; set; }

        /// <summary>
        /// İlgili işlem ID'si
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// Olayın verileri
        /// </summary>
        public Dictionary<string, object> Data { get; set; }

        /// <summary>
        /// Olayın meta verileri
        /// </summary>
        public EventMetadata Metadata { get; set; }

        /// <summary>
        /// Olayın durumu
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Olayın işlenme tarihi
        /// </summary>
        public DateTime? ProcessedAt { get; set; }

        /// <summary>
        /// Olayın yeniden deneme sayısı
        /// </summary>
        public int RetryCount { get; set; }

        /// <summary>
        /// Olayın son hata mesajı
        /// </summary>
        public string LastError { get; set; }
    }

    /// <summary>
    /// Olay meta verilerini temsil eden sınıf.
    /// </summary>
    public class EventMetadata
    {
        /// <summary>
        /// İstek ID'si
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// IP adresi
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// User Agent bilgisi
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// Özel alanlar
        /// </summary>
        public Dictionary<string, string> CustomFields { get; set; }
    }
}