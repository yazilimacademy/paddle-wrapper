using PaddleWrapper.Notifications.Entities.Discounts;
using PaddleWrapper.Notifications.Entities.Shared;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities;

public class Discount : IEntity
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
    public JsonElement? RestrictTo { get; }

    [JsonPropertyName("custom_data")]
    public CustomData? CustomData { get; }

    [JsonPropertyName("import_meta")]
    public ImportMeta? ImportMeta { get; }

    [JsonPropertyName("expires_at")]
    public DateTime? ExpiresAt { get; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; }

    private Discount(string id, DiscountStatus status, string description, bool enabledForCheckout, string? code,
        DiscountType type, string amount, CurrencyCode? currencyCode, bool recur, int? maximumRecurringIntervals,
        int? usageLimit, JsonElement? restrictTo, CustomData? customData, ImportMeta? importMeta, DateTime? expiresAt,
        DateTime createdAt, DateTime updatedAt)
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
        CustomData = customData;
        ImportMeta = importMeta;
        ExpiresAt = expiresAt;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public static Discount FromJson(JsonElement element)
    {
        string id = element.GetProperty("id").GetString()!;
        DiscountStatus status = JsonSerializer.Deserialize<DiscountStatus>(element.GetProperty("status"));
        string description = element.GetProperty("description").GetString()!;
        bool enabledForCheckout = element.GetProperty("enabled_for_checkout").GetBoolean();
        string? code = element.TryGetProperty("code", out JsonElement codeElement) ? codeElement.GetString() : null;
        DiscountType type = JsonSerializer.Deserialize<DiscountType>(element.GetProperty("type"));
        string amount = element.GetProperty("amount").GetString()!;

        CurrencyCode? currencyCode = null;
        if (element.TryGetProperty("currency_code", out JsonElement currencyCodeElement) && !currencyCodeElement.ValueKind.Equals(JsonValueKind.Null))
        {
            currencyCode = JsonSerializer.Deserialize<CurrencyCode>(currencyCodeElement);
        }

        bool recur = element.GetProperty("recur").GetBoolean();

        int? maximumRecurringIntervals = null;
        if (element.TryGetProperty("maximum_recurring_intervals", out JsonElement maxIntervalsElement) && !maxIntervalsElement.ValueKind.Equals(JsonValueKind.Null))
        {
            maximumRecurringIntervals = maxIntervalsElement.GetInt32();
        }

        int? usageLimit = null;
        if (element.TryGetProperty("usage_limit", out JsonElement usageLimitElement) && !usageLimitElement.ValueKind.Equals(JsonValueKind.Null))
        {
            usageLimit = usageLimitElement.GetInt32();
        }

        JsonElement? restrictTo = null;
        if (element.TryGetProperty("restrict_to", out JsonElement restrictToElement) && !restrictToElement.ValueKind.Equals(JsonValueKind.Null))
        {
            restrictTo = restrictToElement;
        }

        CustomData? customData = null;
        if (element.TryGetProperty("custom_data", out JsonElement customDataElement) && !customDataElement.ValueKind.Equals(JsonValueKind.Null))
        {
            customData = CustomData.FromJson(customDataElement);
        }

        ImportMeta? importMeta = null;
        if (element.TryGetProperty("import_meta", out JsonElement importMetaElement) && !importMetaElement.ValueKind.Equals(JsonValueKind.Null))
        {
            importMeta = ImportMeta.FromJson(importMetaElement);
        }

        DateTime? expiresAt = null;
        if (element.TryGetProperty("expires_at", out JsonElement expiresAtElement) && !expiresAtElement.ValueKind.Equals(JsonValueKind.Null))
        {
            expiresAt = DateTime.Parse(expiresAtElement.GetString()!);
        }

        DateTime? createdAt = DateTime.Parse(element.GetProperty("created_at").GetString()!);
        DateTime? updatedAt = DateTime.Parse(element.GetProperty("updated_at").GetString()!);

        return new Discount(id, status, description, enabledForCheckout, code, type, amount, currencyCode,
            recur, maximumRecurringIntervals, usageLimit, restrictTo, customData, importMeta, expiresAt,
            createdAt, updatedAt);
    }
}