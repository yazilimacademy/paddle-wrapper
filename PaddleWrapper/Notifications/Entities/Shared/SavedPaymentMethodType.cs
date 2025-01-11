using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Shared;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SavedPaymentMethodType
{
    [JsonPropertyName("alipay")]
    Alipay,
    [JsonPropertyName("apple_pay")]
    ApplePay,
    [JsonPropertyName("card")]
    Card,
    [JsonPropertyName("google_pay")]
    GooglePay,
    [JsonPropertyName("paypal")]
    Paypal
} 