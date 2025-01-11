using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using PaddleWrapper.Entities.Shared;

namespace PaddleWrapper.Entities
{
    public class NotificationLog
    {
        [JsonPropertyName("id")]
        public string Id { get; }

        [JsonPropertyName("response_code")]
        public int ResponseCode { get; }

        [JsonPropertyName("response_content_type")]
        public string? ResponseContentType { get; }

        [JsonPropertyName("response_body")]
        public string ResponseBody { get; }

        [JsonPropertyName("attempted_at")]
        public DateTime AttemptedAt { get; }

        private NotificationLog(
            string id,
            int responseCode,
            string? responseContentType,
            string responseBody,
            DateTime attemptedAt)
        {
            Id = id;
            ResponseCode = responseCode;
            ResponseContentType = responseContentType;
            ResponseBody = responseBody;
            AttemptedAt = attemptedAt;
        }

        public static NotificationLog From(Dictionary<string, object> data)
        {
            return new NotificationLog(
                id: (string)data["id"],
                responseCode: (int)data["response_code"],
                responseContentType: data.ContainsKey("response_content_type") ? (string?)data["response_content_type"] : null,
                responseBody: (string)data["response_body"],
                attemptedAt: DateTime.Parse((string)data["attempted_at"])
            );
        }
    }
} 