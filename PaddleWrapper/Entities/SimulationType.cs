using PaddleWrapper.Entities.Events;
using PaddleWrapper.Entities.Simulations;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities
{
    public class SimulationType
    {
        [JsonPropertyName("name")]
        public string Name { get; }

        [JsonPropertyName("label")]
        public string Label { get; }

        [JsonPropertyName("description")]
        public string Description { get; }

        [JsonPropertyName("group")]
        public string Group { get; }

        [JsonPropertyName("type")]
        public SimulationKind Type { get; }

        [JsonPropertyName("events")]
        public IReadOnlyList<EventTypeName> Events { get; }

        private SimulationType(
            string name,
            string label,
            string description,
            string group,
            SimulationKind type,
            IReadOnlyList<EventTypeName> events)
        {
            Name = name;
            Label = label;
            Description = description;
            Group = group;
            Type = type;
            Events = events;
        }

        public static SimulationType From(Dictionary<string, object> data)
        {
            List<EventTypeName> events = new();
            if (data.ContainsKey("events"))
            {
                object[] eventsData = (object[])data["events"];
                foreach (object eventData in eventsData)
                {
                    events.Add(Enum.Parse<EventTypeName>((string)eventData, true));
                }
            }

            return new SimulationType(
                name: (string)data["name"],
                label: (string)data["label"],
                description: (string)data["description"],
                group: (string)data["group"],
                type: Enum.Parse<SimulationKind>((string)data["type"], true),
                events: events
            );
        }
    }
}