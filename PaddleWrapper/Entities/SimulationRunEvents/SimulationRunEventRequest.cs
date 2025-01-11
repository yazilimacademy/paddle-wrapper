using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.SimulationRunEvents
{
    public class SimulationRunEventRequest
    {
        [JsonPropertyName("body")]
        public string Body { get; }

        private SimulationRunEventRequest(string body)
        {
            Body = body;
        }

        public static SimulationRunEventRequest From(Dictionary<string, object> data)
        {
            return new SimulationRunEventRequest(
                body: (string)data["body"]
            );
        }
    }
}