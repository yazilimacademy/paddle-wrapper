using PaddleWrapper.Entities.Events;
using PaddleWrapper.Entities.NotificationSettings;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Resources.NotificationSettings.Operations
{
    public class CreateNotificationSetting
    {
        [JsonPropertyName("description")]
        public string Description { get; }

        [JsonPropertyName("destination")]
        public string Destination { get; }

        [JsonPropertyName("subscribed_events")]
        public IEnumerable<EventTypeName> SubscribedEvents { get; }

        [JsonPropertyName("type")]
        public NotificationSettingType Type { get; }

        [JsonPropertyName("include_sensitive_fields")]
        public bool IncludeSensitiveFields { get; }

        [JsonPropertyName("api_version")]
        public int? ApiVersion { get; }

        public CreateNotificationSetting(
            string description,
            string destination,
            IEnumerable<EventTypeName> subscribedEvents,
            NotificationSettingType type,
            bool includeSensitiveFields,
            int? apiVersion = null)
        {
            Description = description;
            Destination = destination;
            SubscribedEvents = subscribedEvents;
            Type = type;
            IncludeSensitiveFields = includeSensitiveFields;
            ApiVersion = apiVersion;
        }
    }
}