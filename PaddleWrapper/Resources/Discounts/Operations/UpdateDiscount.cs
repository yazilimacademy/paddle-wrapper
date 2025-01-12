using PaddleWrapper.Entities.Shared;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Resources.Discounts.Operations
{
    public class UpdateDiscount
    {
        [JsonPropertyName("amount")]
        public string? Amount { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("type")]
        public DiscountType? Type { get; set; }

        [JsonPropertyName("enabled_for_checkout")]
        public bool? EnabledForCheckout { get; set; }

        [JsonPropertyName("recur")]
        public bool? Recur { get; set; }

        [JsonPropertyName("currency_code")]
        public CurrencyCode? CurrencyCode { get; set; }

        [JsonPropertyName("code")]
        public string? Code { get; set; }

        [JsonPropertyName("maximum_recurring_intervals")]
        public int? MaximumRecurringIntervals { get; set; }

        [JsonPropertyName("usage_limit")]
        public int? UsageLimit { get; set; }

        [JsonPropertyName("restrict_to")]
        public List<string>? RestrictTo { get; set; }

        [JsonPropertyName("expires_at")]
        public string? ExpiresAt { get; set; }

        [JsonPropertyName("status")]
        public DiscountStatus? Status { get; set; }

        [JsonPropertyName("custom_data")]
        public CustomData? CustomData { get; set; }

        public UpdateDiscount(
            string? amount = null,
            string? description = null,
            DiscountType? type = null,
            bool? enabledForCheckout = null,
            bool? recur = null,
            CurrencyCode? currencyCode = null,
            string? code = null,
            int? maximumRecurringIntervals = null,
            int? usageLimit = null,
            List<string>? restrictTo = null,
            string? expiresAt = null,
            DiscountStatus? status = null,
            CustomData? customData = null)
        {
            Amount = amount;
            Description = description;
            Type = type;
            EnabledForCheckout = enabledForCheckout;
            Recur = recur;
            CurrencyCode = currencyCode;
            Code = code;
            MaximumRecurringIntervals = maximumRecurringIntervals;
            UsageLimit = usageLimit;
            RestrictTo = restrictTo;
            ExpiresAt = expiresAt;
            Status = status;
            CustomData = customData;
        }
    }
}