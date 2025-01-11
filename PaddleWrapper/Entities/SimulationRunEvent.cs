using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities
{
    public class SimulationRunEvent
    {
        [JsonPropertyName("id")]
        public string Id { get; }

        [JsonPropertyName("status")]
        public SimulationRunEventStatus Status { get; }

        [JsonPropertyName("event_type")]
        public EventTypeName Type { get; }

        [JsonPropertyName("payload")]
        public NotificationEntity Payload { get; }

        [JsonPropertyName("request")]
        public SimulationRunEventRequest? Request { get; }

        [JsonPropertyName("response")]
        public SimulationRunEventResponse? Response { get; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; }

        private SimulationRunEvent(
            string id,
            SimulationRunEventStatus status,
            EventTypeName type,
            NotificationEntity payload,
            SimulationRunEventRequest? request,
            SimulationRunEventResponse? response,
            DateTime createdAt,
            DateTime updatedAt)
        {
            Id = id;
            Status = status;
            Type = type;
            Payload = payload;
            Request = request;
            Response = response;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public static SimulationRunEvent From(Dictionary<string, object> data)
        {
            string eventType = (string)data["event_type"];

            return new SimulationRunEvent(
                id: (string)data["id"],
                status: System.Enum.Parse<SimulationRunEventStatus>((string)data["status"], true),
                type: System.Enum.Parse<EventTypeName>(eventType, true),
                payload: data.ContainsKey("payload") && data["payload"] != null ?
                    EntityFactory.Create(eventType, (Dictionary<string, object>)data["payload"]) : null,
                request: data.ContainsKey("request") ?
                    SimulationRunEventRequest.From((Dictionary<string, object>)data["request"]) : null,
                response: data.ContainsKey("response") ?
                    SimulationRunEventResponse.From((Dictionary<string, object>)data["response"]) : null,
                createdAt: DateTime.Parse((string)data["created_at"]),
                updatedAt: DateTime.Parse((string)data["updated_at"])
            );
        }
    }
}