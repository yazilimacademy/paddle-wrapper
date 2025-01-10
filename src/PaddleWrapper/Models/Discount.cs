using System.Text.Json.Serialization;

namespace PaddleWrapper.Models
{
    public class Discount
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("enabled_for_checkout")]
        public bool EnabledForCheckout { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("amount")]
        public DiscountAmount Amount { get; set; }

        [JsonPropertyName("recur")]
        public bool Recur { get; set; }

        [JsonPropertyName("maximum_recurring_intervals")]
        public int? MaximumRecurringIntervals { get; set; }

        [JsonPropertyName("usage_limit")]
        public int? UsageLimit { get; set; }

        [JsonPropertyName("restrict_to")]
        public DiscountRestrictions RestrictTo { get; set; }

        [JsonPropertyName("expires_at")]
        public DateTime? ExpiresAt { get; set; }

        [JsonPropertyName("times_used")]
        public int TimesUsed { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("currency_code")]
        public string CurrencyCode { get; set; }
    }

    public class DiscountAmount
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("value")]
        public decimal Value { get; set; }
    }

    public class DiscountRestrictions
    {
        [JsonPropertyName("products")]
        public string[] Products { get; set; }

        [JsonPropertyName("customers")]
        public string[] Customers { get; set; }

        [JsonPropertyName("minimum_order_amount")]
        public decimal? MinimumOrderAmount { get; set; }

        [JsonPropertyName("maximum_order_amount")]
        public decimal? MaximumOrderAmount { get; set; }
    }
}