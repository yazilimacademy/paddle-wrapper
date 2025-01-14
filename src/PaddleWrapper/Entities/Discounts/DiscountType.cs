using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Discounts
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DiscountType
    {
        [EnumMember(Value = "flat")]
        Flat,

        [EnumMember(Value = "flat_per_seat")]
        FlatPerSeat,

        [EnumMember(Value = "percentage")]
        Percentage
    }
}