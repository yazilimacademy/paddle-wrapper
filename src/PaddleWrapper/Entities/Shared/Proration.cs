using System.Text.Json;

namespace PaddleWrapper.Entities.Shared
{
    public class Proration
    {
        public decimal Rate { get; }
        public DateTime BillingPeriodStart { get; }
        public DateTime BillingPeriodEnd { get; }

        public Proration(
            decimal rate,
            DateTime billingPeriodStart,
            DateTime billingPeriodEnd)
        {
            Rate = rate;
            BillingPeriodStart = billingPeriodStart;
            BillingPeriodEnd = billingPeriodEnd;
        }

        public static Proration FromDict(JsonElement data)
        {
            return new Proration(
                rate: decimal.Parse(data.GetProperty("rate").GetString()),
                billingPeriodStart: DateTime.Parse(data.GetProperty("billing_period_start").GetString()),
                billingPeriodEnd: DateTime.Parse(data.GetProperty("billing_period_end").GetString())
            );
        }
    }
} 