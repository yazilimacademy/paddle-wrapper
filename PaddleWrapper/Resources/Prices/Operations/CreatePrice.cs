using PaddleWrapper.Entities.Shared;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Resources.Prices.Operations
{
    public class CreatePrice
    {
        [JsonPropertyName("description")]
        public string Description { get; }

        [JsonPropertyName("product_id")]
        public string ProductId { get; }

        [JsonPropertyName("unit_price")]
        public Money UnitPrice { get; }

        [JsonPropertyName("name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Name { get; }

        [JsonPropertyName("type")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CatalogType? Type { get; }

        [JsonPropertyName("unit_price_overrides")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<UnitPriceOverride>? UnitPriceOverrides { get; }

        [JsonPropertyName("tax_mode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TaxMode? TaxMode { get; }

        [JsonPropertyName("trial_period")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TimePeriod? TrialPeriod { get; }

        [JsonPropertyName("billing_cycle")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TimePeriod? BillingCycle { get; }

        [JsonPropertyName("quantity")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public PriceQuantity? Quantity { get; }

        [JsonPropertyName("custom_data")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CustomData? CustomData { get; }

        public CreatePrice(
            string description,
            string productId,
            Money unitPrice,
            string? name = null,
            CatalogType? type = null,
            IEnumerable<UnitPriceOverride>? unitPriceOverrides = null,
            TaxMode? taxMode = null,
            TimePeriod? trialPeriod = null,
            TimePeriod? billingCycle = null,
            PriceQuantity? quantity = null,
            CustomData? customData = null)
        {
            Description = description;
            ProductId = productId;
            UnitPrice = unitPrice;
            Name = name;
            Type = type;
            UnitPriceOverrides = unitPriceOverrides;
            TaxMode = taxMode;
            TrialPeriod = trialPeriod;
            BillingCycle = billingCycle;
            Quantity = quantity;
            CustomData = customData;
        }
    }
}