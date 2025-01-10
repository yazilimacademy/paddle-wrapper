using Microsoft.Extensions.Logging;
using PaddleWrapper.Interfaces;
using PaddleWrapper.Models.Common;
using PaddleWrapper.Models.Customers;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PaddleWrapper.Services
{
    /// <summary>
    /// Service for managing customers in the Paddle system
    /// </summary>
    public class CustomerService : ICustomerService
    {
        private readonly IPaddleClient _client;
        private readonly ILogger<CustomerService> _logger;
        private const string BasePath = "/customers";

        /// <summary>
        /// Creates a new instance of CustomerService
        /// </summary>
        public CustomerService(IPaddleClient client, ILogger<CustomerService> logger)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <inheritdoc/>
        public async Task<PaddleResponse<List<Customer>>> ListCustomersAsync(CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Retrieving list of customers");
            return await _client.GetAsync<PaddleResponse<List<Customer>>>(BasePath, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<PaddleResponse<Customer>> GetCustomerAsync(string customerId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(customerId))
            {
                throw new ArgumentException("Customer ID must be provided", nameof(customerId));
            }

            _logger.LogInformation("Retrieving customer with ID: {CustomerId}", customerId);
            return await _client.GetAsync<PaddleResponse<Customer>>($"{BasePath}/{customerId}", cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<PaddleResponse<Customer>> CreateCustomerAsync(Customer customer, CancellationToken cancellationToken = default)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            _logger.LogInformation("Creating new customer");
            return await _client.PostAsync<Customer, PaddleResponse<Customer>>(BasePath, customer, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<PaddleResponse<Customer>> UpdateCustomerAsync(string customerId, Customer customer, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(customerId))
            {
                throw new ArgumentException("Customer ID must be provided", nameof(customerId));
            }

            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            _logger.LogInformation("Updating customer with ID: {CustomerId}", customerId);
            return await _client.PatchAsync<Customer, PaddleResponse<Customer>>($"{BasePath}/{customerId}", customer, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<PaddleResponse<List<Address>>> ListCustomerAddressesAsync(string customerId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(customerId))
            {
                throw new ArgumentException("Customer ID must be provided", nameof(customerId));
            }

            _logger.LogInformation("Retrieving addresses for customer with ID: {CustomerId}", customerId);
            return await _client.GetAsync<PaddleResponse<List<Address>>>($"{BasePath}/{customerId}/addresses", cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<PaddleResponse<Address>> CreateCustomerAddressAsync(string customerId, Address address, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(customerId))
            {
                throw new ArgumentException("Customer ID must be provided", nameof(customerId));
            }

            if (address == null)
            {
                throw new ArgumentNullException(nameof(address));
            }

            _logger.LogInformation("Creating new address for customer with ID: {CustomerId}", customerId);
            return await _client.PostAsync<Address, PaddleResponse<Address>>($"{BasePath}/{customerId}/addresses", address, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<PaddleResponse<List<Business>>> ListCustomerBusinessesAsync(string customerId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(customerId))
            {
                throw new ArgumentException("Customer ID must be provided", nameof(customerId));
            }

            _logger.LogInformation("Retrieving businesses for customer with ID: {CustomerId}", customerId);
            return await _client.GetAsync<PaddleResponse<List<Business>>>($"{BasePath}/{customerId}/businesses", cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<PaddleResponse<Business>> CreateCustomerBusinessAsync(string customerId, Business business, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(customerId))
            {
                throw new ArgumentException("Customer ID must be provided", nameof(customerId));
            }

            if (business == null)
            {
                throw new ArgumentNullException(nameof(business));
            }

            _logger.LogInformation("Creating new business for customer with ID: {CustomerId}", customerId);
            return await _client.PostAsync<Business, PaddleResponse<Business>>($"{BasePath}/{customerId}/businesses", business, cancellationToken);
        }
    }
}