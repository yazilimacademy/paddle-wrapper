using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Shared
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AdjustmentStatus
    {
        [EnumMember(Value = "pending_approval")]
        PendingApproval,

        [EnumMember(Value = "approved")]
        Approved,

        [EnumMember(Value = "rejected")]
        Rejected,

        [EnumMember(Value = "reversed")]
        Reversed
    }
} 