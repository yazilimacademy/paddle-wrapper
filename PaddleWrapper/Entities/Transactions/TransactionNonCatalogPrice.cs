using PaddleWrapper.Entities.Shared;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Transactions
{
    public class TransactionNonCatalogPrice
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

        [JsonPropertyName("product_id")]
        public string ProductId { get; }

        private TransactionNonCatalogPrice(
            string description,
            string? name,
            TimePeriod? billingCycle,
            TimePeriod? trialPeriod,
            TaxMode taxMode,
            Money unitPrice,
            IReadOnlyList<UnitPriceOverride> unitPriceOverrides,
            PriceQuantity quantity,
            CustomData? customData,
            string productId)
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
            ProductId = productId;
        }

        public static TransactionNonCatalogPrice From(Dictionary<string, object> data)
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

            return new TransactionNonCatalogPrice(
                description: (string)data["description"],
                name: data.ContainsKey("name") ? (string?)data["name"] : null,
                billingCycle: data.ContainsKey("billing_cycle") ? TimePeriod.From((Dictionary<string, object>)data["billing_cycle"]) : null,
                trialPeriod: data.ContainsKey("trial_period") ? TimePeriod.From((Dictionary<string, object>)data["trial_period"]) : null,
                taxMode: Enum.Parse<TaxMode>((string)data["tax_mode"], true),
                unitPrice: Money.From((Dictionary<string, object>)data["unit_price"]),
                unitPriceOverrides: unitPriceOverrides,
                quantity: PriceQuantity.From((Dictionary<string, object>)data["quantity"]),
                customData: data.ContainsKey("custom_data") ? CustomData.From((Dictionary<string, object>)data["custom_data"]) : null,
                productId: (string)data["product_id"]
            );
        }
    }
}