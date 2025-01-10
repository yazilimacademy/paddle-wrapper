using System.Text.Json;

namespace PaddleWrapper.Entities.Transactions
{
    public class TransactionPreviewItemTotals
    {
        public string Subtotal { get; }
        public string Tax { get; }
        public string Total { get; }
        public string Discount { get; }

        public TransactionPreviewItemTotals(
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

        public static TransactionPreviewItemTotals FromDict(JsonElement data)
        {
            return new TransactionPreviewItemTotals(
                subtotal: data.GetProperty("subtotal").GetString(),
                tax: data.GetProperty("tax").GetString(),
                total: data.GetProperty("total").GetString(),
                discount: data.GetProperty("discount").GetString()
            );
        }
    }
} 