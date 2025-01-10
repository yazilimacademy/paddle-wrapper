using PaddleWrapper.Models;
using PaddleWrapper.Responses;
using System.Text.Json;

#if NETSTANDARD2_0
using PaddleWrapper.Extensions;
#endif

namespace PaddleWrapper.Api
{
    public class DiscountsApi
    {
        private readonly HttpClient _httpClient;
        private const string BasePath = "discounts";

        internal DiscountsApi(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        /// <summary>
        /// Lists all discounts
        /// </summary>
        public async Task<List<Discount>> ListAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(BasePath);
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            ApiResponse<List<Discount>>? result = JsonSerializer.Deserialize<ApiResponse<List<Discount>>>(content);

            return result.Data;
        }

        /// <summary>
        /// Gets a discount by ID
        /// </summary>
        public async Task<Discount> GetAsync(string discountId)
        {
            if (string.IsNullOrEmpty(discountId))
            {
                throw new ArgumentNullException(nameof(discountId));
            }

            HttpResponseMessage response = await _httpClient.GetAsync($"{BasePath}/{discountId}");
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            ApiResponse<Discount>? result = JsonSerializer.Deserialize<ApiResponse<Discount>>(content);

            return result.Data;
        }

        /// <summary>
        /// Creates a new discount
        /// </summary>
        public async Task<Discount> CreateAsync(Discount discount)
        {
            if (discount == null)
            {
                throw new ArgumentNullException(nameof(discount));
            }

            string json = JsonSerializer.Serialize(discount);
            StringContent content = new(json, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(BasePath, content);
            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();
            ApiResponse<Discount>? result = JsonSerializer.Deserialize<ApiResponse<Discount>>(responseContent);

            return result.Data;
        }

        /// <summary>
        /// Updates an existing discount
        /// </summary>
        public async Task<Discount> UpdateAsync(string discountId, Discount discount)
        {
            if (string.IsNullOrEmpty(discountId))
            {
                throw new ArgumentNullException(nameof(discountId));
            }

            if (discount == null)
            {
                throw new ArgumentNullException(nameof(discount));
            }

            string json = JsonSerializer.Serialize(discount);
            StringContent content = new(json, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PatchAsync($"{BasePath}/{discountId}", content);
            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();
            ApiResponse<Discount>? result = JsonSerializer.Deserialize<ApiResponse<Discount>>(responseContent);

            return result.Data;
        }
    }
}