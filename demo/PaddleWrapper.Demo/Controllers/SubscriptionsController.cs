using Microsoft.AspNetCore.Mvc;
using PaddleWrapper.Interfaces;

namespace PaddleWrapperDemo.Controllers
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
            PaddleWrapper.Models.Common.PaddleResponse<List<PaddleWrapper.Models.Subscriptions.Subscription>> result = await _subscriptionService.ListSubscriptionsAsync();
            return Ok(result);
        }

        [HttpGet("{subscriptionId}")]
        public async Task<IActionResult> GetSubscription(string subscriptionId)
        {
            PaddleWrapper.Models.Common.PaddleResponse<PaddleWrapper.Models.Subscriptions.Subscription> result = await _subscriptionService.GetSubscriptionAsync(subscriptionId);
            return Ok(result);
        }
    }
}
