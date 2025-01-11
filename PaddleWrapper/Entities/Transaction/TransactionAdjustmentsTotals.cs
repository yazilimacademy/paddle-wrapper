using PaddleWrapper.Entities.Shared;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Transaction
{
    public class TransactionAdjustmentsTotals
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

        [JsonPropertyName("breakdown")]
        public TransactionBreakdown Breakdown { get; }

        [JsonPropertyName("currency_code")]
        public CurrencyCode CurrencyCode { get; }

        private TransactionAdjustmentsTotals(
            string subtotal,
            string tax,
            string total,
            string fee,
            string earnings,
            TransactionBreakdown breakdown,
            CurrencyCode currencyCode)
        {
            Subtotal = subtotal;
            Tax = tax;
            Total = total;
            Fee = fee;
            Earnings = earnings;
            Breakdown = breakdown;
            CurrencyCode = currencyCode;
        }

        public static TransactionAdjustmentsTotals From(Dictionary<string, object> data)
        {
            return new TransactionAdjustmentsTotals(
                subtotal: (string)data["subtotal"],
                tax: (string)data["tax"],
                total: (string)data["total"],
                fee: (string)data["fee"],
                earnings: (string)data["earnings"],
                breakdown: TransactionBreakdown.From((Dictionary<string, object>)data["breakdown"]),
                currencyCode: System.Enum.Parse<CurrencyCode>((string)data["currency_code"], true)
            );
        }
    }
}