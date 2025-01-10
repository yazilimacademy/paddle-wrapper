using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PaddleWrapper.Core.Interfaces;
using PaddleWrapper.Core.Models;
using PaddleWrapper.Core.Models.Customer;
using System.Threading.Tasks;

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
        /// Gets customer credit balance
        /// </summary>
        [HttpGet("{customerId}/credit-balance")]
        public async Task<ActionResult<PaddleResponse<CustomerCreditBalance>>> GetCreditBalance(string customerId)
        {
            return await _customerService.GetCreditBalanceAsync(customerId);
        }

        /// <summary>
        /// Creates a credit adjustment for customer
        /// </summary>
        [HttpPost("{customerId}/credit-adjustments")]
        public async Task<ActionResult<PaddleResponse<CreditAdjustment>>> CreateCreditAdjustment(string customerId, [FromBody] CreditAdjustmentRequest request)
        {
            return await _customerService.CreateCreditAdjustmentAsync(customerId, request);
        }
    }
} 