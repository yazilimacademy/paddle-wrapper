using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.SimulationRunEvents
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SimulationRunEventStatus
    {
        [EnumMember(Value = "aborted")]
        Aborted,

        [EnumMember(Value = "failed")]
        Failed,

        [EnumMember(Value = "success")]
        Success,

        [EnumMember(Value = "pending")]
        Pending
    }
}