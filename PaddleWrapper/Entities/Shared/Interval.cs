using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Shared
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Interval
    {
        [EnumMember(Value = "day")]
        Day,

        [EnumMember(Value = "week")]
        Week,

        [EnumMember(Value = "month")]
        Month,

        [EnumMember(Value = "year")]
        Year
    }
}