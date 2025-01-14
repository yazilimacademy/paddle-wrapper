using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Reports
{
    public class ReportFilter
    {
        [JsonPropertyName("name")]
        public ReportFilterName Name { get; }

        [JsonPropertyName("operator")]
        public ReportFilterOperator? Operator { get; }

        [JsonPropertyName("value")]
        public object Value { get; }

        private ReportFilter(
            ReportFilterName name,
            ReportFilterOperator? @operator,
            object value)
        {
            Name = name;
            Operator = @operator;
            Value = value;
        }

        public static ReportFilter From(Dictionary<string, object> data)
        {
            return new ReportFilter(
                name: Enum.Parse<ReportFilterName>((string)data["name"], true),
                @operator: data.ContainsKey("operator") ? Enum.Parse<ReportFilterOperator>((string)data["operator"], true) : null,
                value: data["value"]
            );
        }
    }
}