using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Subscription
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SubscriptionScheduledChangeAction
    {
        [EnumMember(Value = "cancel")]
        Cancel,

        [EnumMember(Value = "pause")]
        Pause,

        [EnumMember(Value = "resume")]
        Resume
    }
} 