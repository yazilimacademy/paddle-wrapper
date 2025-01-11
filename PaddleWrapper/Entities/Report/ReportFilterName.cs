using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Report
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ReportFilterName
    {
        [EnumMember(Value = "action")]
        Action,

        [EnumMember(Value = "collection_mode")]
        CollectionMode,

        [EnumMember(Value = "currency_code")]
        CurrencyCode,

        [EnumMember(Value = "origin")]
        Origin,

        [EnumMember(Value = "price_status")]
        PriceStatus,

        [EnumMember(Value = "price_type")]
        PriceType,

        [EnumMember(Value = "price_updated_at")]
        PriceUpdatedAt,

        [EnumMember(Value = "product_status")]
        ProductStatus,

        [EnumMember(Value = "product_type")]
        ProductType,

        [EnumMember(Value = "product_updated_at")]
        ProductUpdatedAt,

        [EnumMember(Value = "status")]
        Status,

        [EnumMember(Value = "type")]
        Type,

        [EnumMember(Value = "updated_at")]
        UpdatedAt
    }
} 