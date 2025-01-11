using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Report;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ReportFilterOperator
{
    [JsonPropertyName("lt")]
    Lt,

    [JsonPropertyName("gte")]
    Gte
} 