using System.Text.Json;

namespace PaddleWrapper.Entities
{
    public class AdjustmentCreditNote : Entity
    {
        public string Url { get; }

        public AdjustmentCreditNote(string url)
        {
            Url = url;
        }

        public static AdjustmentCreditNote FromDict(JsonElement data)
        {
            return new AdjustmentCreditNote(data.GetProperty("url").GetString());
        }
    }
} 