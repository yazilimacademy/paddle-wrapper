using PaddleWrapper.Models;
using PaddleWrapper.Responses;
using System.Text.Json;

#if NETSTANDARD2_0
using PaddleWrapper.Extensions;
#endif

namespace PaddleWrapper.Api
{
    public class CustomersApi
    {
        private readonly HttpClient _httpClient;
        private const string BasePath = "customers";

        internal CustomersApi(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        /// <summary>
        /// Lists all customers
        /// </summary>
        public async Task<List<Customer>> ListAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(BasePath);
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            ApiResponse<List<Customer>>? result = JsonSerializer.Deserialize<ApiResponse<List<Customer>>>(content);

            return result.Data;
        }

        /// <summary>
        /// Gets a customer by ID
        /// </summary>
        public async Task<Customer> GetAsync(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
            {
                throw new ArgumentNullException(nameof(customerId));
            }

            HttpResponseMessage response = await _httpClient.GetAsync($"{BasePath}/{customerId}");
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            ApiResponse<Customer>? result = JsonSerializer.Deserialize<ApiResponse<Customer>>(content);

            return result.Data;
        }

        /// <summary>
        /// Creates a new customer
        /// </summary>
        public async Task<Customer> CreateAsync(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            string json = JsonSerializer.Serialize(customer);
            StringContent content = new(json, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(BasePath, content);
            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();
            ApiResponse<Customer>? result = JsonSerializer.Deserialize<ApiResponse<Customer>>(responseContent);

            return result.Data;
        }

        /// <summary>
        /// Updates an existing customer
        /// </summary>
        public async Task<Customer> UpdateAsync(string customerId, Customer customer)
        {
            if (string.IsNullOrEmpty(customerId))
            {
                throw new ArgumentNullException(nameof(customerId));
            }

            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            string json = JsonSerializer.Serialize(customer);
            StringContent content = new(json, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PatchAsync($"{BasePath}/{customerId}", content);
            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();
            ApiResponse<Customer>? result = JsonSerializer.Deserialize<ApiResponse<Customer>>(responseContent);

            return result.Data;
        }
    }
}