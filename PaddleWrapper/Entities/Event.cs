using PaddleWrapper.Entities.Events;
using PaddleWrapper.Notifications.Entities;
using PaddleWrapper.Notifications.Events;
using System.Reflection;
using System.Text.Json.Serialization;
using DateTime = PaddleWrapper.Notifications.Entities.DateTime;
using NotificationEntity = PaddleWrapper.Notifications.Entities.IEntity;



namespace PaddleWrapper.Entities
{
    public abstract class Event
    {
        [JsonPropertyName("event_id")]
        public string EventId { get; }

        [JsonPropertyName("event_type")]
        public EventTypeName EventType { get; }

        [JsonPropertyName("occurred_at")]
        public DateTime OccurredAt { get; }

        [JsonPropertyName("data")]
        public NotificationEntity Data { get; }

        [JsonPropertyName("notification_id")]
        public string? NotificationId { get; }

        protected Event(
            string eventId,
            EventTypeName eventType,
            DateTime occurredAt,
            NotificationEntity data,
            string? notificationId = null)
        {
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            Data = data;
            NotificationId = notificationId;
        }

        public static Event From(Dictionary<string, object> data)
        {
            string eventTypeStr = (string)data["event_type"];
            string[] type = eventTypeStr.Split('.');
            string identifier = string.Join("", type.Select(t => char.ToUpperInvariant(t[0]) + t[1..]));

            Type? eventType = Type.GetType($"PaddleWrapper.Notifications.Events.{identifier}");
            if (eventType == null || !typeof(Event).IsAssignableFrom(eventType))
            {
                eventType = typeof(UndefinedEvent);
            }

            MethodInfo? fromEventMethod = eventType.GetMethod("FromEvent");
            if (fromEventMethod == null)
            {
                throw new InvalidOperationException($"Event type {eventType.Name} does not implement FromEvent method");
            }

            return (Event)fromEventMethod.Invoke(null, new object[]
            {
                (string)data["event_id"],
                Enum.Parse<EventTypeName>(eventTypeStr, true),
                DateTime.Parse((string)data["occurred_at"]),
                EntityFactory.Create(eventTypeStr, (Dictionary<string, object>)data["data"]),
                data.ContainsKey("notification_id") ? (string?)data["notification_id"] : null
            });
        }

        public abstract static Event FromEvent(
            string eventId,
            EventTypeName eventType,
            DateTime occurredAt,
            NotificationEntity data,
            string? notificationId = null);
    }
}