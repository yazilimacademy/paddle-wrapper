using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Shared
{
    public class Checkout
    {
        [JsonPropertyName("url")]
        public string? Url { get; }

        [JsonConstructor]
        public Checkout(string? url = null)
        {
            Url = url;
        }

        public static Checkout From(Dictionary<string, object> data)
        {
            return new Checkout(
                url: data.ContainsKey("url") ? data["url"]?.ToString() : null
            );
        }
    }
} 