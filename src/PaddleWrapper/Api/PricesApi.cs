using PaddleWrapper.Models;
using PaddleWrapper.Responses;
using System.Text.Json;

#if NETSTANDARD2_0
using PaddleWrapper.Extensions;
#endif

namespace PaddleWrapper.Api
{
    public class PricesApi
    {
        private readonly HttpClient _httpClient;
        private const string BasePath = "prices";

        internal PricesApi(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        /// <summary>
        /// Lists all prices
        /// </summary>
        public async Task<List<Price>> ListAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(BasePath);
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            ApiResponse<List<Price>>? result = JsonSerializer.Deserialize<ApiResponse<List<Price>>>(content);

            return result.Data;
        }

        /// <summary>
        /// Gets a price by ID
        /// </summary>
        public async Task<Price> GetAsync(string priceId)
        {
            if (string.IsNullOrEmpty(priceId))
            {
                throw new ArgumentNullException(nameof(priceId));
            }

            HttpResponseMessage response = await _httpClient.GetAsync($"{BasePath}/{priceId}");
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            ApiResponse<Price>? result = JsonSerializer.Deserialize<ApiResponse<Price>>(content);

            return result.Data;
        }

        /// <summary>
        /// Creates a new price
        /// </summary>
        public async Task<Price> CreateAsync(Price price)
        {
            if (price == null)
            {
                throw new ArgumentNullException(nameof(price));
            }

            string json = JsonSerializer.Serialize(price);
            StringContent content = new(json, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(BasePath, content);
            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();
            ApiResponse<Price>? result = JsonSerializer.Deserialize<ApiResponse<Price>>(responseContent);

            return result.Data;
        }

        /// <summary>
        /// Updates an existing price
        /// </summary>
        public async Task<Price> UpdateAsync(string priceId, Price price)
        {
            if (string.IsNullOrEmpty(priceId))
            {
                throw new ArgumentNullException(nameof(priceId));
            }

            if (price == null)
            {
                throw new ArgumentNullException(nameof(price));
            }

            string json = JsonSerializer.Serialize(price);
            StringContent content = new(json, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PatchAsync($"{BasePath}/{priceId}", content);
            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();
            ApiResponse<Price>? result = JsonSerializer.Deserialize<ApiResponse<Price>>(responseContent);

            return result.Data;
        }
    }
}