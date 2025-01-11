using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Transaction
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TransactionCardType
    {
        [EnumMember(Value = "american_express")]
        AmericanExpress,

        [EnumMember(Value = "diners_club")]
        DinersClub,

        [EnumMember(Value = "discover")]
        Discover,

        [EnumMember(Value = "jcb")]
        Jcb,

        [EnumMember(Value = "mada")]
        Mada,

        [EnumMember(Value = "maestro")]
        Maestro,

        [EnumMember(Value = "mastercard")]
        Mastercard,

        [EnumMember(Value = "union_pay")]
        UnionPay,

        [EnumMember(Value = "unknown")]
        Unknown,

        [EnumMember(Value = "visa")]
        Visa
    }
}