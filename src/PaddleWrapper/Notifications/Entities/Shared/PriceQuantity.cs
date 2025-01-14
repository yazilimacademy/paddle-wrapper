using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Shared;

public class PriceQuantity
{
    [JsonPropertyName("minimum")]
    public int Minimum { get; }

    [JsonPropertyName("maximum")]
    public int Maximum { get; }

    private PriceQuantity(int minimum, int maximum)
    {
        Minimum = minimum;
        Maximum = maximum;
    }

    public static PriceQuantity FromJson(JsonElement element)
    {
        return new PriceQuantity(
            element.GetProperty("minimum").GetInt32(),
            element.GetProperty("maximum").GetInt32()
        );
    }
}