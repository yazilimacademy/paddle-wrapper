using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Subscriptions
{
    public class SubscriptionProration
    {
        [JsonPropertyName("rate")]
        public string Rate { get; }

        [JsonPropertyName("billing_period")]
        public SubscriptionTimePeriod BillingPeriod { get; }

        private SubscriptionProration(
            string rate,
            SubscriptionTimePeriod billingPeriod)
        {
            Rate = rate;
            BillingPeriod = billingPeriod;
        }

        public static SubscriptionProration From(Dictionary<string, object> data)
        {
            return new SubscriptionProration(
                rate: (string)data["rate"],
                billingPeriod: SubscriptionTimePeriod.From((Dictionary<string, object>)data["billing_period"])
            );
        }
    }
}