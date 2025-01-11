using System;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Shared
{
    public class AdjustmentTimePeriod
    {
        [JsonPropertyName("starts_at")]
        public DateTime StartsAt { get; }

        [JsonPropertyName("ends_at")]
        public DateTime EndsAt { get; }

        [JsonConstructor]
        public AdjustmentTimePeriod(DateTime startsAt, DateTime endsAt)
        {
            StartsAt = startsAt;
            EndsAt = endsAt;
        }

        public static AdjustmentTimePeriod From(Dictionary<string, object> data)
        {
            return new AdjustmentTimePeriod(
                startsAt: DateTime.Parse(data["starts_at"].ToString()),
                endsAt: DateTime.Parse(data["ends_at"].ToString())
            );
        }
    }
} 