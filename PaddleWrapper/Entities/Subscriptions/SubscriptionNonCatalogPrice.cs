using PaddleWrapper.Entities.Shared;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Subscriptions
{
    public class SubscriptionNonCatalogPrice
    {
        [JsonPropertyName("description")]
        public string Description { get; }

        [JsonPropertyName("name")]
        public string? Name { get; }

        [JsonPropertyName("product_id")]
        public string ProductId { get; }

        [JsonPropertyName("tax_mode")]
        public TaxMode TaxMode { get; }

        [JsonPropertyName("unit_price")]
        public Money UnitPrice { get; }

        [JsonPropertyName("unit_price_overrides")]
        public IReadOnlyList<UnitPriceOverride> UnitPriceOverrides { get; }

        [JsonPropertyName("quantity")]
        public PriceQuantity Quantity { get; }

        [JsonPropertyName("custom_data")]
        public CustomData? CustomData { get; }

        [JsonPropertyName("billing_cycle")]
        public TimePeriod? BillingCycle { get; }

        [JsonPropertyName("trial_period")]
        public TimePeriod? TrialPeriod { get; }

        private SubscriptionNonCatalogPrice(
            string description,
            string? name,
            string productId,
            TaxMode taxMode,
            Money unitPrice,
            IReadOnlyList<UnitPriceOverride> unitPriceOverrides,
            PriceQuantity quantity,
            CustomData? customData,
            TimePeriod? billingCycle,
            TimePeriod? trialPeriod)
        {
            Description = description;
            Name = name;
            ProductId = productId;
            TaxMode = taxMode;
            UnitPrice = unitPrice;
            UnitPriceOverrides = unitPriceOverrides;
            Quantity = quantity;
            CustomData = customData;
            BillingCycle = billingCycle;
            TrialPeriod = trialPeriod;
        }

        public static SubscriptionNonCatalogPrice From(Dictionary<string, object> data)
        {
            List<UnitPriceOverride> unitPriceOverrides = new();
            if (data.ContainsKey("unit_price_overrides"))
            {
                object[] overridesData = (object[])data["unit_price_overrides"];
                foreach (object item in overridesData)
                {
                    unitPriceOverrides.Add(UnitPriceOverride.From((Dictionary<string, object>)item));
                }
            }

            return new SubscriptionNonCatalogPrice(
                description: (string)data["description"],
                name: data.ContainsKey("name") ? (string?)data["name"] : null,
                productId: (string)data["product_id"],
                taxMode: Enum.Parse<TaxMode>((string)data["tax_mode"], true),
                unitPrice: Money.From((Dictionary<string, object>)data["unit_price"]),
                unitPriceOverrides: unitPriceOverrides,
                quantity: PriceQuantity.From((Dictionary<string, object>)data["quantity"]),
                customData: data.ContainsKey("custom_data") ? CustomData.From((Dictionary<string, object>)data["custom_data"]) : null,
                billingCycle: data.ContainsKey("billing_cycle") ? TimePeriod.From((Dictionary<string, object>)data["billing_cycle"]) : null,
                trialPeriod: data.ContainsKey("trial_period") ? TimePeriod.From((Dictionary<string, object>)data["trial_period"]) : null
            );
        }
    }
}