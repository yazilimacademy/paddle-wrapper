using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.NotificationSetting
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum NotificationSettingTrafficSource
    {
        [EnumMember(Value = "all")]
        All,

        [EnumMember(Value = "platform")]
        Platform,

        [EnumMember(Value = "simulation")]
        Simulation
    }
} 