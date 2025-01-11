using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Shared
{
    public class PayoutTotalsAdjustment
    {
        [JsonPropertyName("subtotal")]
        public string Subtotal { get; }

        [JsonPropertyName("tax")]
        public string Tax { get; }

        [JsonPropertyName("total")]
        public string Total { get; }

        [JsonPropertyName("fee")]
        public string Fee { get; }

        [JsonPropertyName("chargeback_fee")]
        public ChargebackFee? ChargebackFee { get; }

        [JsonPropertyName("earnings")]
        public string Earnings { get; }

        [JsonPropertyName("currency_code")]
        public CurrencyCodePayouts CurrencyCode { get; }

        [JsonConstructor]
        public PayoutTotalsAdjustment(
            string subtotal,
            string tax,
            string total,
            string fee,
            ChargebackFee? chargebackFee,
            string earnings,
            CurrencyCodePayouts currencyCode)
        {
            Subtotal = subtotal;
            Tax = tax;
            Total = total;
            Fee = fee;
            ChargebackFee = chargebackFee;
            Earnings = earnings;
            CurrencyCode = currencyCode;
        }

        public static PayoutTotalsAdjustment From(Dictionary<string, object> data)
        {
            return new PayoutTotalsAdjustment(
                subtotal: data["subtotal"].ToString(),
                tax: data["tax"].ToString(),
                total: data["total"].ToString(),
                fee: data["fee"].ToString(),
                chargebackFee: data.ContainsKey("chargeback_fee") && data["chargeback_fee"] != null
                    ? ChargebackFee.From((Dictionary<string, object>)data["chargeback_fee"])
                    : null,
                earnings: data["earnings"].ToString(),
                currencyCode: Enum.Parse<CurrencyCodePayouts>(data["currency_code"].ToString(), true)
            );
        }
    }
}