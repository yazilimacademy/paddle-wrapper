using System.Text.Json.Serialization;

namespace PaddleWrapper.Resources.Reports.Operations
{
    public class CreateReport
    {
        [JsonPropertyName("type")]
        public ReportType Type { get; }

        [JsonPropertyName("filters")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<ReportFilter> Filters { get; }

        public CreateReport(
            ReportType type,
            IEnumerable<ReportFilter>? filters = null)
        {
            Type = type;
            List<ReportFilter> filtersList = filters?.ToList() ?? new List<ReportFilter>();

            if (filtersList.Any(filter => filter == null))
            {
                throw new ArgumentException("filters cannot contain null values", nameof(filters));
            }

            Filters = filtersList;
        }
    }
}