using System;
using System.Text.Json.Serialization;
using PaddleWrapper.Entities.Shared;

namespace PaddleWrapper.Entities.Subscription
{
    public class SubscriptionTimePeriod
    {
        [JsonPropertyName("starts_at")]
        public DateTime StartsAt { get; }

        [JsonPropertyName("ends_at")]
        public DateTime EndsAt { get; }

        private SubscriptionTimePeriod(
            DateTime startsAt,
            DateTime endsAt)
        {
            StartsAt = startsAt;
            EndsAt = endsAt;
        }

        public static SubscriptionTimePeriod From(Dictionary<string, object> data)
        {
            return new SubscriptionTimePeriod(
                startsAt: DateTime.Parse((string)data["starts_at"]),
                endsAt: DateTime.Parse((string)data["ends_at"])
            );
        }
    }
} 