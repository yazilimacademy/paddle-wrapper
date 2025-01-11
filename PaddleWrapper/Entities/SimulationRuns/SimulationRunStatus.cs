using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.SimulationRuns
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SimulationRunStatus
    {
        [EnumMember(Value = "canceled")]
        Canceled,

        [EnumMember(Value = "completed")]
        Completed,

        [EnumMember(Value = "pending")]
        Pending
    }
}