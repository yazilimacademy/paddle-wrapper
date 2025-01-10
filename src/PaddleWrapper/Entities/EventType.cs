using System.Text.Json;

namespace PaddleWrapper.Entities
{
    public class EventType : Entity
    {
        public string Name { get; }
        public string Description { get; }
        public string Group { get; }
        public bool Available { get; }
        public string Version { get; }

        public EventType(
            string id,
            string name,
            string description,
            string group,
            bool available,
            string version)
        {
            Id = id;
            Name = name;
            Description = description;
            Group = group;
            Available = available;
            Version = version;
        }

        public static EventType FromDict(JsonElement data)
        {
            return new EventType(
                id: data.GetProperty("id").GetString(),
                name: data.GetProperty("name").GetString(),
                description: data.GetProperty("description").GetString(),
                group: data.GetProperty("group").GetString(),
                available: data.GetProperty("available").GetBoolean(),
                version: data.GetProperty("version").GetString()
            );
        }
    }
} 