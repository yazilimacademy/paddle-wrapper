using System.Text.Json.Serialization;
using PaddleWrapper.Entities.Shared;

namespace PaddleWrapper.Entities.Transaction
{
    public class TransactionUpdateTransactionItem
    {
        [JsonPropertyName("price_id")]
        public string PriceId { get; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; }

        private TransactionUpdateTransactionItem(
            string priceId,
            int quantity)
        {
            PriceId = priceId;
            Quantity = quantity;
        }

        public static TransactionUpdateTransactionItem From(Dictionary<string, object> data)
        {
            return new TransactionUpdateTransactionItem(
                priceId: (string)data["price_id"],
                quantity: (int)data["quantity"]
            );
        }
    }
} 