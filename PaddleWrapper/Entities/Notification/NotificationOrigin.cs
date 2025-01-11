using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Notification
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum NotificationOrigin
    {
        [EnumMember(Value = "event")]
        Event,

        [EnumMember(Value = "replay")]
        Replay
    }
} 