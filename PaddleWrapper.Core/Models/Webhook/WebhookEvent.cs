using Newtonsoft.Json;

namespace PaddleWrapper.Core.Models.Webhook
{
    public class WebhookEvent
    {
        [JsonProperty("event_type")]
        public string EventType { get; set; }

        [JsonProperty("event_id")]
        public string EventId { get; set; }

        [JsonProperty("occurred_at")]
        public DateTime OccurredAt { get; set; }

        [JsonProperty("data")]
        public dynamic Data { get; set; }

        [JsonProperty("alert_id")]
        public string AlertId { get; set; }

        [JsonProperty("alert_name")]
        public string AlertName { get; set; }

        [JsonProperty("signature")]
        public string Signature { get; set; }
    }

    public static class WebhookEventTypes
    {
        public const string SubscriptionCreated = "subscription_created";
        public const string SubscriptionUpdated = "subscription_updated";
        public const string SubscriptionCancelled = "subscription_cancelled";
        public const string PaymentSucceeded = "payment_succeeded";
        public const string PaymentRefunded = "payment_refunded";
        public const string PaymentFailed = "payment_failed";
    }
}