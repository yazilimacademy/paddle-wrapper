using System.Text.Json.Serialization;

namespace PaddleWrapper.Models
{
    public class Price
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("product_id")]
        public string ProductId { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("billing_cycle")]
        public BillingCycle BillingCycle { get; set; }

        [JsonPropertyName("trial_period")]
        public BillingCycle TrialPeriod { get; set; }

        [JsonPropertyName("tax_mode")]
        public string TaxMode { get; set; }

        [JsonPropertyName("unit_price")]
        public PriceAmount UnitPrice { get; set; }

        [JsonPropertyName("unit_price_overrides")]
        public PriceOverride[] UnitPriceOverrides { get; set; }

        [JsonPropertyName("quantity")]
        public PriceQuantity Quantity { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("custom_data")]
        public object CustomData { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }

    public class PriceAmount
    {
        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("currency_code")]
        public string CurrencyCode { get; set; }
    }

    public class PriceOverride
    {
        [JsonPropertyName("country_codes")]
        public string[] CountryCodes { get; set; }

        [JsonPropertyName("unit_price")]
        public PriceAmount UnitPrice { get; set; }
    }

    public class PriceQuantity
    {
        [JsonPropertyName("minimum")]
        public int Minimum { get; set; }

        [JsonPropertyName("maximum")]
        public int? Maximum { get; set; }
    }
}