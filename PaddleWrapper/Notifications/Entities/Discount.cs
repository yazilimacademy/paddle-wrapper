using System.Text.Json;
using System.Text.Json.Serialization;
using PaddleWrapper.Notifications.Entities.Discount;
using PaddleWrapper.Notifications.Entities.Shared;

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
        var id = element.GetProperty("id").GetString()!;
        var status = JsonSerializer.Deserialize<DiscountStatus>(element.GetProperty("status"));
        var description = element.GetProperty("description").GetString()!;
        var enabledForCheckout = element.GetProperty("enabled_for_checkout").GetBoolean();
        var code = element.TryGetProperty("code", out var codeElement) ? codeElement.GetString() : null;
        var type = JsonSerializer.Deserialize<DiscountType>(element.GetProperty("type"));
        var amount = element.GetProperty("amount").GetString()!;
        
        CurrencyCode? currencyCode = null;
        if (element.TryGetProperty("currency_code", out var currencyCodeElement) && !currencyCodeElement.ValueKind.Equals(JsonValueKind.Null))
        {
            currencyCode = JsonSerializer.Deserialize<CurrencyCode>(currencyCodeElement);
        }

        var recur = element.GetProperty("recur").GetBoolean();
        
        int? maximumRecurringIntervals = null;
        if (element.TryGetProperty("maximum_recurring_intervals", out var maxIntervalsElement) && !maxIntervalsElement.ValueKind.Equals(JsonValueKind.Null))
        {
            maximumRecurringIntervals = maxIntervalsElement.GetInt32();
        }

        int? usageLimit = null;
        if (element.TryGetProperty("usage_limit", out var usageLimitElement) && !usageLimitElement.ValueKind.Equals(JsonValueKind.Null))
        {
            usageLimit = usageLimitElement.GetInt32();
        }

        JsonElement? restrictTo = null;
        if (element.TryGetProperty("restrict_to", out var restrictToElement) && !restrictToElement.ValueKind.Equals(JsonValueKind.Null))
        {
            restrictTo = restrictToElement;
        }

        CustomData? customData = null;
        if (element.TryGetProperty("custom_data", out var customDataElement) && !customDataElement.ValueKind.Equals(JsonValueKind.Null))
        {
            customData = CustomData.FromJson(customDataElement);
        }

        ImportMeta? importMeta = null;
        if (element.TryGetProperty("import_meta", out var importMetaElement) && !importMetaElement.ValueKind.Equals(JsonValueKind.Null))
        {
            importMeta = ImportMeta.FromJson(importMetaElement);
        }

        DateTime? expiresAt = null;
        if (element.TryGetProperty("expires_at", out var expiresAtElement) && !expiresAtElement.ValueKind.Equals(JsonValueKind.Null))
        {
            expiresAt = DateTime.Parse(expiresAtElement.GetString()!);
        }

        var createdAt = DateTime.Parse(element.GetProperty("created_at").GetString()!);
        var updatedAt = DateTime.Parse(element.GetProperty("updated_at").GetString()!);

        return new Discount(id, status, description, enabledForCheckout, code, type, amount, currencyCode,
            recur, maximumRecurringIntervals, usageLimit, restrictTo, customData, importMeta, expiresAt,
            createdAt, updatedAt);
    }
} 