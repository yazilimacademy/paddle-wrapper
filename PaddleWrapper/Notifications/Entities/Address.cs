using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities;

public class Address : IEntity
{
    [JsonPropertyName("id")]
    public string Id { get; }

    [JsonPropertyName("description")]
    public string? Description { get; }

    [JsonPropertyName("first_line")]
    public string? FirstLine { get; }

    [JsonPropertyName("second_line")]
    public string? SecondLine { get; }

    [JsonPropertyName("city")]
    public string? City { get; }

    [JsonPropertyName("postal_code")]
    public string? PostalCode { get; }

    [JsonPropertyName("region")]
    public string? Region { get; }

    [JsonPropertyName("country_code")]
    public CountryCode CountryCode { get; }

    [JsonPropertyName("custom_data")]
    public CustomData? CustomData { get; }

    [JsonPropertyName("status")]
    public Status Status { get; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; }

    [JsonPropertyName("import_meta")]
    public ImportMeta? ImportMeta { get; }

    [JsonPropertyName("customer_id")]
    public string? CustomerId { get; }

    private Address(
        string id,
        string? description,
        string? firstLine,
        string? secondLine,
        string? city,
        string? postalCode,
        string? region,
        CountryCode countryCode,
        CustomData? customData,
        Status status,
        DateTime createdAt,
        DateTime updatedAt,
        ImportMeta? importMeta,
        string? customerId)
    {
        Id = id;
        Description = description;
        FirstLine = firstLine;
        SecondLine = secondLine;
        City = city;
        PostalCode = postalCode;
        Region = region;
        CountryCode = countryCode;
        CustomData = customData;
        Status = status;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        ImportMeta = importMeta;
        CustomerId = customerId;
    }

    public static Address FromJson(JsonElement json)
    {
        return new Address(
            json.GetProperty("id").GetString()!,
            json.TryGetProperty("description", out var description) ? description.GetString() : null,
            json.TryGetProperty("first_line", out var firstLine) ? firstLine.GetString() : null,
            json.TryGetProperty("second_line", out var secondLine) ? secondLine.GetString() : null,
            json.TryGetProperty("city", out var city) ? city.GetString() : null,
            json.TryGetProperty("postal_code", out var postalCode) ? postalCode.GetString() : null,
            json.TryGetProperty("region", out var region) ? region.GetString() : null,
            JsonSerializer.Deserialize<CountryCode>(json.GetProperty("country_code").GetRawText()),
            json.TryGetProperty("custom_data", out var customData) ? CustomData.FromJson(customData) : null,
            JsonSerializer.Deserialize<Status>(json.GetProperty("status").GetRawText()),
            DateTime.Parse(json.GetProperty("created_at").GetString()!),
            DateTime.Parse(json.GetProperty("updated_at").GetString()!),
            json.TryGetProperty("import_meta", out var importMeta) ? ImportMeta.FromJson(importMeta) : null,
            json.TryGetProperty("customer_id", out var customerId) ? customerId.GetString() : null
        );
    }
} 