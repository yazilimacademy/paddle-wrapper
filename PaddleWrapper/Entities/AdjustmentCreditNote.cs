using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities
{
    public class AdjustmentCreditNote
    {
        [JsonPropertyName("url")]
        public string Url { get; }

        private AdjustmentCreditNote(string url)
        {
            Url = url;
        }

        public static AdjustmentCreditNote From(Dictionary<string, object> data)
        {
            return new AdjustmentCreditNote(
                url: (string)data["url"]
            );
        }
    }
}