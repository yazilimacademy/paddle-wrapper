using PaddleWrapper.Entities.Shared;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Subscriptions
{
    public class SubscriptionPrice
    {
        [JsonPropertyName("id")]
        public string Id { get; }

        [JsonPropertyName("description")]
        public string Description { get; }

        [JsonPropertyName("product_id")]
        public string ProductId { get; }

        [JsonPropertyName("billing_cycle")]
        public TimePeriod? BillingCycle { get; }

        [JsonPropertyName("trial_period")]
        public TimePeriod? TrialPeriod { get; }

        [JsonPropertyName("tax_mode")]
        public TaxMode TaxMode { get; }

        [JsonPropertyName("unit_price")]
        public Money UnitPrice { get; }

        private SubscriptionPrice(
            string id,
            string description,
            string productId,
            TimePeriod? billingCycle,
            TimePeriod? trialPeriod,
            TaxMode taxMode,
            Money unitPrice)
        {
            Id = id;
            Description = description;
            ProductId = productId;
            BillingCycle = billingCycle;
            TrialPeriod = trialPeriod;
            TaxMode = taxMode;
            UnitPrice = unitPrice;
        }

        public static SubscriptionPrice From(Dictionary<string, object> data)
        {
            return new SubscriptionPrice(
                id: (string)data["id"],
                description: (string)data["description"],
                productId: (string)data["product_id"],
                billingCycle: data.ContainsKey("billing_cycle") ? TimePeriod.From((Dictionary<string, object>)data["billing_cycle"]) : null,
                trialPeriod: data.ContainsKey("trial_period") ? TimePeriod.From((Dictionary<string, object>)data["trial_period"]) : null,
                taxMode: Enum.Parse<TaxMode>((string)data["tax_mode"], true),
                unitPrice: Money.From((Dictionary<string, object>)data["unit_price"])
            );
        }
    }
}