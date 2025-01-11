using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Simulation
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SimulationStatus
    {
        [EnumMember(Value = "active")]
        Active,

        [EnumMember(Value = "archived")]
        Archived
    }
} 