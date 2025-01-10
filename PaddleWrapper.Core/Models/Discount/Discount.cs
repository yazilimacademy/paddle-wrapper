namespace PaddleWrapper.Core.Models.Discount
{
    /// <summary>
    /// İndirim bilgilerini temsil eden sınıf.
    /// </summary>
    public class Discount
    {
        /// <summary>
        /// İndirim ID'si
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// İndirim kodu
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// İndirim açıklaması
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// İndirim tipi (yüzde, sabit tutar vb.)
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// İndirim miktarı
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// İndirimin geçerli olduğu para birimi
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// İndirimin başlangıç tarihi
        /// </summary>
        public DateTime? StartsAt { get; set; }

        /// <summary>
        /// İndirimin bitiş tarihi
        /// </summary>
        public DateTime? ExpiresAt { get; set; }

        /// <summary>
        /// İndirimin kullanım limiti
        /// </summary>
        public int? UsageLimit { get; set; }

        /// <summary>
        /// İndirimin kaç kez kullanıldığı
        /// </summary>
        public int TimesUsed { get; set; }

        /// <summary>
        /// İndirimin aktif olup olmadığı
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// İndirimin oluşturulma tarihi
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// İndirimin son güncelleme tarihi
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }
}