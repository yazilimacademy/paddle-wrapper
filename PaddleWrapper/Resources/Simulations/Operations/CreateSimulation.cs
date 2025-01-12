using PaddleWrapper.Entities.Events;
using PaddleWrapper.Entities.Simulations;
using System.Text.Json.Serialization;
using NotificationEntity = PaddleWrapper.Notifications.Entities.IEntity;

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
        public NotificationEntity? Payload { get; }

        public CreateSimulation(
            string notificationSettingId,
            EventTypeName type,
            string name,
            NotificationEntity? payload = null)
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
            NotificationEntity? payload = null)
        {
            NotificationSettingId = notificationSettingId;
            Type = type.ToString();
            Name = name;
            Payload = payload;
        }
    }
}