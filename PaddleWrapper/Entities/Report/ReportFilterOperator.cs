using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Report
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ReportFilterOperator
    {
        [EnumMember(Value = "lt")]
        Lt,

        [EnumMember(Value = "gte")]
        Gte
    }
} 