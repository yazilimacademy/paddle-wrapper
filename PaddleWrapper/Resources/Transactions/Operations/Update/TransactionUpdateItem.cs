using System.Text.Json.Serialization;

namespace PaddleWrapper.Resources.Transactions.Operations.Update
{
    public class TransactionUpdateItem
    {
        [JsonPropertyName("price_id")]
        public string PriceId { get; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; }

        public TransactionUpdateItem(string priceId, int quantity)
        {
            PriceId = priceId;
            Quantity = quantity;
        }
    }
}