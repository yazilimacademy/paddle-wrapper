using PaddleWrapper.Entities.Shared;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Subscriptions
{
    public class SubscriptionNextTransaction
    {
        [JsonPropertyName("billing_period")]
        public SubscriptionTimePeriod BillingPeriod { get; }

        [JsonPropertyName("details")]
        public TransactionDetailsPreview Details { get; }

        [JsonPropertyName("adjustments")]
        public IReadOnlyList<SubscriptionAdjustmentPreview> Adjustments { get; }

        private SubscriptionNextTransaction(
            SubscriptionTimePeriod billingPeriod,
            TransactionDetailsPreview details,
            IReadOnlyList<SubscriptionAdjustmentPreview> adjustments)
        {
            BillingPeriod = billingPeriod;
            Details = details;
            Adjustments = adjustments;
        }

        public static SubscriptionNextTransaction From(Dictionary<string, object> data)
        {
            List<SubscriptionAdjustmentPreview> adjustments = new();
            object[] adjustmentsData = (object[])data["adjustments"];
            foreach (object item in adjustmentsData)
            {
                adjustments.Add(SubscriptionAdjustmentPreview.From((Dictionary<string, object>)item));
            }

            return new SubscriptionNextTransaction(
                billingPeriod: SubscriptionTimePeriod.From((Dictionary<string, object>)data["billing_period"]),
                details: TransactionDetailsPreview.From((Dictionary<string, object>)data["details"]),
                adjustments: adjustments
            );
        }
    }
}