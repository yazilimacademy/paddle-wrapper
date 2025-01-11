using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.SimulationRunEvents
{
    public class SimulationRunEventResponse
    {
        [JsonPropertyName("body")]
        public string Body { get; }

        [JsonPropertyName("status_code")]
        public int StatusCode { get; }

        private SimulationRunEventResponse(string body, int statusCode)
        {
            Body = body;
            StatusCode = statusCode;
        }

        public static SimulationRunEventResponse From(Dictionary<string, object> data)
        {
            return new SimulationRunEventResponse(
                body: (string)data["body"],
                statusCode: (int)data["status_code"]
            );
        }
    }
}