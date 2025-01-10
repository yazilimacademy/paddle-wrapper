using System.Text.Json;

namespace PaddleWrapper.Entities.Subscriptions
{
    public class SubscriptionPreviewTaxRatesUsed
    {
        public string TaxRate { get; }
        public SubscriptionPreviewTotals Totals { get; }

        public SubscriptionPreviewTaxRatesUsed(string taxRate, SubscriptionPreviewTotals totals)
        {
            TaxRate = taxRate;
            Totals = totals;
        }

        public static SubscriptionPreviewTaxRatesUsed FromDict(JsonElement data)
        {
            return new SubscriptionPreviewTaxRatesUsed(
                taxRate: data.GetProperty("tax_rate").GetString(),
                totals: SubscriptionPreviewTotals.FromDict(data.GetProperty("totals"))
            );
        }
    }
} 