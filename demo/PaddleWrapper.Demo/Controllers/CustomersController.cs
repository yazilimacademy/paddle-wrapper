using Microsoft.AspNetCore.Mvc;
using PaddleWrapper.Core.Interfaces;
using PaddleWrapper.Core.Models;
using PaddleWrapper.Core.Models.Customer;

namespace PaddleWrapper.Demo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger<CustomersController> _logger;

        public CustomersController(ICustomerService customerService, ILogger<CustomersController> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }

        /// <summary>
        /// Lists all customers
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<PaddleResponse<Customer[]>>> ListCustomers()
        {
            return await _customerService.ListCustomersAsync();
        }

        /// <summary>
        /// Gets a specific customer by ID
        /// </summary>
        [HttpGet("{customerId}")]
        public async Task<ActionResult<PaddleResponse<Customer>>> GetCustomer(string customerId)
        {
            return await _customerService.GetCustomerAsync(customerId);
        }

        /// <summary>
        /// Creates a new customer
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<PaddleResponse<Customer>>> CreateCustomer([FromBody] Customer customer)
        {
            return await _customerService.CreateCustomerAsync(customer);
        }

        /// <summary>
        /// Updates an existing customer
        /// </summary>
        [HttpPatch("{customerId}")]
        public async Task<ActionResult<PaddleResponse<Customer>>> UpdateCustomer(string customerId, [FromBody] Customer customer)
        {
            return await _customerService.UpdateCustomerAsync(customerId, customer);
        }

        /// <summary>
        /// Gets customer addresses
        /// </summary>
        [HttpGet("{customerId}/addresses")]
        public async Task<ActionResult<PaddleResponse<Address[]>>> GetCustomerAddresses(string customerId)
        {
            return await _customerService.GetCustomerAddressesAsync(customerId);
        }

        /// <summary>
        /// Adds a new address to customer
        /// </summary>
        [HttpPost("{customerId}/addresses")]
        public async Task<ActionResult<PaddleResponse<Address>>> AddCustomerAddress(string customerId, [FromBody] Address address)
        {
            return await _customerService.AddCustomerAddressAsync(customerId, address);
        }

        /// <summary>
        /// Updates customer address
        /// </summary>
        [HttpPatch("{customerId}/addresses/{addressId}")]
        public async Task<ActionResult<PaddleResponse<Address>>> UpdateCustomerAddress(string customerId, string addressId, [FromBody] Address address)
        {
            return await _customerService.UpdateCustomerAddressAsync(customerId, addressId, address);
        }

        /// <summary>
        /// Deletes customer address
        /// </summary>
        [HttpDelete("{customerId}/addresses/{addressId}")]
        public async Task<ActionResult<PaddleResponse<bool>>> DeleteCustomerAddress(string customerId, string addressId)
        {
            return await _customerService.DeleteCustomerAddressAsync(customerId, addressId);
        }

        /// <summary>
        /// Gets customer business details
        /// </summary>
        [HttpGet("{customerId}/business")]
        public async Task<ActionResult<PaddleResponse<Business>>> GetCustomerBusiness(string customerId)
        {
            return await _customerService.GetCustomerBusinessAsync(customerId);
        }

        /// <summary>
        /// Updates customer business details
        /// </summary>
        [HttpPatch("{customerId}/business")]
        public async Task<ActionResult<PaddleResponse<Business>>> UpdateCustomerBusiness(string customerId, [FromBody] Business business)
        {
            return await _customerService.UpdateCustomerBusinessAsync(customerId, business);
        }
    }
}