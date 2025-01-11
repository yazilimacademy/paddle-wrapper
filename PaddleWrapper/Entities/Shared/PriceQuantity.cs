using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Shared
{
    public class PriceQuantity
    {
        [JsonPropertyName("minimum")]
        public int Minimum { get; }

        [JsonPropertyName("maximum")]
        public int Maximum { get; }

        [JsonConstructor]
        public PriceQuantity(int minimum, int maximum)
        {
            Minimum = minimum;
            Maximum = maximum;
        }

        public static PriceQuantity From(Dictionary<string, object> data)
        {
            return new PriceQuantity(
                minimum: Convert.ToInt32(data["minimum"]),
                maximum: Convert.ToInt32(data["maximum"])
            );
        }
    }
} 