using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Reports;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ReportType
{
    [JsonPropertyName("adjustments")]
    Adjustments,

    [JsonPropertyName("adjustment_line_items")]
    AdjustmentLineItems,

    [JsonPropertyName("discounts")]
    Discounts,

    [JsonPropertyName("products_prices")]
    ProductsPrices,

    [JsonPropertyName("transactions")]
    Transactions,

    [JsonPropertyName("transaction_line_items")]
    TransactionLineItems
} 