using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Shared;

public class Checkout
{
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    public static Checkout FromJson(JsonElement data)
    {
        return new Checkout
        {
            Url = data.TryGetProperty("url", out JsonElement url) ? url.GetString() : null
        };
    }
}