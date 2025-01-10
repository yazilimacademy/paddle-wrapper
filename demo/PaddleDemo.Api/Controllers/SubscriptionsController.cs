using Microsoft.AspNetCore.Mvc;
using PaddleWrapper.Interfaces;
using PaddleWrapper.Services;
using System.Threading.Tasks;

namespace PaddleDemo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriptionsController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;

        public SubscriptionsController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSubscriptions()
        {
            var result = await _subscriptionService.ListSubscriptionsAsync();
            return Ok(result);
        }

        [HttpGet("{subscriptionId}")]
        public async Task<IActionResult> GetSubscription(string subscriptionId)
        {
            var result = await _subscriptionService.GetSubscriptionAsync(subscriptionId);
            return Ok(result);
        }
    }
}
