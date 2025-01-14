using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.NotificationSettings
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum NotificationSettingType
    {
        [EnumMember(Value = "email")]
        Email,

        [EnumMember(Value = "url")]
        Url
    }
}