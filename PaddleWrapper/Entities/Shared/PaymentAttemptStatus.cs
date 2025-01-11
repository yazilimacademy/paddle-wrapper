using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Shared
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PaymentAttemptStatus
    {
        [EnumMember(Value = "authorized")]
        Authorized,

        [EnumMember(Value = "authorized_flagged")]
        AuthorizedFlagged,

        [EnumMember(Value = "canceled")]
        Canceled,

        [EnumMember(Value = "captured")]
        Captured,

        [EnumMember(Value = "error")]
        Error,

        [EnumMember(Value = "action_required")]
        ActionRequired,

        [EnumMember(Value = "pending_no_action_required")]
        PendingNoActionRequired,

        [EnumMember(Value = "created")]
        Created,

        [EnumMember(Value = "unknown")]
        Unknown,

        [EnumMember(Value = "dropped")]
        Dropped
    }
}