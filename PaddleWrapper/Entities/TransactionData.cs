using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities
{
    public class TransactionData
    {
        [JsonPropertyName("url")]
        public string Url { get; }

        private TransactionData(string url)
        {
            Url = url;
        }

        public static TransactionData FromJson(JsonElement json)
        {
            return From(JsonSerializer.Deserialize<Dictionary<string, object>>(json.GetRawText()));
        }

        public static TransactionData From(Dictionary<string, object> data)
        {
            return new TransactionData(
                url: (string)data["url"]
            );
        }
    }
}