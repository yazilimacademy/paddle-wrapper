using PaddleWrapper.Core.Interfaces;
using PaddleWrapper.Core.Models;
using PaddleWrapper.Core.Models.Customer;

namespace PaddleWrapper.Core.Services.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly PaddleHttpClient _httpClient;
        private const string BaseEndpoint = "customer";

        public CustomerService(PaddleHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PaddleResponse<Customer>> GetCustomerAsync(string customerId)
        {
            return await _httpClient.GetAsync<PaddleResponse<Customer>>($"{BaseEndpoint}/{customerId}");
        }

        public async Task<PaddleResponse<Customer>> CreateCustomerAsync(Customer customer)
        {
            return await _httpClient.PostAsync<PaddleResponse<Customer>>(BaseEndpoint, customer);
        }

        public async Task<PaddleResponse<Customer>> UpdateCustomerAsync(string customerId, Customer customer)
        {
            return await _httpClient.PostAsync<PaddleResponse<Customer>>($"{BaseEndpoint}/{customerId}", customer);
        }

        public async Task<PaddleResponse<Customer[]>> ListCustomersAsync()
        {
            return await _httpClient.GetAsync<PaddleResponse<Customer[]>>(BaseEndpoint);
        }

        public async Task<PaddleResponse<Address[]>> GetCustomerAddressesAsync(string customerId)
        {
            return await _httpClient.GetAsync<PaddleResponse<Address[]>>($"{BaseEndpoint}/{customerId}/addresses");
        }

        public async Task<PaddleResponse<Address>> AddCustomerAddressAsync(string customerId, Address address)
        {
            return await _httpClient.PostAsync<PaddleResponse<Address>>($"{BaseEndpoint}/{customerId}/addresses", address);
        }

        public async Task<PaddleResponse<Address>> UpdateCustomerAddressAsync(string customerId, string addressId, Address address)
        {
            return await _httpClient.PostAsync<PaddleResponse<Address>>($"{BaseEndpoint}/{customerId}/addresses/{addressId}", address);
        }

        public async Task<PaddleResponse<bool>> DeleteCustomerAddressAsync(string customerId, string addressId)
        {
            return await _httpClient.PostAsync<PaddleResponse<bool>>($"{BaseEndpoint}/{customerId}/addresses/{addressId}/delete", null);
        }

        public async Task<PaddleResponse<Business>> GetCustomerBusinessAsync(string customerId)
        {
            return await _httpClient.GetAsync<PaddleResponse<Business>>($"{BaseEndpoint}/{customerId}/business");
        }

        public async Task<PaddleResponse<Business>> UpdateCustomerBusinessAsync(string customerId, Business business)
        {
            return await _httpClient.PostAsync<PaddleResponse<Business>>($"{BaseEndpoint}/{customerId}/business", business);
        }
    }
}