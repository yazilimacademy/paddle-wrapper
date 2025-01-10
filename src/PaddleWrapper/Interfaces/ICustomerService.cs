using PaddleWrapper.Models.Common;
using PaddleWrapper.Models.Customers;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PaddleWrapper.Interfaces
{
    /// <summary>
    /// Interface for managing customers in the Paddle system
    /// </summary>
    public interface ICustomerService
    {
        /// <summary>
        /// Gets a list of all customers
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<PaddleResponse<List<Customer>>> ListCustomersAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a customer by their ID
        /// </summary>
        /// <param name="customerId">The ID of the customer</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<PaddleResponse<Customer>> GetCustomerAsync(string customerId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a new customer
        /// </summary>
        /// <param name="customer">The customer to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<PaddleResponse<Customer>> CreateCustomerAsync(Customer customer, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing customer
        /// </summary>
        /// <param name="customerId">The ID of the customer to update</param>
        /// <param name="customer">The updated customer data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<PaddleResponse<Customer>> UpdateCustomerAsync(string customerId, Customer customer, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a list of addresses for a customer
        /// </summary>
        /// <param name="customerId">The ID of the customer</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<PaddleResponse<List<Address>>> ListCustomerAddressesAsync(string customerId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a new address for a customer
        /// </summary>
        /// <param name="customerId">The ID of the customer</param>
        /// <param name="address">The address to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<PaddleResponse<Address>> CreateCustomerAddressAsync(string customerId, Address address, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a list of businesses for a customer
        /// </summary>
        /// <param name="customerId">The ID of the customer</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<PaddleResponse<List<Business>>> ListCustomerBusinessesAsync(string customerId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a new business for a customer
        /// </summary>
        /// <param name="customerId">The ID of the customer</param>
        /// <param name="business">The business to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<PaddleResponse<Business>> CreateCustomerBusinessAsync(string customerId, Business business, CancellationToken cancellationToken = default);
    }
}