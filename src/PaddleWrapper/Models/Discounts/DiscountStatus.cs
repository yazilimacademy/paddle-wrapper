using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace PaddleWrapper.Models.Discounts
{
    /// <summary>
    /// Represents the status of a discount
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DiscountStatus
    {
        /// <summary>
        /// The discount is active and can be used
        /// </summary>
        [EnumMember(Value = "active")]
        Active,

        /// <summary>
        /// The discount has expired
        /// </summary>
        [EnumMember(Value = "expired")]
        Expired,

        /// <summary>
        /// The discount has been used up to its limit
        /// </summary>
        [EnumMember(Value = "depleted")]
        Depleted,

        /// <summary>
        /// The discount has been archived
        /// </summary>
        [EnumMember(Value = "archived")]
        Archived
    }
}