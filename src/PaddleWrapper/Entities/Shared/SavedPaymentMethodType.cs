using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Shared
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SavedPaymentMethodType
    {
        [EnumMember(Value = "alipay")]
        Alipay,

        [EnumMember(Value = "apple_pay")]
        ApplePay,

        [EnumMember(Value = "card")]
        Card,

        [EnumMember(Value = "google_pay")]
        GooglePay,

        [EnumMember(Value = "paypal")]
        Paypal
    }
}