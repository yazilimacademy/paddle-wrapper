using System.Text.Json.Serialization;

namespace PaddleWrapper.Resources.SimulationRuns.Operations;

public class CreateSimulationRun : IHasParameters
{
    [JsonPropertyName("simulation_id")]
    public string SimulationId { get; set; }

    public CreateSimulationRun(string simulationId)
    {
        SimulationId = simulationId;
    }

    public IDictionary<string, object> GetParameters()
    {
        Dictionary<string, object> parameters = new();

        if (!string.IsNullOrEmpty(SimulationId))
        {
            parameters.Add("simulation_id", SimulationId);
        }

        return parameters;
    }
}