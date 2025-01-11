using System.Collections.Generic;
using System.Text.Json.Serialization;
using PaddleWrapper.Entities.Shared;

namespace PaddleWrapper.Entities.Subscription
{
    public class SubscriptionNonCatalogPriceWithProduct
    {
        [JsonPropertyName("description")]
        public string Description { get; }

        [JsonPropertyName("name")]
        public string? Name { get; }

        [JsonPropertyName("product")]
        public SubscriptionNonCatalogProduct Product { get; }

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

        private SubscriptionNonCatalogPriceWithProduct(
            string description,
            string? name,
            SubscriptionNonCatalogProduct product,
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
            Product = product;
            TaxMode = taxMode;
            UnitPrice = unitPrice;
            UnitPriceOverrides = unitPriceOverrides;
            Quantity = quantity;
            CustomData = customData;
            BillingCycle = billingCycle;
            TrialPeriod = trialPeriod;
        }

        public static SubscriptionNonCatalogPriceWithProduct From(Dictionary<string, object> data)
        {
            var unitPriceOverrides = new List<UnitPriceOverride>();
            if (data.ContainsKey("unit_price_overrides"))
            {
                var overridesData = (object[])data["unit_price_overrides"];
                foreach (var item in overridesData)
                {
                    unitPriceOverrides.Add(UnitPriceOverride.From((Dictionary<string, object>)item));
                }
            }

            return new SubscriptionNonCatalogPriceWithProduct(
                description: (string)data["description"],
                name: data.ContainsKey("name") ? (string?)data["name"] : null,
                product: SubscriptionNonCatalogProduct.From((Dictionary<string, object>)data["product"]),
                taxMode: System.Enum.Parse<TaxMode>((string)data["tax_mode"], true),
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