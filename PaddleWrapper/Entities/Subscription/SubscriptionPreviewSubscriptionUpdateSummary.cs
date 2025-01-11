using System.Text.Json.Serialization;
using PaddleWrapper.Entities.Shared;

namespace PaddleWrapper.Entities.Subscription
{
    public class SubscriptionPreviewSubscriptionUpdateSummary
    {
        [JsonPropertyName("credit")]
        public SubscriptionCredit Credit { get; }

        [JsonPropertyName("charge")]
        public SubscriptionCharge Charge { get; }

        [JsonPropertyName("result")]
        public SubscriptionResult Result { get; }

        private SubscriptionPreviewSubscriptionUpdateSummary(
            SubscriptionCredit credit,
            SubscriptionCharge charge,
            SubscriptionResult result)
        {
            Credit = credit;
            Charge = charge;
            Result = result;
        }

        public static SubscriptionPreviewSubscriptionUpdateSummary From(Dictionary<string, object> data)
        {
            return new SubscriptionPreviewSubscriptionUpdateSummary(
                credit: SubscriptionCredit.From((Dictionary<string, object>)data["credit"]),
                charge: SubscriptionCharge.From((Dictionary<string, object>)data["charge"]),
                result: SubscriptionResult.From((Dictionary<string, object>)data["result"])
            );
        }
    }
} 