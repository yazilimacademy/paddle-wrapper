using System.Collections.Generic;
using System.Text.Json.Serialization;
using PaddleWrapper.Entities.Shared;

namespace PaddleWrapper.Entities.Transaction
{
    public class TransactionNonCatalogPriceWithProduct
    {
        [JsonPropertyName("description")]
        public string Description { get; }

        [JsonPropertyName("name")]
        public string? Name { get; }

        [JsonPropertyName("billing_cycle")]
        public TimePeriod? BillingCycle { get; }

        [JsonPropertyName("trial_period")]
        public TimePeriod? TrialPeriod { get; }

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

        [JsonPropertyName("product")]
        public TransactionNonCatalogProduct Product { get; }

        private TransactionNonCatalogPriceWithProduct(
            string description,
            string? name,
            TimePeriod? billingCycle,
            TimePeriod? trialPeriod,
            TaxMode taxMode,
            Money unitPrice,
            IReadOnlyList<UnitPriceOverride> unitPriceOverrides,
            PriceQuantity quantity,
            CustomData? customData,
            TransactionNonCatalogProduct product)
        {
            Description = description;
            Name = name;
            BillingCycle = billingCycle;
            TrialPeriod = trialPeriod;
            TaxMode = taxMode;
            UnitPrice = unitPrice;
            UnitPriceOverrides = unitPriceOverrides;
            Quantity = quantity;
            CustomData = customData;
            Product = product;
        }

        public static TransactionNonCatalogPriceWithProduct From(Dictionary<string, object> data)
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

            return new TransactionNonCatalogPriceWithProduct(
                description: (string)data["description"],
                name: data.ContainsKey("name") ? (string?)data["name"] : null,
                billingCycle: data.ContainsKey("billing_cycle") ? TimePeriod.From((Dictionary<string, object>)data["billing_cycle"]) : null,
                trialPeriod: data.ContainsKey("trial_period") ? TimePeriod.From((Dictionary<string, object>)data["trial_period"]) : null,
                taxMode: System.Enum.Parse<TaxMode>((string)data["tax_mode"], true),
                unitPrice: Money.From((Dictionary<string, object>)data["unit_price"]),
                unitPriceOverrides: unitPriceOverrides,
                quantity: PriceQuantity.From((Dictionary<string, object>)data["quantity"]),
                customData: data.ContainsKey("custom_data") ? CustomData.From((Dictionary<string, object>)data["custom_data"]) : null,
                product: TransactionNonCatalogProduct.From((Dictionary<string, object>)data["product"])
            );
        }
    }
} 