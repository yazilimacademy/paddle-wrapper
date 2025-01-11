using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Shared
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SavedPaymentMethodOrigin
    {
        [EnumMember(Value = "saved_during_purchase")]
        SavedDuringPurchase,

        [EnumMember(Value = "subscription")]
        Subscription
    }
} 