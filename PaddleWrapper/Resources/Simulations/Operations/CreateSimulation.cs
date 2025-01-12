using System.Text.Json.Serialization;

namespace PaddleWrapper.Resources.Simulations.Operations
{
    public class CreateSimulation
    {
        [JsonPropertyName("notification_setting_id")]
        public string NotificationSettingId { get; }

        [JsonPropertyName("type")]
        public string Type { get; }

        [JsonPropertyName("name")]
        public string Name { get; }

        [JsonPropertyName("payload")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Entity? Payload { get; }

        public CreateSimulation(
            string notificationSettingId,
            EventTypeName type,
            string name,
            Entity? payload = null)
        {
            NotificationSettingId = notificationSettingId;
            Type = type.ToString();
            Name = name;
            Payload = payload;
        }

        public CreateSimulation(
            string notificationSettingId,
            SimulationScenarioType type,
            string name,
            Entity? payload = null)
        {
            NotificationSettingId = notificationSettingId;
            Type = type.ToString();
            Name = name;
            Payload = payload;
        }
    }
}