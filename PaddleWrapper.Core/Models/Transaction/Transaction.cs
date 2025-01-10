using PaddleWrapper.Core.Models.Customer;

namespace PaddleWrapper.Core.Models.Transaction
{
    /// <summary>
    /// İşlem bilgilerini temsil eden sınıf.
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// İşlem ID'si
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// İşlem tutarı
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Para birimi
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// İşlem durumu
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Müşteri ID'si
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// Abonelik ID'si
        /// </summary>
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Fatura ID'si
        /// </summary>
        public string InvoiceId { get; set; }

        /// <summary>
        /// Ödeme yöntemi
        /// </summary>
        public string PaymentMethod { get; set; }

        /// <summary>
        /// Fatura adresi
        /// </summary>
        public Address BillingAddress { get; set; }

        /// <summary>
        /// Vergi tutarı
        /// </summary>
        public decimal TaxAmount { get; set; }

        /// <summary>
        /// İade tutarı
        /// </summary>
        public decimal? RefundAmount { get; set; }

        /// <summary>
        /// İade tarihi
        /// </summary>
        public DateTime? RefundedAt { get; set; }

        /// <summary>
        /// İşlem tarihi
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// İşlemin son güncelleme tarihi
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// İşlem öğeleri
        /// </summary>
        public List<TransactionItem> Items { get; set; } = new List<TransactionItem>();

        /// <summary>
        /// İşlem meta verileri
        /// </summary>
        public Dictionary<string, string> Metadata { get; set; } = new Dictionary<string, string>();
    }

    /// <summary>
    /// İşlem öğesini temsil eden sınıf.
    /// </summary>
    public class TransactionItem
    {
        /// <summary>
        /// Öğe ID'si
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Ürün ID'si
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// Fiyat ID'si
        /// </summary>
        public string PriceId { get; set; }

        /// <summary>
        /// Miktar
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Birim fiyat
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Toplam tutar
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Vergi tutarı
        /// </summary>
        public decimal TaxAmount { get; set; }
    }
}