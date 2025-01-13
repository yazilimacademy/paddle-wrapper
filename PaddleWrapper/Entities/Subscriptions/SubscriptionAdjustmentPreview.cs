using PaddleWrapper.Entities.Shared;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Subscriptions
{
    public class SubscriptionAdjustmentPreview
    {
        [JsonPropertyName("transaction_id")]
        public string TransactionId { get; }

        [JsonPropertyName("items")]
        public IReadOnlyList<SubscriptionAdjustmentItem> Items { get; }

        [JsonPropertyName("totals")]
        public AdjustmentTotals Totals { get; }

        private SubscriptionAdjustmentPreview(
            string transactionId,
            IReadOnlyList<SubscriptionAdjustmentItem> items,
            AdjustmentTotals totals)
        {
            TransactionId = transactionId;
            Items = items;
            Totals = totals;
        }

        public static SubscriptionAdjustmentPreview From(Dictionary<string, object> data)
        {
            List<SubscriptionAdjustmentItem> items = new();
            object[] itemsData = (object[])data["items"];
            foreach (object item in itemsData)
            {
                items.Add(SubscriptionAdjustmentItem.From((Dictionary<string, object>)item));
            }

            return new SubscriptionAdjustmentPreview(
                transactionId: (string)data["transaction_id"],
                items: items,
                totals: AdjustmentTotals.From((Dictionary<string, object>)data["totals"])
            );
        }
    }
}