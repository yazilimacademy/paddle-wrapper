using System.Text.Json;

namespace PaddleWrapper.Entities.Subscriptions
{
    public class SubscriptionPreviewItemTotals
    {
        public string Subtotal { get; }
        public string Tax { get; }
        public string Total { get; }
        public string Discount { get; }

        public SubscriptionPreviewItemTotals(
            string subtotal,
            string tax,
            string total,
            string discount)
        {
            Subtotal = subtotal;
            Tax = tax;
            Total = total;
            Discount = discount;
        }

        public static SubscriptionPreviewItemTotals FromDict(JsonElement data)
        {
            return new SubscriptionPreviewItemTotals(
                subtotal: data.GetProperty("subtotal").GetString(),
                tax: data.GetProperty("tax").GetString(),
                total: data.GetProperty("total").GetString(),
                discount: data.GetProperty("discount").GetString()
            );
        }
    }
} 