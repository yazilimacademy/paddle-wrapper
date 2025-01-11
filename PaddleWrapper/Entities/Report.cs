using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities
{
    public class Report
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

        public static Report From(Dictionary<string, object> data)
        {
            List<ReportFilter> filters = new();
            if (data.ContainsKey("filters"))
            {
                object[] filtersData = (object[])data["filters"];
                foreach (object filter in filtersData)
                {
                    filters.Add(ReportFilter.From((Dictionary<string, object>)filter));
                }
            }

            return new Report(
                id: (string)data["id"],
                status: System.Enum.Parse<ReportStatus>((string)data["status"], true),
                rows: data.ContainsKey("rows") ? (int?)data["rows"] : null,
                type: System.Enum.Parse<ReportType>((string)data["type"], true),
                filters: filters,
                expiresAt: data.ContainsKey("expires_at") ?
                    DateTime.Parse((string)data["expires_at"]) : null,
                createdAt: DateTime.Parse((string)data["created_at"]),
                updatedAt: DateTime.Parse((string)data["updated_at"])
            );
        }
    }
}