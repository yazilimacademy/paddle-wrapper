using System.Text.Json;

namespace PaddleWrapper.Entities.Subscriptions
{
    public class SubscriptionPreviewDetails
    {
        public TaxRatesUsed[] TaxRatesUsed { get; }
        public SubscriptionPreviewTotals Totals { get; }

        public SubscriptionPreviewDetails(TaxRatesUsed[] taxRatesUsed, SubscriptionPreviewTotals totals)
        {
            TaxRatesUsed = taxRatesUsed;
            Totals = totals;
        }

        public static SubscriptionPreviewDetails FromDict(JsonElement data)
        {
            var taxRatesUsed = data.GetProperty("tax_rates_used").EnumerateArray()
                .Select(TaxRatesUsed.FromDict)
                .ToArray();

            return new SubscriptionPreviewDetails(
                taxRatesUsed: taxRatesUsed,
                totals: SubscriptionPreviewTotals.FromDict(data.GetProperty("totals"))
            );
        }
    }
} 