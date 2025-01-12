using PaddleWrapper.Notifications.Entities.Shared;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities;

public class Product : IEntity
{
    [JsonPropertyName("id")]
    public string Id { get; }

    [JsonPropertyName("name")]
    public string? Name { get; }

    [JsonPropertyName("description")]
    public string? Description { get; }

    [JsonPropertyName("type")]
    public CatalogType? Type { get; }

    [JsonPropertyName("tax_category")]
    public TaxCategory TaxCategory { get; }

    [JsonPropertyName("image_url")]
    public string? ImageUrl { get; }

    [JsonPropertyName("custom_data")]
    public CustomData? CustomData { get; }

    [JsonPropertyName("status")]
    public Status Status { get; }

    [JsonPropertyName("import_meta")]
    public ImportMeta? ImportMeta { get; }

    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; }

    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; }

    private Product(
        string id,
        string? name,
        string? description,
        CatalogType? type,
        TaxCategory taxCategory,
        string? imageUrl,
        CustomData? customData,
        Status status,
        ImportMeta? importMeta,
        DateTime? createdAt,
        DateTime? updatedAt)
    {
        Id = id;
        Name = name;
        Description = description;
        Type = type;
        TaxCategory = taxCategory;
        ImageUrl = imageUrl;
        CustomData = customData;
        Status = status;
        ImportMeta = importMeta;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public static IEntity FromJson(JsonElement json)
    {
        return new Product(
            id: json.GetProperty("id").GetString()!,
            name: json.TryGetProperty("name", out JsonElement nameElement) ? nameElement.GetString() : null,
            description: json.TryGetProperty("description", out JsonElement descElement) ? descElement.GetString() : null,
            type: json.TryGetProperty("type", out JsonElement typeElement)
                ? JsonSerializer.Deserialize<CatalogType>(typeElement.GetRawText())
                : null,
            taxCategory: JsonSerializer.Deserialize<TaxCategory>(json.GetProperty("tax_category").GetRawText())!,
            imageUrl: json.TryGetProperty("image_url", out JsonElement imageElement) ? imageElement.GetString() : null,
            customData: json.TryGetProperty("custom_data", out JsonElement customDataElement)
                ? CustomData.FromJson(customDataElement)
                : null,
            status: JsonSerializer.Deserialize<Status>(json.GetProperty("status").GetRawText())!,
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