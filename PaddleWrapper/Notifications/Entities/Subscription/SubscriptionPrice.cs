using System.Text.Json;
using System.Text.Json.Serialization;
using PaddleWrapper.Notifications.Entities.Shared;

namespace PaddleWrapper.Notifications.Entities.Subscription;

public class SubscriptionPrice
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("product_id")]
    public string ProductId { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("type")]
    public CatalogType? Type { get; set; }

    [JsonPropertyName("billing_cycle")]
    public TimePeriod? BillingCycle { get; set; }

    [JsonPropertyName("trial_period")]
    public TimePeriod? TrialPeriod { get; set; }

    [JsonPropertyName("tax_mode")]
    public TaxMode TaxMode { get; set; }

    [JsonPropertyName("unit_price")]
    public Money UnitPrice { get; set; }

    [JsonPropertyName("unit_price_overrides")]
    public List<UnitPriceOverride> UnitPriceOverrides { get; set; } = new();

    [JsonPropertyName("quantity")]
    public PriceQuantity? Quantity { get; set; }

    [JsonPropertyName("status")]
    public Status? Status { get; set; }

    [JsonPropertyName("custom_data")]
    public CustomData? CustomData { get; set; }

    [JsonPropertyName("import_meta")]
    public ImportMeta? ImportMeta { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }

    public static SubscriptionPrice FromJson(JsonElement data)
    {
        return new SubscriptionPrice
        {
            Id = data.GetProperty("id").GetString()!,
            ProductId = data.GetProperty("product_id").GetString()!,
            Name = data.TryGetProperty("name", out var name) ? name.GetString() : null,
            Description = data.GetProperty("description").GetString()!,
            Type = data.TryGetProperty("type", out var type) 
                ? JsonSerializer.Deserialize<CatalogType>(type.GetRawText()) 
                : null,
            BillingCycle = data.TryGetProperty("billing_cycle", out var billingCycle) 
                ? TimePeriod.FromJson(billingCycle) 
                : null,
            TrialPeriod = data.TryGetProperty("trial_period", out var trialPeriod) 
                ? TimePeriod.FromJson(trialPeriod) 
                : null,
            TaxMode = JsonSerializer.Deserialize<TaxMode>(data.GetProperty("tax_mode").GetRawText()),
            UnitPrice = Money.FromJson(data.GetProperty("unit_price")),
            UnitPriceOverrides = data.TryGetProperty("unit_price_overrides", out var overrides)
                ? overrides.EnumerateArray()
                    .Select(o => UnitPriceOverride.FromJson(o))
                    .ToList()
                : new List<UnitPriceOverride>(),
            Quantity = data.TryGetProperty("quantity", out var quantity) 
                ? PriceQuantity.FromJson(quantity) 
                : null,
            Status = data.TryGetProperty("status", out var status) 
                ? JsonSerializer.Deserialize<Status>(status.GetRawText()) 
                : null,
            CustomData = data.TryGetProperty("custom_data", out var customData) 
                ? CustomData.FromJson(customData) 
                : null,
            ImportMeta = data.TryGetProperty("import_meta", out var importMeta) 
                ? ImportMeta.FromJson(importMeta) 
                : null,
            CreatedAt = DateTime.Parse(data.GetProperty("created_at").GetString()!),
            UpdatedAt = DateTime.Parse(data.GetProperty("updated_at").GetString()!)
        };
    }
} 