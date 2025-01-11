using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using PaddleWrapper.Entities.Discount;
using PaddleWrapper.Entities.Shared;

namespace PaddleWrapper.Entities
{
    public class Discount
    {
        [JsonPropertyName("id")]
        public string Id { get; }

        [JsonPropertyName("status")]
        public DiscountStatus Status { get; }

        [JsonPropertyName("description")]
        public string Description { get; }

        [JsonPropertyName("enabled_for_checkout")]
        public bool EnabledForCheckout { get; }

        [JsonPropertyName("code")]
        public string? Code { get; }

        [JsonPropertyName("type")]
        public DiscountType Type { get; }

        [JsonPropertyName("amount")]
        public string Amount { get; }

        [JsonPropertyName("currency_code")]
        public CurrencyCode? CurrencyCode { get; }

        [JsonPropertyName("recur")]
        public bool Recur { get; }

        [JsonPropertyName("maximum_recurring_intervals")]
        public int? MaximumRecurringIntervals { get; }

        [JsonPropertyName("usage_limit")]
        public int? UsageLimit { get; }

        [JsonPropertyName("restrict_to")]
        public object[]? RestrictTo { get; }

        [JsonPropertyName("expires_at")]
        public DateTime? ExpiresAt { get; }

        [JsonPropertyName("times_used")]
        public int TimesUsed { get; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; }

        [JsonPropertyName("custom_data")]
        public CustomData? CustomData { get; }

        [JsonPropertyName("import_meta")]
        public ImportMeta? ImportMeta { get; }

        private Discount(
            string id,
            DiscountStatus status,
            string description,
            bool enabledForCheckout,
            string? code,
            DiscountType type,
            string amount,
            CurrencyCode? currencyCode,
            bool recur,
            int? maximumRecurringIntervals,
            int? usageLimit,
            object[]? restrictTo,
            DateTime? expiresAt,
            int timesUsed,
            DateTime createdAt,
            DateTime updatedAt,
            CustomData? customData,
            ImportMeta? importMeta)
        {
            Id = id;
            Status = status;
            Description = description;
            EnabledForCheckout = enabledForCheckout;
            Code = code;
            Type = type;
            Amount = amount;
            CurrencyCode = currencyCode;
            Recur = recur;
            MaximumRecurringIntervals = maximumRecurringIntervals;
            UsageLimit = usageLimit;
            RestrictTo = restrictTo;
            ExpiresAt = expiresAt;
            TimesUsed = timesUsed;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            CustomData = customData;
            ImportMeta = importMeta;
        }

        public static Discount From(Dictionary<string, object> data)
        {
            return new Discount(
                id: (string)data["id"],
                status: System.Enum.Parse<DiscountStatus>((string)data["status"], true),
                description: (string)data["description"],
                enabledForCheckout: (bool)data["enabled_for_checkout"],
                code: data.ContainsKey("code") ? (string?)data["code"] : null,
                type: System.Enum.Parse<DiscountType>((string)data["type"], true),
                amount: (string)data["amount"],
                currencyCode: data.ContainsKey("currency_code") && data["currency_code"] != null ? 
                    System.Enum.Parse<CurrencyCode>((string)data["currency_code"], true) : null,
                recur: (bool)data["recur"],
                maximumRecurringIntervals: (int?)data["maximum_recurring_intervals"],
                usageLimit: data.ContainsKey("usage_limit") ? (int?)data["usage_limit"] : null,
                restrictTo: data.ContainsKey("restrict_to") ? (object[]?)data["restrict_to"] : null,
                expiresAt: data.ContainsKey("expires_at") ? 
                    DateTime.Parse((string)data["expires_at"]) : null,
                timesUsed: (int)data["times_used"],
                createdAt: DateTime.Parse((string)data["created_at"]),
                updatedAt: DateTime.Parse((string)data["updated_at"]),
                customData: data.ContainsKey("custom_data") ? 
                    CustomData.From((Dictionary<string, object>)data["custom_data"]) : null,
                importMeta: data.ContainsKey("import_meta") ? 
                    ImportMeta.From((Dictionary<string, object>)data["import_meta"]) : null
            );
        }
    }
} 