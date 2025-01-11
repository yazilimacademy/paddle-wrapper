using System.Collections.Generic;
using System.Text.Json.Serialization;
using PaddleWrapper.Entities.Discount;
using PaddleWrapper.Entities.Shared;

namespace PaddleWrapper.Resources.Discounts.Operations
{
    public class CreateDiscount
    {
        [JsonPropertyName("amount")]
        public string Amount { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("type")]
        public DiscountType Type { get; set; }

        [JsonPropertyName("enabled_for_checkout")]
        public bool EnabledForCheckout { get; set; }

        [JsonPropertyName("recur")]
        public bool Recur { get; set; }

        [JsonPropertyName("currency_code")]
        public CurrencyCode CurrencyCode { get; set; }

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

        [JsonPropertyName("custom_data")]
        public CustomData? CustomData { get; set; }

        public CreateDiscount(
            string amount,
            string description,
            DiscountType type,
            bool enabledForCheckout,
            bool recur,
            CurrencyCode currencyCode,
            string? code = null,
            int? maximumRecurringIntervals = null,
            int? usageLimit = null,
            List<string>? restrictTo = null,
            string? expiresAt = null,
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
            CustomData = customData;
        }
    }
} 