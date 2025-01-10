using PaddleWrapper.Models;
using PaddleWrapper.Responses;
using System.Text.Json;

#if NETSTANDARD2_0
using PaddleWrapper.Extensions;
#endif

namespace PaddleWrapper.Api
{
    public class ApiResponse
    {
        private readonly HttpClient _httpClient;
        private const string BasePath = "products";

        internal ApiResponse(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        /// <summary>
        /// Lists all products
        /// </summary>
        public async Task<List<Product>> ListAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(BasePath);
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            ApiResponse<List<Product>>? result = JsonSerializer.Deserialize<ApiResponse<List<Product>>>(content);

            return result.Data;
        }

        /// <summary>
        /// Gets a product by ID
        /// </summary>
        public async Task<Product> GetAsync(string productId)
        {
            if (string.IsNullOrEmpty(productId))
            {
                throw new ArgumentNullException(nameof(productId));
            }

            HttpResponseMessage response = await _httpClient.GetAsync($"{BasePath}/{productId}");
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            ApiResponse<Product>? result = JsonSerializer.Deserialize<ApiResponse<Product>>(content);

            return result.Data;
        }

        /// <summary>
        /// Creates a new product
        /// </summary>
        public async Task<Product> CreateAsync(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            string json = JsonSerializer.Serialize(product);
            StringContent content = new(json, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(BasePath, content);
            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();
            ApiResponse<Product>? result = JsonSerializer.Deserialize<ApiResponse<Product>>(responseContent);

            return result.Data;
        }

        /// <summary>
        /// Updates an existing product
        /// </summary>
        public async Task<Product> UpdateAsync(string productId, Product product)
        {
            if (string.IsNullOrEmpty(productId))
            {
                throw new ArgumentNullException(nameof(productId));
            }

            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            string json = JsonSerializer.Serialize(product);
            StringContent content = new(json, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PatchAsync($"{BasePath}/{productId}", content);
            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();
            ApiResponse<Product>? result = JsonSerializer.Deserialize<ApiResponse<Product>>(responseContent);

            return result.Data;
        }
    }
}