using System.Text.Json;

namespace PaddleWrapper.Entities
{
    public class NotificationLog : Entity
    {
        public string NotificationId { get; }
        public string NotificationSettingId { get; }
        public int AttemptCount { get; }
        public string Status { get; }
        public string Response { get; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; }

        public NotificationLog(
            string id,
            string notificationId,
            string notificationSettingId,
            int attemptCount,
            string status,
            string response,
            DateTime createdAt,
            DateTime updatedAt)
        {
            Id = id;
            NotificationId = notificationId;
            NotificationSettingId = notificationSettingId;
            AttemptCount = attemptCount;
            Status = status;
            Response = response;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public static NotificationLog FromDict(JsonElement data)
        {
            return new NotificationLog(
                id: data.GetProperty("id").GetString(),
                notificationId: data.GetProperty("notification_id").GetString(),
                notificationSettingId: data.GetProperty("notification_setting_id").GetString(),
                attemptCount: data.GetProperty("attempt_count").GetInt32(),
                status: data.GetProperty("status").GetString(),
                response: data.GetProperty("response").GetString(),
                createdAt: DateTime.Parse(data.GetProperty("created_at").GetString()),
                updatedAt: DateTime.Parse(data.GetProperty("updated_at").GetString())
            );
        }
    }
} 