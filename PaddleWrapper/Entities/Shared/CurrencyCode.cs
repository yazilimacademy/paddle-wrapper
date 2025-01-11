using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Shared
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CurrencyCode
    {
        [EnumMember(Value = "USD")]
        USD,

        [EnumMember(Value = "EUR")]
        EUR,

        [EnumMember(Value = "GBP")]
        GBP,

        [EnumMember(Value = "JPY")]
        JPY,

        [EnumMember(Value = "AUD")]
        AUD,

        [EnumMember(Value = "CAD")]
        CAD,

        [EnumMember(Value = "CHF")]
        CHF,

        [EnumMember(Value = "HKD")]
        HKD,

        [EnumMember(Value = "SGD")]
        SGD,

        [EnumMember(Value = "SEK")]
        SEK,

        [EnumMember(Value = "ARS")]
        ARS,

        [EnumMember(Value = "BRL")]
        BRL,

        [EnumMember(Value = "CNY")]
        CNY,

        [EnumMember(Value = "COP")]
        COP,

        [EnumMember(Value = "CZK")]
        CZK,

        [EnumMember(Value = "DKK")]
        DKK,

        [EnumMember(Value = "HUF")]
        HUF,

        [EnumMember(Value = "ILS")]
        ILS,

        [EnumMember(Value = "INR")]
        INR,

        [EnumMember(Value = "KRW")]
        KRW,

        [EnumMember(Value = "MXN")]
        MXN,

        [EnumMember(Value = "NOK")]
        NOK,

        [EnumMember(Value = "NZD")]
        NZD,

        [EnumMember(Value = "PLN")]
        PLN,

        [EnumMember(Value = "RUB")]
        RUB,

        [EnumMember(Value = "THB")]
        THB,

        [EnumMember(Value = "TRY")]
        TRY,

        [EnumMember(Value = "TWD")]
        TWD,

        [EnumMember(Value = "UAH")]
        UAH,

        [EnumMember(Value = "VND")]
        VND,

        [EnumMember(Value = "ZAR")]
        ZAR
    }
} 