using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Shared;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Status
{
    [JsonPropertyName("active")]
    Active,
    [JsonPropertyName("archived")]
    Archived
}