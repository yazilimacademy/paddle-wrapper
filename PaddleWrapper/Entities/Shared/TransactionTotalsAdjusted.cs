using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Shared
{
    public class TransactionTotalsAdjusted
    {
        [JsonPropertyName("subtotal")]
        public string Subtotal { get; }

        [JsonPropertyName("tax")]
        public string Tax { get; }

        [JsonPropertyName("total")]
        public string Total { get; }

        [JsonPropertyName("grand_total")]
        public string GrandTotal { get; }

        [JsonPropertyName("fee")]
        public string? Fee { get; }

        [JsonPropertyName("earnings")]
        public string? Earnings { get; }

        [JsonPropertyName("currency_code")]
        public CurrencyCode CurrencyCode { get; }

        [JsonConstructor]
        public TransactionTotalsAdjusted(
            string subtotal,
            string tax,
            string total,
            string grandTotal,
            string? fee,
            string? earnings,
            CurrencyCode currencyCode)
        {
            Subtotal = subtotal;
            Tax = tax;
            Total = total;
            GrandTotal = grandTotal;
            Fee = fee;
            Earnings = earnings;
            CurrencyCode = currencyCode;
        }

        public static TransactionTotalsAdjusted From(Dictionary<string, object> data)
        {
            return new TransactionTotalsAdjusted(
                subtotal: data["subtotal"].ToString(),
                tax: data["tax"].ToString(),
                total: data["total"].ToString(),
                grandTotal: data["grand_total"].ToString(),
                fee: data.ContainsKey("fee") ? data["fee"]?.ToString() : null,
                earnings: data.ContainsKey("earnings") ? data["earnings"]?.ToString() : null,
                currencyCode: Enum.Parse<CurrencyCode>(data["currency_code"].ToString(), true)
            );
        }
    }
} 