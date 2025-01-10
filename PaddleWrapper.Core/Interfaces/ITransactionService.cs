using System.Threading.Tasks;
using PaddleWrapper.Core.Models;
using PaddleWrapper.Core.Models.Transaction;

namespace PaddleWrapper.Core.Interfaces
{
    /// <summary>
    /// İşlem işlemleri için servis arayüzü.
    /// </summary>
    public interface ITransactionService
    {
        /// <summary>
        /// İşlem detaylarını getirir.
        /// </summary>
        Task<PaddleResponse<Transaction>> GetTransactionAsync(string transactionId);

        /// <summary>
        /// İşlem listesini getirir.
        /// </summary>
        Task<PaddleResponse<Transaction[]>> ListTransactionsAsync();

        /// <summary>
        /// Müşterinin işlemlerini getirir.
        /// </summary>
        Task<PaddleResponse<Transaction[]>> GetCustomerTransactionsAsync(string customerId);

        /// <summary>
        /// Aboneliğin işlemlerini getirir.
        /// </summary>
        Task<PaddleResponse<Transaction[]>> GetSubscriptionTransactionsAsync(string subscriptionId);

        /// <summary>
        /// İşlemi iptal eder ve iade başlatır.
        /// </summary>
        Task<PaddleResponse<Transaction>> RefundTransactionAsync(string transactionId, decimal? amount = null);

        /// <summary>
        /// İşlem faturasını getirir.
        /// </summary>
        Task<PaddleResponse<byte[]>> GetTransactionInvoiceAsync(string transactionId);

        /// <summary>
        /// İşlem notlarını günceller.
        /// </summary>
        Task<PaddleResponse<Transaction>> UpdateTransactionNotesAsync(string transactionId, string notes);

        /// <summary>
        /// İşlem meta verilerini günceller.
        /// </summary>
        Task<PaddleResponse<Transaction>> UpdateTransactionMetadataAsync(string transactionId, Dictionary<string, string> metadata);
    }
} 