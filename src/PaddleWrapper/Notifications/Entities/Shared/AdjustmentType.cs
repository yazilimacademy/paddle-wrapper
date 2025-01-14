using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Shared;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AdjustmentType
{
    [JsonPropertyName("full")]
    Full,

    [JsonPropertyName("partial")]
    Partial,

    [JsonPropertyName("tax")]
    Tax,

    [JsonPropertyName("proration")]
    Proration
}