using System.Text.Json;

namespace PaddleWrapper.Entities.Transactions
{
    public class TransactionItemTotals
    {
        public string Subtotal { get; }
        public string Tax { get; }
        public string Total { get; }
        public string Discount { get; }

        public TransactionItemTotals(
            string subtotal,
            string tax,
            string total,
            string discount)
        {
            Subtotal = subtotal;
            Tax = tax;
            Total = total;
            Discount = discount;
        }

        public static TransactionItemTotals FromDict(JsonElement data)
        {
            return new TransactionItemTotals(
                subtotal: data.GetProperty("subtotal").GetString(),
                tax: data.GetProperty("tax").GetString(),
                total: data.GetProperty("total").GetString(),
                discount: data.GetProperty("discount").GetString()
            );
        }
    }
} 