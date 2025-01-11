using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Simulations
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SimulationKind
    {
        [EnumMember(Value = "scenario")]
        Scenario,

        [EnumMember(Value = "single_event")]
        SingleEvent
    }
}