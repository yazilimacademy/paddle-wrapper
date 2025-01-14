using System.Text.Json.Serialization;

namespace PaddleWrapper.Resources.SimulationRuns.Operations;

public class GetSimulationRuns : IHasParameters
{
    [JsonPropertyName("simulation_id")]
    public string SimulationId { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; }

    public GetSimulationRuns(string simulationId, string id)
    {
        SimulationId = simulationId;
        Id = id;
    }

    public IDictionary<string, object> GetParameters()
    {
        Dictionary<string, object> parameters = new();

        if (!string.IsNullOrEmpty(SimulationId))
        {
            parameters.Add("simulation_id", SimulationId);
        }

        if (!string.IsNullOrEmpty(Id))
        {
            parameters.Add("id", Id);
        }

        return parameters;
    }
}