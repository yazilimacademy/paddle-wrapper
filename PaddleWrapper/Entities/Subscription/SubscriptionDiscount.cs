using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Subscription
{
    public class SubscriptionDiscount
    {
        [JsonPropertyName("id")]
        public string Id { get; }

        [JsonPropertyName("starts_at")]
        public DateTime? StartsAt { get; }

        [JsonPropertyName("ends_at")]
        public DateTime? EndsAt { get; }

        private SubscriptionDiscount(
            string id,
            DateTime? startsAt,
            DateTime? endsAt)
        {
            Id = id;
            StartsAt = startsAt;
            EndsAt = endsAt;
        }

        public static SubscriptionDiscount From(Dictionary<string, object> data)
        {
            return new SubscriptionDiscount(
                id: (string)data["id"],
                startsAt: data.ContainsKey("starts_at") ? DateTime.Parse((string)data["starts_at"]) : null,
                endsAt: data.ContainsKey("ends_at") ? DateTime.Parse((string)data["ends_at"]) : null
            );
        }
    }
}