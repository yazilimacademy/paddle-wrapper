using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Shared
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Action
    {
        [EnumMember(Value = "credit")]
        Credit,

        [EnumMember(Value = "credit_reverse")]
        CreditReverse,

        [EnumMember(Value = "refund")]
        Refund,

        [EnumMember(Value = "chargeback")]
        Chargeback,

        [EnumMember(Value = "chargeback_reverse")]
        ChargebackReverse,

        [EnumMember(Value = "chargeback_warning")]
        ChargebackWarning
    }
} 