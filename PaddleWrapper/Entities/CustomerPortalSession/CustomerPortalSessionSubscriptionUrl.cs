using System.Text.Json.Serialization;
using PaddleWrapper.Entities.Shared;

namespace PaddleWrapper.Entities.CustomerPortalSession
{
    public class CustomerPortalSessionSubscriptionUrl
    {
        [JsonPropertyName("id")]
        public string Id { get; }

        [JsonPropertyName("cancel_subscription")]
        public string CancelSubscription { get; }

        [JsonPropertyName("update_subscription_payment_method")]
        public string UpdateSubscriptionPaymentMethod { get; }

        private CustomerPortalSessionSubscriptionUrl(
            string id,
            string cancelSubscription,
            string updateSubscriptionPaymentMethod)
        {
            Id = id;
            CancelSubscription = cancelSubscription;
            UpdateSubscriptionPaymentMethod = updateSubscriptionPaymentMethod;
        }

        public static CustomerPortalSessionSubscriptionUrl From(Dictionary<string, object> data)
        {
            return new CustomerPortalSessionSubscriptionUrl(
                id: (string)data["id"],
                cancelSubscription: (string)data["cancel_subscription"],
                updateSubscriptionPaymentMethod: (string)data["update_subscription_payment_method"]
            );
        }
    }
} 