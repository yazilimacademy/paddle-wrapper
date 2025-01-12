using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Reports;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ReportFilterName
{
    [JsonPropertyName("action")]
    Action,

    [JsonPropertyName("collection_mode")]
    CollectionMode,

    [JsonPropertyName("currency_code")]
    CurrencyCode,

    [JsonPropertyName("origin")]
    Origin,

    [JsonPropertyName("price_status")]
    PriceStatus,

    [JsonPropertyName("price_type")]
    PriceType,

    [JsonPropertyName("price_updated_at")]
    PriceUpdatedAt,

    [JsonPropertyName("product_status")]
    ProductStatus,

    [JsonPropertyName("product_type")]
    ProductType,

    [JsonPropertyName("product_updated_at")]
    ProductUpdatedAt,

    [JsonPropertyName("status")]
    Status,

    [JsonPropertyName("type")]
    Type,

    [JsonPropertyName("updated_at")]
    UpdatedAt
}