using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Transactions
{
    public class TransactionTimePeriod
    {
        [JsonPropertyName("starts_at")]
        public DateTime StartsAt { get; }

        [JsonPropertyName("ends_at")]
        public DateTime EndsAt { get; }

        private TransactionTimePeriod(
            DateTime startsAt,
            DateTime endsAt)
        {
            StartsAt = startsAt;
            EndsAt = endsAt;
        }

        public static TransactionTimePeriod From(Dictionary<string, object> data)
        {
            return new TransactionTimePeriod(
                startsAt: DateTime.Parse((string)data["starts_at"]),
                endsAt: DateTime.Parse((string)data["ends_at"])
            );
        }
    }
}