using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Shared;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Action
{
    [JsonPropertyName("credit")]
    Credit,

    [JsonPropertyName("credit_reverse")]
    CreditReverse,

    [JsonPropertyName("refund")]
    Refund,

    [JsonPropertyName("chargeback")]
    Chargeback,

    [JsonPropertyName("chargeback_reverse")]
    ChargebackReverse,

    [JsonPropertyName("chargeback_warning")]
    ChargebackWarning
} 