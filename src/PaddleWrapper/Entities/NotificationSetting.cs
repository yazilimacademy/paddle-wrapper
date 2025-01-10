using System.Text.Json;
using PaddleWrapper.Entities.Shared;

namespace PaddleWrapper.Entities
{
    public class NotificationSetting : Entity
    {
        public string Description { get; }
        public string Type { get; }
        public string Destination { get; }
        public bool Active { get; }
        public string ApiVersion { get; }
        public string TrafficSource { get; }
        public bool IncludeSignature { get; }
        public CustomData CustomData { get; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; }

        public NotificationSetting(
            string id,
            string description,
            string type,
            string destination,
            bool active,
            string apiVersion,
            string trafficSource,
            bool includeSignature,
            CustomData customData,
            DateTime createdAt,
            DateTime updatedAt)
        {
            Id = id;
            Description = description;
            Type = type;
            Destination = destination;
            Active = active;
            ApiVersion = apiVersion;
            TrafficSource = trafficSource;
            IncludeSignature = includeSignature;
            CustomData = customData;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public static NotificationSetting FromDict(JsonElement data)
        {
            return new NotificationSetting(
                id: data.GetProperty("id").GetString(),
                description: data.GetProperty("description").GetString(),
                type: data.GetProperty("type").GetString(),
                destination: data.GetProperty("destination").GetString(),
                active: data.GetProperty("active").GetBoolean(),
                apiVersion: data.GetProperty("api_version").GetString(),
                trafficSource: data.GetProperty("traffic_source").GetString(),
                includeSignature: data.GetProperty("include_signature").GetBoolean(),
                customData: data.TryGetProperty("custom_data", out var customData) ? new CustomData(customData) : null,
                createdAt: DateTime.Parse(data.GetProperty("created_at").GetString()),
                updatedAt: DateTime.Parse(data.GetProperty("updated_at").GetString())
            );
        }
    }
} 