using System.Runtime.Serialization;

namespace PaddleWrapper.Notifications.Entities.Adjustments;

public enum AdjustmentType
{
    [EnumMember(Value = "full")]
    Full,

    [EnumMember(Value = "partial")]
    Partial
}