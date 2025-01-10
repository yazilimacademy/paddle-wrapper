using System.Text.Json;

namespace PaddleWrapper.Entities.Notifications
{
    public class NotificationPayload
    {
        public string AttemptId { get; }
        public string NotificationId { get; }
        public string EventId { get; }
        public string EventType { get; }
        public JsonElement Data { get; }
        public DateTime OccurredAt { get; }
        public string NotificationSettingId { get; }

        public NotificationPayload(
            string attemptId,
            string notificationId,
            string eventId,
            string eventType,
            JsonElement data,
            DateTime occurredAt,
            string notificationSettingId)
        {
            AttemptId = attemptId;
            NotificationId = notificationId;
            EventId = eventId;
            EventType = eventType;
            Data = data;
            OccurredAt = occurredAt;
            NotificationSettingId = notificationSettingId;
        }

        public static NotificationPayload FromDict(JsonElement data)
        {
            return new NotificationPayload(
                attemptId: data.GetProperty("attempt_id").GetString(),
                notificationId: data.GetProperty("notification_id").GetString(),
                eventId: data.GetProperty("event_id").GetString(),
                eventType: data.GetProperty("event_type").GetString(),
                data: data.GetProperty("data"),
                occurredAt: DateTime.Parse(data.GetProperty("occurred_at").GetString()),
                notificationSettingId: data.GetProperty("notification_setting_id").GetString()
            );
        }
    }
} 