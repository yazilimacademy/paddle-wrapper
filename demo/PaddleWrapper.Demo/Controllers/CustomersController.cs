using Microsoft.AspNetCore.Mvc;
using PaddleWrapper.Interfaces;

namespace PaddleWrapperDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            PaddleWrapper.Models.Common.PaddleResponse<List<PaddleWrapper.Models.Customers.Customer>> result = await _customerService.ListCustomersAsync();
            return Ok(result);
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomer(string customerId)
        {
            PaddleWrapper.Models.Common.PaddleResponse<PaddleWrapper.Models.Customers.Customer> result = await _customerService.GetCustomerAsync(customerId);
            return Ok(result);
        }
    }
}
