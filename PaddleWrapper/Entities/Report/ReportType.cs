using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Report
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ReportType
    {
        [EnumMember(Value = "adjustments")]
        Adjustments,

        [EnumMember(Value = "adjustment_line_items")]
        AdjustmentLineItems,

        [EnumMember(Value = "discounts")]
        Discounts,

        [EnumMember(Value = "products_prices")]
        ProductsPrices,

        [EnumMember(Value = "transactions")]
        Transactions,

        [EnumMember(Value = "transaction_line_items")]
        TransactionLineItems
    }
}