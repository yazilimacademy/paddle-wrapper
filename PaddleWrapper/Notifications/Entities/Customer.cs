using System.Text.Json;
using System.Text.Json.Serialization;
using PaddleWrapper.Notifications.Entities.Shared;

namespace PaddleWrapper.Notifications.Entities;

public class Customer : IEntity
{
    [JsonPropertyName("id")]
    public string Id { get; }

    [JsonPropertyName("name")]
    public string? Name { get; }

    [JsonPropertyName("email")]
    public string Email { get; }

    [JsonPropertyName("marketing_consent")]
    public bool MarketingConsent { get; }

    [JsonPropertyName("status")]
    public Status Status { get; }

    [JsonPropertyName("custom_data")]
    public CustomData? CustomData { get; }

    [JsonPropertyName("locale")]
    public string Locale { get; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; }

    [JsonPropertyName("import_meta")]
    public ImportMeta? ImportMeta { get; }

    private Customer(string id, string? name, string email, bool marketingConsent, Status status, CustomData? customData, string locale, DateTime createdAt, DateTime updatedAt, ImportMeta? importMeta)
    {
        Id = id;
        Name = name;
        Email = email;
        MarketingConsent = marketingConsent;
        Status = status;
        CustomData = customData;
        Locale = locale;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        ImportMeta = importMeta;
    }

    public static Customer FromJson(JsonElement json)
    {
        var id = json.GetProperty("id").GetString()!;
        var name = json.TryGetProperty("name", out var nameElement) ? nameElement.GetString() : null;
        var email = json.GetProperty("email").GetString()!;
        var marketingConsent = json.GetProperty("marketing_consent").GetBoolean();
        var status = Status.FromJson(json.GetProperty("status"));
        var customData = json.TryGetProperty("custom_data", out var customDataElement) ? CustomData.FromJson(customDataElement) : null;
        var locale = json.GetProperty("locale").GetString()!;
        var createdAt = DateTime.Parse(json.GetProperty("created_at").GetString()!);
        var updatedAt = DateTime.Parse(json.GetProperty("updated_at").GetString()!);
        var importMeta = json.TryGetProperty("import_meta", out var importMetaElement) ? ImportMeta.FromJson(importMetaElement) : null;

        return new Customer(id, name, email, marketingConsent, status, customData, locale, createdAt, updatedAt, importMeta);
    }
} 