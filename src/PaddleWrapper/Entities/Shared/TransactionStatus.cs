using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Shared
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TransactionStatus
    {
        [EnumMember(Value = "draft")]
        Draft,

        [EnumMember(Value = "ready")]
        Ready,

        [EnumMember(Value = "billed")]
        Billed,

        [EnumMember(Value = "paid")]
        Paid,

        [EnumMember(Value = "completed")]
        Completed,

        [EnumMember(Value = "canceled")]
        Canceled,

        [EnumMember(Value = "past_due")]
        PastDue
    }
}