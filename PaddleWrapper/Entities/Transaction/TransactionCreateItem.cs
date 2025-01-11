using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Transaction
{
    public class TransactionCreateItem
    {
        [JsonPropertyName("price_id")]
        public string PriceId { get; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; }

        private TransactionCreateItem(string priceId, int quantity)
        {
            PriceId = priceId;
            Quantity = quantity;
        }

        public static TransactionCreateItem From(Dictionary<string, object> data)
        {
            return new TransactionCreateItem(
                priceId: (string)data["price_id"],
                quantity: (int)data["quantity"]
            );
        }
    }
}