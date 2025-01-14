using PaddleWrapper.Notifications.Entities.Shared;
using System.Text.Json;
using System.Text.Json.Serialization;

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
    public string? Locale { get; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; }

    [JsonPropertyName("import_meta")]
    public ImportMeta? ImportMeta { get; }

    private Customer(
        string id,
        string? name,
        string email,
        bool marketingConsent,
        Status status,
        CustomData? customData,
        string? locale,
        DateTime createdAt,
        DateTime updatedAt,
        ImportMeta? importMeta)
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
        if (json.ValueKind == JsonValueKind.Null)
        {
            throw new JsonException("Customer data cannot be null");
        }

        string id = json.GetProperty("id").GetString() ?? throw new JsonException("Customer id cannot be null");
        string? name = json.TryGetProperty("name", out JsonElement nameElement) ? nameElement.GetString() : null;
        string email = json.GetProperty("email").GetString() ?? throw new JsonException("Customer email cannot be null");
        bool marketingConsent = json.GetProperty("marketing_consent").GetBoolean();
        Status status = PaddleEnum.FromJson<Status>(json.GetProperty("status"));
        CustomData? customData = json.TryGetProperty("custom_data", out JsonElement customDataElement) ? CustomData.FromJson(customDataElement) : null;
        string? locale = json.TryGetProperty("locale", out JsonElement localeElement) ? localeElement.GetString() : null;

        string? createdAtStr = json.GetProperty("created_at").GetString();
        if (createdAtStr == null)
        {
            throw new JsonException("Customer created_at cannot be null");
        }
        DateTime createdAt = DateTime.Parse(createdAtStr);

        string? updatedAtStr = json.GetProperty("updated_at").GetString();
        if (updatedAtStr == null)
        {
            throw new JsonException("Customer updated_at cannot be null");
        }
        DateTime updatedAt = DateTime.Parse(updatedAtStr);

        ImportMeta? importMeta = json.TryGetProperty("import_meta", out JsonElement importMetaElement) ? ImportMeta.FromJson(importMetaElement) : null;

        return new Customer(id, name, email, marketingConsent, status, customData, locale, createdAt, updatedAt, importMeta);
    }
}