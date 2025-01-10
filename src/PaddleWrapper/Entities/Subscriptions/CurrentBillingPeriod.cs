using System.Text.Json;

namespace PaddleWrapper.Entities.Subscriptions
{
    public class CurrentBillingPeriod
    {
        public DateTime StartsAt { get; }
        public DateTime EndsAt { get; }

        public CurrentBillingPeriod(DateTime startsAt, DateTime endsAt)
        {
            StartsAt = startsAt;
            EndsAt = endsAt;
        }

        public static CurrentBillingPeriod FromDict(JsonElement data)
        {
            return new CurrentBillingPeriod(
                DateTime.Parse(data.GetProperty("starts_at").GetString()),
                DateTime.Parse(data.GetProperty("ends_at").GetString())
            );
        }
    }
} 