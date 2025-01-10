using System.Text.Json;

namespace PaddleWrapper.Entities.Notifications
{
    public class Notification
    {
        public string NotificationId { get; }
        public string NotificationSettingId { get; }
        public string EventId { get; }
        public string EventType { get; }
        public JsonElement Data { get; }
        public DateTime OccurredAt { get; }

        public Notification(string notificationId, string notificationSettingId, string eventId, string eventType, JsonElement data, DateTime occurredAt)
        {
            NotificationId = notificationId;
            NotificationSettingId = notificationSettingId;
            EventId = eventId;
            EventType = eventType;
            Data = data;
            OccurredAt = occurredAt;
        }

        public static Notification FromDict(JsonElement data)
        {
            return new Notification(
                notificationId: data.GetProperty("notification_id").GetString(),
                notificationSettingId: data.GetProperty("notification_setting_id").GetString(),
                eventId: data.GetProperty("event_id").GetString(),
                eventType: data.GetProperty("event_type").GetString(),
                data: data.GetProperty("data"),
                occurredAt: DateTime.Parse(data.GetProperty("occurred_at").GetString())
            );
        }
    }
} 