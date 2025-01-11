using System.Collections.Generic;
using System.Text.Json.Serialization;
using PaddleWrapper.Entities.Shared;

namespace PaddleWrapper.Entities.Subscription
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
            var items = new List<SubscriptionAdjustmentItem>();
            var itemsData = (object[])data["items"];
            foreach (var item in itemsData)
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