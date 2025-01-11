using System.Collections.Generic;
using System.Text.Json.Serialization;
using PaddleWrapper.Entities.Shared;

namespace PaddleWrapper.Resources.Transactions.Operations.Price
{
    public class TransactionNonCatalogPrice
    {
        [JsonPropertyName("description")]
        public string Description { get; }

        [JsonPropertyName("unit_price")]
        public Money UnitPrice { get; }

        [JsonPropertyName("product_id")]
        public string ProductId { get; }

        [JsonPropertyName("name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Name { get; }

        [JsonPropertyName("billing_cycle")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TimePeriod BillingCycle { get; }

        [JsonPropertyName("trial_period")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TimePeriod TrialPeriod { get; }

        [JsonPropertyName("tax_mode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string TaxMode { get; }

        [JsonPropertyName("unit_price_overrides")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<UnitPriceOverride> UnitPriceOverrides { get; }

        [JsonPropertyName("quantity")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public PriceQuantity Quantity { get; }

        [JsonPropertyName("custom_data")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CustomData CustomData { get; }

        public TransactionNonCatalogPrice(
            string description,
            Money unitPrice,
            string productId,
            string name = null,
            TimePeriod billingCycle = null,
            TimePeriod trialPeriod = null,
            TaxMode? taxMode = null,
            IEnumerable<UnitPriceOverride> unitPriceOverrides = null,
            PriceQuantity quantity = null,
            CustomData customData = null)
        {
            Description = description;
            UnitPrice = unitPrice;
            ProductId = productId;
            Name = name;
            BillingCycle = billingCycle;
            TrialPeriod = trialPeriod;
            TaxMode = taxMode?.ToString().ToLower();
            UnitPriceOverrides = unitPriceOverrides;
            Quantity = quantity;
            CustomData = customData;
        }
    }
} 