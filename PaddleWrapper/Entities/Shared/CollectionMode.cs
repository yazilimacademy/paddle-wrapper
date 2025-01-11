using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Shared
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CollectionMode
    {
        [EnumMember(Value = "automatic")]
        Automatic,

        [EnumMember(Value = "manual")]
        Manual
    }
}