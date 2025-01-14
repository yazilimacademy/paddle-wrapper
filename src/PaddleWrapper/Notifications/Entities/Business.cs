using PaddleWrapper.Notifications.Entities.Businesses;
using PaddleWrapper.Notifications.Entities.Shared;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities;

public class Business : IEntity
{
    [JsonPropertyName("id")]
    public string Id { get; }

    [JsonPropertyName("name")]
    public string Name { get; }

    [JsonPropertyName("company_number")]
    public string? CompanyNumber { get; }

    [JsonPropertyName("tax_identifier")]
    public string? TaxIdentifier { get; }

    [JsonPropertyName("status")]
    public Status Status { get; }

    [JsonPropertyName("contacts")]
    public IReadOnlyList<BusinessesContacts> Contacts { get; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; }

    [JsonPropertyName("custom_data")]
    public CustomData? CustomData { get; }

    [JsonPropertyName("import_meta")]
    public ImportMeta? ImportMeta { get; }

    [JsonPropertyName("customer_id")]
    public string? CustomerId { get; }

    private Business(
        string id,
        string name,
        string? companyNumber,
        string? taxIdentifier,
        Status status,
        IReadOnlyList<BusinessesContacts> contacts,
        DateTime createdAt,
        DateTime updatedAt,
        CustomData? customData,
        ImportMeta? importMeta,
        string? customerId)
    {
        Id = id;
        Name = name;
        CompanyNumber = companyNumber;
        TaxIdentifier = taxIdentifier;
        Status = status;
        Contacts = contacts;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        CustomData = customData;
        ImportMeta = importMeta;
        CustomerId = customerId;
    }

    public static Business FromJson(JsonElement json)
    {
        return new Business(
            json.GetProperty("id").GetString()!,
            json.GetProperty("name").GetString()!,
            json.TryGetProperty("company_number", out JsonElement companyNumber) ? companyNumber.GetString() : null,
            json.TryGetProperty("tax_identifier", out JsonElement taxIdentifier) ? taxIdentifier.GetString() : null,
            JsonSerializer.Deserialize<Status>(json.GetProperty("status").GetRawText()),
            json.GetProperty("contacts").EnumerateArray()
                .Select(BusinessesContacts.FromJson)
                .ToList()
                .AsReadOnly(),
            DateTime.Parse(json.GetProperty("created_at").GetString()!),
            DateTime.Parse(json.GetProperty("updated_at").GetString()!),
            json.TryGetProperty("custom_data", out JsonElement customData) ? CustomData.FromJson(customData) : null,
            json.TryGetProperty("import_meta", out JsonElement importMeta) ? ImportMeta.FromJson(importMeta) : null,
            json.TryGetProperty("customer_id", out JsonElement customerId) ? customerId.GetString() : null
        );
    }
}