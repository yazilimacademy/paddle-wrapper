using PaddleWrapper.Entities.Events;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities
{
    public class EventType
    {
        [JsonPropertyName("name")]
        public EventTypeName Name { get; }

        [JsonPropertyName("description")]
        public string Description { get; }

        [JsonPropertyName("group")]
        public string Group { get; }

        [JsonPropertyName("available_versions")]
        public IReadOnlyList<string> AvailableVersions { get; }

        private EventType(
            EventTypeName name,
            string description,
            string group,
            IReadOnlyList<string> availableVersions)
        {
            Name = name;
            Description = description;
            Group = group;
            AvailableVersions = availableVersions;
        }

        public static EventType From(Dictionary<string, object> data)
        {
            List<string> availableVersions = ((object[])data["available_versions"])
                .Select(v => (string)v)
                .ToList();

            return new EventType(
                name: Enum.Parse<EventTypeName>((string)data["name"], true),
                description: (string)data["description"],
                group: (string)data["group"],
                availableVersions: availableVersions
            );
        }
    }
}