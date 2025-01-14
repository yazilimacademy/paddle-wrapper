using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Transactions
{
    public class TransactionProration
    {
        [JsonPropertyName("rate")]
        public string Rate { get; }

        [JsonPropertyName("billing_period")]
        public TransactionTimePeriod? BillingPeriod { get; }

        private TransactionProration(
            string rate,
            TransactionTimePeriod? billingPeriod)
        {
            Rate = rate;
            BillingPeriod = billingPeriod;
        }

        public static TransactionProration From(Dictionary<string, object> data)
        {
            return new TransactionProration(
                rate: (string)data["rate"],
                billingPeriod: data.ContainsKey("billing_period") ? TransactionTimePeriod.From((Dictionary<string, object>)data["billing_period"]) : null
            );
        }
    }
}