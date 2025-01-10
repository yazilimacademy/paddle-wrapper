using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace PaddleWrapper.Models.Discounts
{
    /// <summary>
    /// Represents the type of discount
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DiscountType
    {
        /// <summary>
        /// A percentage discount
        /// </summary>
        [EnumMember(Value = "percentage")]
        Percentage,

        /// <summary>
        /// A fixed amount discount
        /// </summary>
        [EnumMember(Value = "fixed_amount")]
        FixedAmount
    }
}