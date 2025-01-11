using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities
{
    public class NotificationSetting
    {
        [JsonPropertyName("id")]
        public string Id { get; }

        [JsonPropertyName("description")]
        public string Description { get; }

        [JsonPropertyName("type")]
        public NotificationSettingType Type { get; }

        [JsonPropertyName("destination")]
        public string Destination { get; }

        [JsonPropertyName("active")]
        public bool Active { get; }

        [JsonPropertyName("api_version")]
        public int ApiVersion { get; }

        [JsonPropertyName("include_sensitive_fields")]
        public bool IncludeSensitiveFields { get; }

        [JsonPropertyName("subscribed_events")]
        public IReadOnlyList<EventType> SubscribedEvents { get; }

        [JsonPropertyName("endpoint_secret_key")]
        public string EndpointSecretKey { get; }

        [JsonPropertyName("traffic_source")]
        public NotificationSettingTrafficSource TrafficSource { get; }

        private NotificationSetting(
            string id,
            string description,
            NotificationSettingType type,
            string destination,
            bool active,
            int apiVersion,
            bool includeSensitiveFields,
            IReadOnlyList<EventType> subscribedEvents,
            string endpointSecretKey,
            NotificationSettingTrafficSource trafficSource)
        {
            Id = id;
            Description = description;
            Type = type;
            Destination = destination;
            Active = active;
            ApiVersion = apiVersion;
            IncludeSensitiveFields = includeSensitiveFields;
            SubscribedEvents = subscribedEvents;
            EndpointSecretKey = endpointSecretKey;
            TrafficSource = trafficSource;
        }

        public static NotificationSetting From(Dictionary<string, object> data)
        {
            List<EventType> subscribedEvents = new();
            if (data.ContainsKey("subscribed_events"))
            {
                object[] eventsData = (object[])data["subscribed_events"];
                foreach (object eventData in eventsData)
                {
                    subscribedEvents.Add(EventType.From((Dictionary<string, object>)eventData));
                }
            }

            return new NotificationSetting(
                id: (string)data["id"],
                description: (string)data["description"],
                type: System.Enum.Parse<NotificationSettingType>((string)data["type"], true),
                destination: (string)data["destination"],
                active: (bool)data["active"],
                apiVersion: (int)data["api_version"],
                includeSensitiveFields: (bool)data["include_sensitive_fields"],
                subscribedEvents: subscribedEvents,
                endpointSecretKey: (string)data["endpoint_secret_key"],
                trafficSource: System.Enum.Parse<NotificationSettingTrafficSource>((string)data["traffic_source"], true)
            );
        }
    }
}