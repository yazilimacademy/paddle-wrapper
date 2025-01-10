using PaddleWrapper.Models;
using PaddleWrapper.Responses;
using System.Text.Json;

#if NETSTANDARD2_0
using PaddleWrapper.Extensions;
#endif

namespace PaddleWrapper.Api
{
    public class TransactionsApi
    {
        private readonly HttpClient _httpClient;
        private const string BasePath = "transactions";

        internal TransactionsApi(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        /// <summary>
        /// Lists all transactions
        /// </summary>
        public async Task<List<Transaction>> ListAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(BasePath);
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            ApiResponse<List<Transaction>>? result = JsonSerializer.Deserialize<ApiResponse<List<Transaction>>>(content);

            return result.Data;
        }

        /// <summary>
        /// Gets a transaction by ID
        /// </summary>
        public async Task<Transaction> GetAsync(string transactionId)
        {
            if (string.IsNullOrEmpty(transactionId))
            {
                throw new ArgumentNullException(nameof(transactionId));
            }

            HttpResponseMessage response = await _httpClient.GetAsync($"{BasePath}/{transactionId}");
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            ApiResponse<Transaction>? result = JsonSerializer.Deserialize<ApiResponse<Transaction>>(content);

            return result.Data;
        }

        /// <summary>
        /// Creates a new transaction
        /// </summary>
        public async Task<Transaction> CreateAsync(Transaction transaction)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException(nameof(transaction));
            }

            string json = JsonSerializer.Serialize(transaction);
            StringContent content = new(json, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(BasePath, content);
            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();
            ApiResponse<Transaction>? result = JsonSerializer.Deserialize<ApiResponse<Transaction>>(responseContent);

            return result.Data;
        }

        /// <summary>
        /// Updates an existing transaction
        /// </summary>
        public async Task<Transaction> UpdateAsync(string transactionId, Transaction transaction)
        {
            if (string.IsNullOrEmpty(transactionId))
            {
                throw new ArgumentNullException(nameof(transactionId));
            }

            if (transaction == null)
            {
                throw new ArgumentNullException(nameof(transaction));
            }

            string json = JsonSerializer.Serialize(transaction);
            StringContent content = new(json, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PatchAsync($"{BasePath}/{transactionId}", content);
            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();
            ApiResponse<Transaction>? result = JsonSerializer.Deserialize<ApiResponse<Transaction>>(responseContent);

            return result.Data;
        }

        /// <summary>
        /// Previews a transaction
        /// </summary>
        public async Task<Transaction> PreviewAsync(Transaction transaction)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException(nameof(transaction));
            }

            string json = JsonSerializer.Serialize(transaction);
            StringContent content = new(json, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync($"{BasePath}/preview", content);
            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();
            ApiResponse<Transaction>? result = JsonSerializer.Deserialize<ApiResponse<Transaction>>(responseContent);

            return result.Data;
        }
    }
}