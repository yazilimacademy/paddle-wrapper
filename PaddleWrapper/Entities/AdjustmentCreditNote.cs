using System.Collections.Generic;
using System.Text.Json.Serialization;
using PaddleWrapper.Entities.Shared;

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