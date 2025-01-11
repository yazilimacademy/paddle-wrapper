using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Adjustments
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AdjustmentType
    {
        [EnumMember(Value = "full")]
        Full,

        [EnumMember(Value = "partial")]
        Partial
    }
}