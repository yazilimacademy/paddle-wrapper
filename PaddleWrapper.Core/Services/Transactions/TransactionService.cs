using System.Collections.Generic;
using System.Threading.Tasks;
using PaddleWrapper.Core.Interfaces;
using PaddleWrapper.Core.Models;
using PaddleWrapper.Core.Models.Transaction;

namespace PaddleWrapper.Core.Services.Transactions
{
    public class TransactionService : ITransactionService
    {
        private readonly PaddleHttpClient _httpClient;
        private const string BaseEndpoint = "transaction";

        public TransactionService(PaddleHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PaddleResponse<Transaction>> GetTransactionAsync(string transactionId)
        {
            return await _httpClient.GetAsync<PaddleResponse<Transaction>>($"{BaseEndpoint}/{transactionId}");
        }

        public async Task<PaddleResponse<Transaction[]>> ListTransactionsAsync()
        {
            return await _httpClient.GetAsync<PaddleResponse<Transaction[]>>(BaseEndpoint);
        }

        public async Task<PaddleResponse<Transaction[]>> GetCustomerTransactionsAsync(string customerId)
        {
            return await _httpClient.GetAsync<PaddleResponse<Transaction[]>>($"{BaseEndpoint}/customer/{customerId}");
        }

        public async Task<PaddleResponse<Transaction[]>> GetSubscriptionTransactionsAsync(string subscriptionId)
        {
            return await _httpClient.GetAsync<PaddleResponse<Transaction[]>>($"{BaseEndpoint}/subscription/{subscriptionId}");
        }

        public async Task<PaddleResponse<Transaction>> RefundTransactionAsync(string transactionId, decimal? amount = null)
        {
            var data = amount.HasValue ? new { amount } : null;
            return await _httpClient.PostAsync<PaddleResponse<Transaction>>($"{BaseEndpoint}/{transactionId}/refund", data);
        }

        public async Task<PaddleResponse<byte[]>> GetTransactionInvoiceAsync(string transactionId)
        {
            return await _httpClient.GetAsync<PaddleResponse<byte[]>>($"{BaseEndpoint}/{transactionId}/invoice");
        }

        public async Task<PaddleResponse<Transaction>> UpdateTransactionNotesAsync(string transactionId, string notes)
        {
            return await _httpClient.PostAsync<PaddleResponse<Transaction>>($"{BaseEndpoint}/{transactionId}/notes", new { notes });
        }

        public async Task<PaddleResponse<Transaction>> UpdateTransactionMetadataAsync(string transactionId, Dictionary<string, string> metadata)
        {
            return await _httpClient.PostAsync<PaddleResponse<Transaction>>($"{BaseEndpoint}/{transactionId}/metadata", new { metadata });
        }
    }
} 