using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Subscription
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SubscriptionResumeEffectiveFrom
    {
        [EnumMember(Value = "immediately")]
        Immediately
    }
} 