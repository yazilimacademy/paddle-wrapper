using System.Text.Json.Serialization;

namespace PaddleWrapper.Models
{
    public class Webhook
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("active")]
        public bool Active { get; set; }

        [JsonPropertyName("endpoint_url")]
        public string EndpointUrl { get; set; }

        [JsonPropertyName("api_version")]
        public string ApiVersion { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("subscribed_events")]
        public string[] SubscribedEvents { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }

    public class WebhookEvent
    {
        [JsonPropertyName("event_id")]
        public string EventId { get; set; }

        [JsonPropertyName("event_type")]
        public string EventType { get; set; }

        [JsonPropertyName("occurred_at")]
        public DateTime OccurredAt { get; set; }

        [JsonPropertyName("notification_id")]
        public string NotificationId { get; set; }

        [JsonPropertyName("data")]
        public object Data { get; set; }
    }
}