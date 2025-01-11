using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Report;

public class ReportFilter
{
    [JsonPropertyName("name")]
    public ReportFilterName Name { get; set; }

    [JsonPropertyName("operator")]
    public ReportFilterOperator? Operator { get; set; }

    [JsonPropertyName("value")]
    public JsonElement Value { get; set; }

    public static ReportFilter FromJson(JsonElement data)
    {
        return new ReportFilter
        {
            Name = JsonSerializer.Deserialize<ReportFilterName>(data.GetProperty("name").GetRawText()),
            Operator = data.TryGetProperty("operator", out var op) 
                ? JsonSerializer.Deserialize<ReportFilterOperator>(op.GetRawText()) 
                : null,
            Value = data.GetProperty("value")
        };
    }
} 