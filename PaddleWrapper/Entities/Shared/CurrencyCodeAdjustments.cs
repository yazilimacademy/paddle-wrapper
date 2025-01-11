using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Shared
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CurrencyCodeAdjustments
    {
        [EnumMember(Value = "EUR")]
        EUR,

        [EnumMember(Value = "GBP")]
        GBP,

        [EnumMember(Value = "USD")]
        USD
    }
}