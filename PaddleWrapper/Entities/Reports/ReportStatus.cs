using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Reports
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ReportStatus
    {
        [EnumMember(Value = "pending")]
        Pending,

        [EnumMember(Value = "ready")]
        Ready,

        [EnumMember(Value = "failed")]
        Failed,

        [EnumMember(Value = "expired")]
        Expired
    }
}