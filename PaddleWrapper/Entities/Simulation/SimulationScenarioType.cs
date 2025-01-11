using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Simulation
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SimulationScenarioType
    {
        [EnumMember(Value = "subscription_creation")]
        SubscriptionCreation,

        [EnumMember(Value = "subscription_renewal")]
        SubscriptionRenewal,

        [EnumMember(Value = "subscription_pause")]
        SubscriptionPause,

        [EnumMember(Value = "subscription_resume")]
        SubscriptionResume,

        [EnumMember(Value = "subscription_cancellation")]
        SubscriptionCancellation
    }
} 