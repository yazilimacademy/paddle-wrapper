using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Shared
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CatalogType
    {
        [EnumMember(Value = "standard")]
        Standard,

        [EnumMember(Value = "custom")]
        Custom
    }
} 