using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Reports;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ReportFilterOperator
{
    [JsonPropertyName("lt")]
    Lt,

    [JsonPropertyName("gte")]
    Gte
} 