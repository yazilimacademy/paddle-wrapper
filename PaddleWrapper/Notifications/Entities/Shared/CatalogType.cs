using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Shared;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum CatalogType
{
    [JsonPropertyName("standard")]
    Standard,

    [JsonPropertyName("custom")]
    Custom
}