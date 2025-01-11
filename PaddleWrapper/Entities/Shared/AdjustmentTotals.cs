using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Shared
{
    public class AdjustmentTotals
    {
        [JsonPropertyName("subtotal")]
        public string Subtotal { get; }

        [JsonPropertyName("tax")]
        public string Tax { get; }

        [JsonPropertyName("total")]
        public string Total { get; }

        [JsonPropertyName("fee")]
        public string Fee { get; }

        [JsonPropertyName("earnings")]
        public string Earnings { get; }

        [JsonPropertyName("currency_code")]
        public CurrencyCode CurrencyCode { get; }

        [JsonConstructor]
        public AdjustmentTotals(
            string subtotal,
            string tax,
            string total,
            string fee,
            string earnings,
            CurrencyCode currencyCode)
        {
            Subtotal = subtotal;
            Tax = tax;
            Total = total;
            Fee = fee;
            Earnings = earnings;
            CurrencyCode = currencyCode;
        }

        public static AdjustmentTotals From(Dictionary<string, object> data)
        {
            return new AdjustmentTotals(
                subtotal: data["subtotal"].ToString(),
                tax: data["tax"].ToString(),
                total: data["total"].ToString(),
                fee: data["fee"].ToString(),
                earnings: data["earnings"].ToString(),
                currencyCode: Enum.Parse<CurrencyCode>(data["currency_code"].ToString(), true)
            );
        }
    }
} 