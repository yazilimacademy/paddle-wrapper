using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Shared
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ErrorCode
    {
        [EnumMember(Value = "already_canceled")]
        AlreadyCanceled,

        [EnumMember(Value = "already_refunded")]
        AlreadyRefunded,

        [EnumMember(Value = "authentication_failed")]
        AuthenticationFailed,

        [EnumMember(Value = "blocked_card")]
        BlockedCard,

        [EnumMember(Value = "canceled")]
        Canceled,

        [EnumMember(Value = "declined")]
        Declined,

        [EnumMember(Value = "declined_not_retryable")]
        DeclinedNotRetryable,

        [EnumMember(Value = "expired_card")]
        ExpiredCard,

        [EnumMember(Value = "fraud")]
        Fraud,

        [EnumMember(Value = "invalid_amount")]
        InvalidAmount,

        [EnumMember(Value = "invalid_payment_details")]
        InvalidPaymentDetails,

        [EnumMember(Value = "issuer_unavailable")]
        IssuerUnavailable,

        [EnumMember(Value = "not_enough_balance")]
        NotEnoughBalance,

        [EnumMember(Value = "psp_error")]
        PspError,

        [EnumMember(Value = "redacted_payment_method")]
        RedactedPaymentMethod,

        [EnumMember(Value = "system_error")]
        SystemError,

        [EnumMember(Value = "transaction_not_permitted")]
        TransactionNotPermitted,

        [EnumMember(Value = "unknown")]
        Unknown
    }
}