using PaddleWrapper.Entities.Shared;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Resources.Prices.Operations
{
    public class UpdatePrice
    {
        [JsonPropertyName("description")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Description { get; set; }

        [JsonPropertyName("name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Name { get; set; }

        [JsonPropertyName("type")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CatalogType? Type { get; set; }

        [JsonPropertyName("billing_cycle")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TimePeriod? BillingCycle { get; set; }

        [JsonPropertyName("trial_period")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TimePeriod? TrialPeriod { get; set; }

        [JsonPropertyName("tax_mode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TaxMode? TaxMode { get; set; }

        [JsonPropertyName("unit_price")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Money? UnitPrice { get; set; }

        [JsonPropertyName("unit_price_overrides")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<UnitPriceOverride>? UnitPriceOverrides { get; set; }

        [JsonPropertyName("quantity")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public PriceQuantity? Quantity { get; set; }

        [JsonPropertyName("status")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Status? Status { get; set; }

        [JsonPropertyName("custom_data")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CustomData? CustomData { get; set; }
    }
}