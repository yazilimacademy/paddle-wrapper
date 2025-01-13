using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities
{
    public class ReportCSV
    {
        [JsonPropertyName("url")]
        public string Url { get; }

        private ReportCSV(string url)
        {
            Url = url;
        }

        public static ReportCSV FromJson(JsonElement json)
        {
            return From(JsonSerializer.Deserialize<Dictionary<string, object>>(json.GetRawText()));
        }

        public static ReportCSV From(Dictionary<string, object> data)
        {
            return new ReportCSV(
                url: (string)data["url"]
            );
        }
    }
}