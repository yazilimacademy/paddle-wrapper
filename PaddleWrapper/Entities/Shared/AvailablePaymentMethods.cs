using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Shared
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AvailablePaymentMethods
    {
        [EnumMember(Value = "alipay")]
        Alipay,

        [EnumMember(Value = "apple_pay")]
        ApplePay,

        [EnumMember(Value = "bancontact")]
        Bancontact,

        [EnumMember(Value = "card")]
        Card,

        [EnumMember(Value = "google_pay")]
        GooglePay,

        [EnumMember(Value = "ideal")]
        Ideal,

        [EnumMember(Value = "offline")]
        Offline,

        [EnumMember(Value = "paypal")]
        Paypal,

        [EnumMember(Value = "unknown")]
        Unknown,

        [EnumMember(Value = "wire_transfer")]
        WireTransfer
    }
} 