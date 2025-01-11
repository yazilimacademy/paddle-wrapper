using System.Text.Json.Serialization;

namespace PaddleWrapper.Resources.Transactions.Operations.Create;

public class TransactionCreateItem
{
    [JsonPropertyName("price_id")]
    public string PriceId { get; }

    [JsonPropertyName("quantity")]
    public int Quantity { get; }

    public TransactionCreateItem(string priceId, int quantity)
    {
        PriceId = priceId;
        Quantity = quantity;
    }
} 