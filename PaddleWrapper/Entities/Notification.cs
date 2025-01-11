using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities
{
    public class Notification
    {
        [JsonPropertyName("id")]
        public string Id { get; }

        [JsonPropertyName("type")]
        public EventTypeName Type { get; }

        [JsonPropertyName("status")]
        public NotificationStatus Status { get; }

        [JsonPropertyName("payload")]
        public Event Payload { get; }

        [JsonPropertyName("occurred_at")]
        public DateTime OccurredAt { get; }

        [JsonPropertyName("delivered_at")]
        public DateTime? DeliveredAt { get; }

        [JsonPropertyName("replayed_at")]
        public DateTime? ReplayedAt { get; }

        [JsonPropertyName("origin")]
        public NotificationOrigin Origin { get; }

        [JsonPropertyName("last_attempt_at")]
        public DateTime? LastAttemptAt { get; }

        [JsonPropertyName("retry_at")]
        public DateTime? RetryAt { get; }

        [JsonPropertyName("times_attempted")]
        public int TimesAttempted { get; }

        [JsonPropertyName("notification_setting_id")]
        public string NotificationSettingId { get; }

        private Notification(
            string id,
            EventTypeName type,
            NotificationStatus status,
            Event payload,
            DateTime occurredAt,
            DateTime? deliveredAt,
            DateTime? replayedAt,
            NotificationOrigin origin,
            DateTime? lastAttemptAt,
            DateTime? retryAt,
            int timesAttempted,
            string notificationSettingId)
        {
            Id = id;
            Type = type;
            Status = status;
            Payload = payload;
            OccurredAt = occurredAt;
            DeliveredAt = deliveredAt;
            ReplayedAt = replayedAt;
            Origin = origin;
            LastAttemptAt = lastAttemptAt;
            RetryAt = retryAt;
            TimesAttempted = timesAttempted;
            NotificationSettingId = notificationSettingId;
        }

        public static Notification From(Dictionary<string, object> data)
        {
            return new Notification(
                id: (string)data["id"],
                type: System.Enum.Parse<EventTypeName>((string)data["type"], true),
                status: System.Enum.Parse<NotificationStatus>((string)data["status"], true),
                payload: Event.From((Dictionary<string, object>)data["payload"]),
                occurredAt: DateTime.Parse((string)data["occurred_at"]),
                deliveredAt: data.ContainsKey("delivered_at") ? DateTime.Parse((string)data["delivered_at"]) : null,
                replayedAt: data.ContainsKey("replayed_at") ? DateTime.Parse((string)data["replayed_at"]) : null,
                origin: System.Enum.Parse<NotificationOrigin>((string)data["origin"], true),
                lastAttemptAt: data.ContainsKey("last_attempt_at") ? DateTime.Parse((string)data["last_attempt_at"]) : null,
                retryAt: data.ContainsKey("retry_at") ? DateTime.Parse((string)data["retry_at"]) : null,
                timesAttempted: (int)data["times_attempted"],
                notificationSettingId: (string)data["notification_setting_id"]
            );
        }
    }
}