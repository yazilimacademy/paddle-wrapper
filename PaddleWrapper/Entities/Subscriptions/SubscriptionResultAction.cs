using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Subscriptions
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SubscriptionResultAction
    {
        [EnumMember(Value = "credit")]
        Credit,

        [EnumMember(Value = "charge")]
        Charge
    }
}