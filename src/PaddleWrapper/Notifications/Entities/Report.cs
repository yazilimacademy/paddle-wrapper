using PaddleWrapper.Notifications.Entities.Reports;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities;

public class Report : IEntity
{
    [JsonPropertyName("id")]
    public string Id { get; }

    [JsonPropertyName("status")]
    public ReportStatus Status { get; }

    [JsonPropertyName("rows")]
    public int? Rows { get; }

    [JsonPropertyName("type")]
    public ReportType Type { get; }

    [JsonPropertyName("filters")]
    public IReadOnlyList<ReportFilter> Filters { get; }

    [JsonPropertyName("expires_at")]
    public DateTime? ExpiresAt { get; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; }

    private Report(
        string id,
        ReportStatus status,
        int? rows,
        ReportType type,
        IReadOnlyList<ReportFilter> filters,
        DateTime? expiresAt,
        DateTime createdAt,
        DateTime updatedAt)
    {
        Id = id;
        Status = status;
        Rows = rows;
        Type = type;
        Filters = filters;
        ExpiresAt = expiresAt;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public static IEntity FromJson(JsonElement json)
    {
        List<ReportFilter> filters = new();
        if (json.TryGetProperty("filters", out JsonElement filtersElement))
        {
            foreach (JsonElement filter in filtersElement.EnumerateArray())
            {
                filters.Add(ReportFilter.FromJson(filter));
            }
        }

        return new Report(
            id: json.GetProperty("id").GetString()!,
            status: JsonSerializer.Deserialize<ReportStatus>(json.GetProperty("status").GetRawText())!,
            rows: json.TryGetProperty("rows", out JsonElement rowsElement) ? rowsElement.GetInt32() : null,
            type: JsonSerializer.Deserialize<ReportType>(json.GetProperty("type").GetRawText())!,
            filters: filters,
            expiresAt: json.TryGetProperty("expires_at", out JsonElement expiresAtElement)
                ? DateTime.Parse(expiresAtElement.GetString()!)
                : null,
            createdAt: DateTime.Parse(json.GetProperty("created_at").GetString()!),
            updatedAt: DateTime.Parse(json.GetProperty("updated_at").GetString()!)
        );
    }
}