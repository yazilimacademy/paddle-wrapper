using System.Text.Json;

namespace PaddleWrapper.Entities.Transactions
{
    public class TransactionTotals
    {
        public string Subtotal { get; }
        public string Discount { get; }
        public string Tax { get; }
        public string Total { get; }
        public string Credit { get; }
        public string Balance { get; }
        public string GrandTotal { get; }
        public string Fee { get; }
        public string Earnings { get; }
        public string CurrencyCode { get; }

        public TransactionTotals(
            string subtotal,
            string discount,
            string tax,
            string total,
            string credit,
            string balance,
            string grandTotal,
            string fee,
            string earnings,
            string currencyCode)
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
        }

        public static TransactionTotals FromDict(JsonElement data)
        {
            return new TransactionTotals(
                subtotal: data.GetProperty("subtotal").GetString(),
                discount: data.GetProperty("discount").GetString(),
                tax: data.GetProperty("tax").GetString(),
                total: data.GetProperty("total").GetString(),
                credit: data.GetProperty("credit").GetString(),
                balance: data.GetProperty("balance").GetString(),
                grandTotal: data.GetProperty("grand_total").GetString(),
                fee: data.GetProperty("fee").GetString(),
                earnings: data.GetProperty("earnings").GetString(),
                currencyCode: data.GetProperty("currency_code").GetString()
            );
        }
    }
} 