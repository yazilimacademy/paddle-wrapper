using System.Text.Json;
using System.Threading.Tasks;

namespace PaddleWrapper.Clients
{
    public class SubscriptionClient
    {
        private readonly PaddleClient _paddleClient;

        public SubscriptionClient(PaddleClient paddleClient)
        {
            _paddleClient = paddleClient;
        }

        public async Task<JsonElement> GetSubscriptionAsync(string subscriptionId)
        {
            var payload = new { subscription_id = subscriptionId };
            return await _paddleClient.SendRequestAsync("subscription/get", payload);
        }
    }
} 