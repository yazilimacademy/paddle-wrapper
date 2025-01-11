using System.Runtime.Serialization;

namespace PaddleWrapper.Notifications.Entities.Adjustment;

public enum AdjustmentType
{
    [EnumMember(Value = "full")]
    Full,

    [EnumMember(Value = "partial")]
    Partial
} 