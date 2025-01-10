using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace PaddleWrapper.Models.Notifications
{
    /// <summary>
    /// Represents the status of a notification
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum NotificationStatus
    {
        /// <summary>
        /// The notification has not been read
        /// </summary>
        [EnumMember(Value = "unread")]
        Unread,

        /// <summary>
        /// The notification has been read
        /// </summary>
        [EnumMember(Value = "read")]
        Read
    }
}