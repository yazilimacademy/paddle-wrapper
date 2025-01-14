using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Shared
{
    public class MethodDetails
    {
        [JsonPropertyName("type")]
        public PaymentMethodType Type { get; }

        [JsonPropertyName("card")]
        public Card? Card { get; }

        [JsonConstructor]
        public MethodDetails(PaymentMethodType type, Card? card = null)
        {
            Type = type;
            Card = card;
        }

        public static MethodDetails From(Dictionary<string, object> data)
        {
            return new MethodDetails(
                type: Enum.Parse<PaymentMethodType>(data["type"].ToString(), true),
                card: data.ContainsKey("card") && data["card"] != null
                    ? Card.From((Dictionary<string, object>)data["card"])
                    : null
            );
        }
    }
}