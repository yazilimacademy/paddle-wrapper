using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Shared
{
    public class TransactionPayoutTotals
    {
        [JsonPropertyName("subtotal")]
        public string Subtotal { get; }

        [JsonPropertyName("discount")]
        public string Discount { get; }

        [JsonPropertyName("tax")]
        public string Tax { get; }

        [JsonPropertyName("total")]
        public string Total { get; }

        [JsonPropertyName("credit")]
        public string Credit { get; }

        [JsonPropertyName("balance")]
        public string Balance { get; }

        [JsonPropertyName("grand_total")]
        public string GrandTotal { get; }

        [JsonPropertyName("fee")]
        public string Fee { get; }

        [JsonPropertyName("earnings")]
        public string Earnings { get; }

        [JsonPropertyName("currency_code")]
        public CurrencyCodePayouts CurrencyCode { get; }

        [JsonPropertyName("credit_to_balance")]
        public string CreditToBalance { get; }

        [JsonConstructor]
        public TransactionPayoutTotals(
            string subtotal,
            string discount,
            string tax,
            string total,
            string credit,
            string balance,
            string grandTotal,
            string fee,
            string earnings,
            CurrencyCodePayouts currencyCode,
            string creditToBalance)
        {
            Subtotal = subtotal;
            Discount = discount;
            Tax = tax;
            Total = total;
            Credit = credit;
            Balance = balance;
            GrandTotal = grandTotal;
            Fee = fee;
            Earnings = earnings;
            CurrencyCode = currencyCode;
            CreditToBalance = creditToBalance;
        }

        public static TransactionPayoutTotals From(Dictionary<string, object> data)
        {
            return new TransactionPayoutTotals(
                subtotal: data["subtotal"].ToString(),
                discount: data["discount"].ToString(),
                tax: data["tax"].ToString(),
                total: data["total"].ToString(),
                credit: data["credit"].ToString(),
                balance: data["balance"].ToString(),
                grandTotal: data["grand_total"].ToString(),
                fee: data["fee"].ToString(),
                earnings: data["earnings"].ToString(),
                currencyCode: Enum.Parse<CurrencyCodePayouts>(data["currency_code"].ToString(), true),
                creditToBalance: data["credit_to_balance"].ToString()
            );
        }
    }
}