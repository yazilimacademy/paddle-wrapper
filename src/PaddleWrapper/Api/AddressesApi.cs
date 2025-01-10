using PaddleWrapper.Models;
using PaddleWrapper.Responses;
using System.Text.Json;


#if NETSTANDARD2_0
using PaddleWrapper.Extensions;
#endif

namespace PaddleWrapper.Api
{
    public class AddressesApi
    {
        private readonly HttpClient _httpClient;
        private const string BasePath = "addresses";

        internal AddressesApi(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        /// <summary>
        /// Lists all addresses
        /// </summary>
        public async Task<List<Address>> ListAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(BasePath);
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            ApiResponse<List<Address>>? result = JsonSerializer.Deserialize<ApiResponse<List<Address>>>(content);

            return result.Data;
        }

        /// <summary>
        /// Gets an address by ID
        /// </summary>
        public async Task<Address> GetAsync(string addressId)
        {
            if (string.IsNullOrEmpty(addressId))
            {
                throw new ArgumentNullException(nameof(addressId));
            }

            HttpResponseMessage response = await _httpClient.GetAsync($"{BasePath}/{addressId}");
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            ApiResponse<Address>? result = JsonSerializer.Deserialize<ApiResponse<Address>>(content);

            return result.Data;
        }

        /// <summary>
        /// Creates a new address
        /// </summary>
        public async Task<Address> CreateAsync(Address address)
        {
            if (address == null)
            {
                throw new ArgumentNullException(nameof(address));
            }

            string json = JsonSerializer.Serialize(address);
            StringContent content = new(json, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(BasePath, content);
            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();
            ApiResponse<Address>? result = JsonSerializer.Deserialize<ApiResponse<Address>>(responseContent);

            return result.Data;
        }

        /// <summary>
        /// Updates an existing address
        /// </summary>
        public async Task<Address> UpdateAsync(string addressId, Address address)
        {
            if (string.IsNullOrEmpty(addressId))
            {
                throw new ArgumentNullException(nameof(addressId));
            }

            if (address == null)
            {
                throw new ArgumentNullException(nameof(address));
            }

            string json = JsonSerializer.Serialize(address);
            StringContent content = new(json, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PatchAsync($"{BasePath}/{addressId}", content);
            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();
            ApiResponse<Address>? result = JsonSerializer.Deserialize<ApiResponse<Address>>(responseContent);

            return result.Data;
        }
    }
}