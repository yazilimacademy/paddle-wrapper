using System.Text.Json;

namespace PaddleWrapper.Entities
{
    public class Event : Entity
    {
        public string EventType { get; }
        public JsonElement Data { get; }
        public DateTime OccurredAt { get; }

        public Event(string id, string eventType, JsonElement data, DateTime occurredAt)
        {
            Id = id;
            EventType = eventType;
            Data = data;
            OccurredAt = occurredAt;
        }

        public static Event FromDict(JsonElement data)
        {
            return new Event(
                id: data.GetProperty("id").GetString(),
                eventType: data.GetProperty("event_type").GetString(),
                data: data.GetProperty("data"),
                occurredAt: DateTime.Parse(data.GetProperty("occurred_at").GetString())
            );
        }
    }
} 