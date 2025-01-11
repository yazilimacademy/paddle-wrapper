using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Resources.CustomerPortalSessions.Operations
{
    public class CreateCustomerPortalSession
    {
        [JsonPropertyName("subscription_ids")]
        public List<string>? SubscriptionIds { get; set; }

        public CreateCustomerPortalSession(List<string>? subscriptionIds = null)
        {
            SubscriptionIds = subscriptionIds;
        }
    }
} 