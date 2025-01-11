using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using PaddleWrapper.Entities.Event;
using PaddleWrapper.Entities.Simulation;
using PaddleWrapper.Entities.SimulationRun;

namespace PaddleWrapper.Entities
{
    public class SimulationRun
    {
        [JsonPropertyName("id")]
        public string Id { get; }

        [JsonPropertyName("status")]
        public SimulationRunStatus Status { get; }

        [JsonPropertyName("type")]
        public object Type { get; } // Can be either EventTypeName or SimulationScenarioType

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; }

        [JsonPropertyName("events")]
        public IReadOnlyList<SimulationRunEvent> Events { get; }

        private SimulationRun(
            string id,
            SimulationRunStatus status,
            object type,
            DateTime createdAt,
            DateTime updatedAt,
            IReadOnlyList<SimulationRunEvent> events)
        {
            Id = id;
            Status = status;
            Type = type;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Events = events;
        }

        public static SimulationRun From(Dictionary<string, object> data)
        {
            var typeStr = (string)data["type"];
            object type;
            
            try
            {
                var eventType = System.Enum.Parse<EventTypeName>(typeStr, true);
                type = eventType;
            }
            catch
            {
                type = System.Enum.Parse<SimulationScenarioType>(typeStr, true);
            }

            var events = new List<SimulationRunEvent>();
            if (data.ContainsKey("events"))
            {
                var eventsData = (object[])data["events"];
                foreach (var eventData in eventsData)
                {
                    events.Add(SimulationRunEvent.From((Dictionary<string, object>)eventData));
                }
            }

            return new SimulationRun(
                id: (string)data["id"],
                status: System.Enum.Parse<SimulationRunStatus>((string)data["status"], true),
                type: type,
                createdAt: DateTime.Parse((string)data["created_at"]),
                updatedAt: DateTime.Parse((string)data["updated_at"]),
                events: events
            );
        }
    }
} 