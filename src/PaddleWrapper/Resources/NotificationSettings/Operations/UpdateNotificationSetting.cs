using PaddleWrapper.Entities.Events;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Resources.NotificationSettings.Operations
{
    public class UpdateNotificationSetting
    {
        [JsonPropertyName("description")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Description { get; }

        [JsonPropertyName("destination")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Destination { get; }

        [JsonPropertyName("active")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Active { get; }

        [JsonPropertyName("api_version")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? ApiVersion { get; }

        [JsonPropertyName("include_sensitive_fields")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IncludeSensitiveFields { get; }

        [JsonPropertyName("subscribed_events")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<EventTypeName>? SubscribedEvents { get; }

        public UpdateNotificationSetting(
            string? description = null,
            string? destination = null,
            bool? active = null,
            int? apiVersion = null,
            bool? includeSensitiveFields = null,
            IEnumerable<EventTypeName>? subscribedEvents = null)
        {
            Description = description;
            Destination = destination;
            Active = active;
            ApiVersion = apiVersion;
            IncludeSensitiveFields = includeSensitiveFields;
            SubscribedEvents = subscribedEvents;
        }
    }
}