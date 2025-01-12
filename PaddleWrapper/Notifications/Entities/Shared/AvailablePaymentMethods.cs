using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Shared;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AvailablePaymentMethods
{
    [JsonPropertyName("alipay")]
    Alipay,

    [JsonPropertyName("apple_pay")]
    ApplePay,

    [JsonPropertyName("bancontact")]
    Bancontact,

    [JsonPropertyName("card")]
    Card,

    [JsonPropertyName("google_pay")]
    GooglePay,

    [JsonPropertyName("ideal")]
    Ideal,

    [JsonPropertyName("offline")]
    Offline,

    [JsonPropertyName("paypal")]
    Paypal,

    [JsonPropertyName("unknown")]
    Unknown,

    [JsonPropertyName("wire_transfer")]
    WireTransfer
}