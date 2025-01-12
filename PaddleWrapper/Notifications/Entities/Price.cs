using PaddleWrapper.Notifications.Entities.Shared;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities;

public class Price : IEntity
{
    [JsonPropertyName("id")]
    public string Id { get; }

    [JsonPropertyName("product_id")]
    public string ProductId { get; }

    [JsonPropertyName("name")]
    public string? Name { get; }

    [JsonPropertyName("description")]
    public string Description { get; }

    [JsonPropertyName("type")]
    public CatalogType? Type { get; }

    [JsonPropertyName("billing_cycle")]
    public TimePeriod? BillingCycle { get; }

    [JsonPropertyName("trial_period")]
    public TimePeriod? TrialPeriod { get; }

    [JsonPropertyName("tax_mode")]
    public TaxMode TaxMode { get; }

    [JsonPropertyName("unit_price")]
    public Money UnitPrice { get; }

    [JsonPropertyName("unit_price_overrides")]
    public IReadOnlyList<UnitPriceOverride> UnitPriceOverrides { get; }

    [JsonPropertyName("quantity")]
    public PriceQuantity Quantity { get; }

    [JsonPropertyName("status")]
    public Status Status { get; }

    [JsonPropertyName("custom_data")]
    public CustomData? CustomData { get; }

    [JsonPropertyName("import_meta")]
    public ImportMeta? ImportMeta { get; }

    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; }

    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; }

    private Price(
        string id,
        string productId,
        string? name,
        string description,
        CatalogType? type,
        TimePeriod? billingCycle,
        TimePeriod? trialPeriod,
        TaxMode taxMode,
        Money unitPrice,
        IReadOnlyList<UnitPriceOverride> unitPriceOverrides,
        PriceQuantity quantity,
        Status status,
        CustomData? customData,
        ImportMeta? importMeta,
        DateTime? createdAt,
        DateTime? updatedAt)
    {
        Id = id;
        ProductId = productId;
        Name = name;
        Description = description;
        Type = type;
        BillingCycle = billingCycle;
        TrialPeriod = trialPeriod;
        TaxMode = taxMode;
        UnitPrice = unitPrice;
        UnitPriceOverrides = unitPriceOverrides;
        Quantity = quantity;
        Status = status;
        CustomData = customData;
        ImportMeta = importMeta;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public static IEntity FromJson(JsonElement json)
    {
        List<UnitPriceOverride> unitPriceOverrides = new();
        if (json.TryGetProperty("unit_price_overrides", out JsonElement overridesElement))
        {
            foreach (JsonElement override_ in overridesElement.EnumerateArray())
            {
                unitPriceOverrides.Add(UnitPriceOverride.FromJson(override_));
            }
        }

        return new Price(
            id: json.GetProperty("id").GetString()!,
            productId: json.GetProperty("product_id").GetString()!,
            name: json.TryGetProperty("name", out JsonElement nameElement) ? nameElement.GetString() : null,
            description: json.GetProperty("description").GetString()!,
            type: json.TryGetProperty("type", out JsonElement typeElement)
                ? JsonSerializer.Deserialize<CatalogType>(typeElement.GetRawText())
                : null,
            billingCycle: json.TryGetProperty("billing_cycle", out JsonElement billingElement)
                ? TimePeriod.FromJson(billingElement)
                : null,
            trialPeriod: json.TryGetProperty("trial_period", out JsonElement trialElement)
                ? TimePeriod.FromJson(trialElement)
                : null,
            taxMode: JsonSerializer.Deserialize<TaxMode>(json.GetProperty("tax_mode").GetRawText())!,
            unitPrice: Money.FromJson(json.GetProperty("unit_price")),
            unitPriceOverrides: unitPriceOverrides,
            quantity: PriceQuantity.FromJson(json.GetProperty("quantity")),
            status: JsonSerializer.Deserialize<Status>(json.GetProperty("status").GetRawText())!,
            customData: json.TryGetProperty("custom_data", out JsonElement customDataElement)
                ? CustomData.FromJson(customDataElement)
                : null,
            importMeta: json.TryGetProperty("import_meta", out JsonElement importMetaElement)
                ? ImportMeta.FromJson(importMetaElement)
                : null,
            createdAt: json.TryGetProperty("created_at", out JsonElement createdAtElement)
                ? DateTime.Parse(createdAtElement.GetString()!)
                : null,
            updatedAt: json.TryGetProperty("updated_at", out JsonElement updatedAtElement)
                ? DateTime.Parse(updatedAtElement.GetString()!)
                : null
        );
    }
}