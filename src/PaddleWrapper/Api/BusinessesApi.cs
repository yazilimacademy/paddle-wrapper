using PaddleWrapper.Models;
using PaddleWrapper.Responses;
using System.Text.Json;

#if NETSTANDARD2_0
using PaddleWrapper.Extensions;
#endif

namespace PaddleWrapper.Api
{
    public class BusinessesApi
    {
        private readonly HttpClient _httpClient;
        private const string BasePath = "businesses";

        internal BusinessesApi(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        /// <summary>
        /// Lists all businesses
        /// </summary>
        public async Task<List<Business>> ListAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(BasePath);
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            ApiResponse<List<Business>>? result = JsonSerializer.Deserialize<ApiResponse<List<Business>>>(content);

            return result.Data;
        }

        /// <summary>
        /// Gets a business by ID
        /// </summary>
        public async Task<Business> GetAsync(string businessId)
        {
            if (string.IsNullOrEmpty(businessId))
            {
                throw new ArgumentNullException(nameof(businessId));
            }

            HttpResponseMessage response = await _httpClient.GetAsync($"{BasePath}/{businessId}");
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            ApiResponse<Business>? result = JsonSerializer.Deserialize<ApiResponse<Business>>(content);

            return result.Data;
        }

        /// <summary>
        /// Creates a new business
        /// </summary>
        public async Task<Business> CreateAsync(Business business)
        {
            if (business == null)
            {
                throw new ArgumentNullException(nameof(business));
            }

            string json = JsonSerializer.Serialize(business);
            StringContent content = new(json, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(BasePath, content);
            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();
            ApiResponse<Business>? result = JsonSerializer.Deserialize<ApiResponse<Business>>(responseContent);

            return result.Data;
        }

        /// <summary>
        /// Updates an existing business
        /// </summary>
        public async Task<Business> UpdateAsync(string businessId, Business business)
        {
            if (string.IsNullOrEmpty(businessId))
            {
                throw new ArgumentNullException(nameof(businessId));
            }

            if (business == null)
            {
                throw new ArgumentNullException(nameof(business));
            }

            string json = JsonSerializer.Serialize(business);
            StringContent content = new(json, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PatchAsync($"{BasePath}/{businessId}", content);
            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();
            ApiResponse<Business>? result = JsonSerializer.Deserialize<ApiResponse<Business>>(responseContent);

            return result.Data;
        }
    }
}