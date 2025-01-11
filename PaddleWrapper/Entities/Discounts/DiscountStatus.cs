using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Discounts
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DiscountStatus
    {
        [EnumMember(Value = "active")]
        Active,

        [EnumMember(Value = "archived")]
        Archived,

        [EnumMember(Value = "expired")]
        Expired,

        [EnumMember(Value = "used")]
        Used
    }
}