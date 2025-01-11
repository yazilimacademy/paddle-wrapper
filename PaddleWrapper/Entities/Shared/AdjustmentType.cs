using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Shared
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AdjustmentType
    {
        [EnumMember(Value = "full")]
        Full,

        [EnumMember(Value = "partial")]
        Partial,

        [EnumMember(Value = "tax")]
        Tax,

        [EnumMember(Value = "proration")]
        Proration
    }
} 