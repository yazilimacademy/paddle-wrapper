using PaddleWrapper.Entities.Events;
using PaddleWrapper.Entities.Simulations;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities
{
    public class Simulation
    {
        [JsonPropertyName("id")]
        public string Id { get; }

        [JsonPropertyName("status")]
        public SimulationStatus Status { get; }

        [JsonPropertyName("notification_setting_id")]
        public string NotificationSettingId { get; }

        [JsonPropertyName("name")]
        public string Name { get; }

        [JsonPropertyName("type")]
        public object Type { get; } // Can be either EventTypeName or SimulationScenarioType

        [JsonPropertyName("payload")]
        public NotificationEntity? Payload { get; }

        [JsonPropertyName("last_run_at")]
        public DateTime? LastRunAt { get; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; }

        private Simulation(
            string id,
            SimulationStatus status,
            string notificationSettingId,
            string name,
            object type,
            NotificationEntity? payload,
            DateTime? lastRunAt,
            DateTime createdAt,
            DateTime updatedAt)
        {
            Id = id;
            Status = status;
            NotificationSettingId = notificationSettingId;
            Name = name;
            Type = type;
            Payload = payload;
            LastRunAt = lastRunAt;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public static Simulation From(Dictionary<string, object> data)
        {
            string typeStr = (string)data["type"];
            object type;

            try
            {
                EventTypeName eventType = Enum.Parse<EventTypeName>(typeStr, true);
                type = eventType;
            }
            catch
            {
                type = Enum.Parse<SimulationScenarioType>(typeStr, true);
            }

            return new Simulation(
                id: (string)data["id"],
                status: Enum.Parse<SimulationStatus>((string)data["status"], true),
                notificationSettingId: (string)data["notification_setting_id"],
                name: (string)data["name"],
                type: type,
                payload: data.ContainsKey("payload") && data["payload"] != null ?
                    EntityFactory.Create(typeStr, (Dictionary<string, object>)data["payload"]) : null,
                lastRunAt: data.ContainsKey("last_run_at") ?
                    DateTime.Parse((string)data["last_run_at"]) : null,
                createdAt: DateTime.Parse((string)data["created_at"]),
                updatedAt: DateTime.Parse((string)data["updated_at"])
            );
        }
    }
}