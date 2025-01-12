using PaddleWrapper.Entities.Events;
using PaddleWrapper.Entities.Simulations;
using System.Text.Json.Serialization;
using NotificationEntity = PaddleWrapper.Notifications.Entities.IEntity;

namespace PaddleWrapper.Resources.Simulations.Operations
{
    public class UpdateSimulation
    {
        [JsonPropertyName("notification_setting_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? NotificationSettingId { get; }

        [JsonPropertyName("type")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Type { get; private set; }

        [JsonPropertyName("name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Name { get; }

        [JsonPropertyName("status")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Status { get; private set; }

        [JsonPropertyName("payload")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public NotificationEntity? Payload { get; }

        public UpdateSimulation(
            string? notificationSettingId = null,
            EventTypeName? type = null,
            string? name = null,
            SimulationStatus? status = null,
            NotificationEntity? payload = null)
        {
            NotificationSettingId = notificationSettingId;
            Type = type?.ToString();
            Name = name;
            Status = status?.ToString()?.ToLower();
            Payload = payload;
        }

        public UpdateSimulation(
            string? notificationSettingId = null,
            SimulationScenarioType? type = null,
            string? name = null,
            SimulationStatus? status = null,
            NotificationEntity? payload = null)
        {
            NotificationSettingId = notificationSettingId;
            Type = type?.ToString();
            Name = name;
            Status = status?.ToString()?.ToLower();
            Payload = payload;
        }
    }
}