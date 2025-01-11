using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Shared
{
    public class AdjustmentProration
    {
        [JsonPropertyName("rate")]
        public string Rate { get; }

        [JsonPropertyName("billing_period")]
        public AdjustmentTimePeriod BillingPeriod { get; }

        [JsonConstructor]
        public AdjustmentProration(string rate, AdjustmentTimePeriod billingPeriod)
        {
            Rate = rate;
            BillingPeriod = billingPeriod;
        }

        public static AdjustmentProration From(Dictionary<string, object> data)
        {
            return new AdjustmentProration(
                rate: data["rate"].ToString(),
                billingPeriod: AdjustmentTimePeriod.From((Dictionary<string, object>)data["billing_period"])
            );
        }
    }
}