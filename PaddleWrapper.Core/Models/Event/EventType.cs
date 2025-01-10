using Newtonsoft.Json;

namespace PaddleWrapper.Core.Models.Event
{
    public class EventType
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("group")]
        public string Group { get; set; }

        [JsonProperty("available_versions")]
        public string[] AvailableVersions { get; set; }
    }
} 