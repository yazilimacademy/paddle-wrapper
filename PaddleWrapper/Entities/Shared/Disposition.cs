using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Shared
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Disposition
    {
        [EnumMember(Value = "attachment")]
        Attachment,

        [EnumMember(Value = "inline")]
        Inline
    }
} 