using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Shared
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CurrencyCodePayouts
    {
        [EnumMember(Value = "AUD")]
        AUD,

        [EnumMember(Value = "CAD")]
        CAD,

        [EnumMember(Value = "CHF")]
        CHF,

        [EnumMember(Value = "CNY")]
        CNY,

        [EnumMember(Value = "CZK")]
        CZK,

        [EnumMember(Value = "DKK")]
        DKK,

        [EnumMember(Value = "EUR")]
        EUR,

        [EnumMember(Value = "GBP")]
        GBP,

        [EnumMember(Value = "HUF")]
        HUF,

        [EnumMember(Value = "PLN")]
        PLN,

        [EnumMember(Value = "SEK")]
        SEK,

        [EnumMember(Value = "USD")]
        USD,

        [EnumMember(Value = "ZAR")]
        ZAR
    }
} 