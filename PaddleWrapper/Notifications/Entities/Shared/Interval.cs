using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Shared;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Interval
{
    [JsonPropertyName("day")]
    Day,
    [JsonPropertyName("week")]
    Week,
    [JsonPropertyName("month")]
    Month,
    [JsonPropertyName("year")]
    Year
} 