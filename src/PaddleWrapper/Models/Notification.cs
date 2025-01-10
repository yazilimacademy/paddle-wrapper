using System.Text.Json.Serialization;

namespace PaddleWrapper.Models
{
    public class Notification
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("payload")]
        public object Payload { get; set; }

        [JsonPropertyName("replay_url")]
        public string ReplayUrl { get; set; }

        [JsonPropertyName("occurrence")]
        public int Occurrence { get; set; }

        [JsonPropertyName("delivered_at")]
        public DateTime? DeliveredAt { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("scheduled_at")]
        public DateTime? ScheduledAt { get; set; }

        [JsonPropertyName("last_attempt_at")]
        public DateTime? LastAttemptAt { get; set; }

        [JsonPropertyName("next_attempt_at")]
        public DateTime? NextAttemptAt { get; set; }
    }

    public class NotificationAttempt
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("notification_id")]
        public string NotificationId { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("status_code")]
        public int StatusCode { get; set; }

        [JsonPropertyName("response_body")]
        public string ResponseBody { get; set; }

        [JsonPropertyName("attempted_at")]
        public DateTime AttemptedAt { get; set; }
    }
}