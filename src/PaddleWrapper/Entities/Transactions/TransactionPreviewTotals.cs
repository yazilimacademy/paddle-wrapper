using System.Text.Json;

namespace PaddleWrapper.Entities.Transactions
{
    public class TransactionPreviewTotals
    {
        public string Subtotal { get; }
        public string Discount { get; }
        public string Tax { get; }
        public string Total { get; }
        public string Credit { get; }
        public string Balance { get; }
        public string GrandTotal { get; }
        public string CurrencyCode { get; }

        public TransactionPreviewTotals(
            string subtotal,
            string discount,
            string tax,
            string total,
            string credit,
            string balance,
            string grandTotal,
            string currencyCode)
        {
            Subtotal = subtotal;
            Discount = discount;
            Tax = tax;
            Total = total;
            Credit = credit;
            Balance = balance;
            GrandTotal = grandTotal;
            CurrencyCode = currencyCode;
        }

        public static TransactionPreviewTotals FromDict(JsonElement data)
        {
            return new TransactionPreviewTotals(
                subtotal: data.GetProperty("subtotal").GetString(),
                discount: data.GetProperty("discount").GetString(),
                tax: data.GetProperty("tax").GetString(),
                total: data.GetProperty("total").GetString(),
                credit: data.GetProperty("credit").GetString(),
                balance: data.GetProperty("balance").GetString(),
                grandTotal: data.GetProperty("grand_total").GetString(),
                currencyCode: data.GetProperty("currency_code").GetString()
            );
        }
    }
} 