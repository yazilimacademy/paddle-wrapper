using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Notification
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum NotificationStatus
    {
        [EnumMember(Value = "not_attempted")]
        NotAttempted,

        [EnumMember(Value = "needs_retry")]
        NeedsRetry,

        [EnumMember(Value = "delivered")]
        Delivered,

        [EnumMember(Value = "failed")]
        Failed
    }
}