using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Notification
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum NotificationPayoutStatus
    {
        [EnumMember(Value = "unpaid")]
        Unpaid,

        [EnumMember(Value = "paid")]
        Paid
    }
}