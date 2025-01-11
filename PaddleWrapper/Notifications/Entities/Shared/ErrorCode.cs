using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Shared;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ErrorCode
{
    [JsonPropertyName("already_canceled")]
    AlreadyCanceled,
    [JsonPropertyName("already_refunded")]
    AlreadyRefunded,
    [JsonPropertyName("authentication_failed")]
    AuthenticationFailed,
    [JsonPropertyName("blocked_card")]
    BlockedCard,
    [JsonPropertyName("canceled")]
    Canceled,
    [JsonPropertyName("declined")]
    Declined,
    [JsonPropertyName("expired_card")]
    ExpiredCard,
    [JsonPropertyName("fraud")]
    Fraud,
    [JsonPropertyName("invalid_amount")]
    InvalidAmount,
    [JsonPropertyName("invalid_payment_details")]
    InvalidPaymentDetails,
    [JsonPropertyName("issuer_unavailable")]
    IssuerUnavailable,
    [JsonPropertyName("not_enough_balance")]
    NotEnoughBalance,
    [JsonPropertyName("psp_error")]
    PspError,
    [JsonPropertyName("redacted_payment_method")]
    RedactedPaymentMethod,
    [JsonPropertyName("system_error")]
    SystemError,
    [JsonPropertyName("transaction_not_permitted")]
    TransactionNotPermitted,
    [JsonPropertyName("unknown")]
    Unknown
} 