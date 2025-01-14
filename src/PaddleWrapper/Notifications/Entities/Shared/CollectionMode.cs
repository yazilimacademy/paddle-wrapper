using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Shared;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum CollectionMode
{
    [JsonPropertyName("automatic")]
    Automatic,

    [JsonPropertyName("manual")]
    Manual
}