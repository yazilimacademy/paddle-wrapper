using System.Text.Json;

namespace PaddleWrapper.Entities.Collections;

public class SimulationTypeCollection : Collection<SimulationType>
{
    public SimulationTypeCollection(List<SimulationType> data, Paginator paginator = null) : base(data, paginator)
    {
    }

    public static SimulationTypeCollection FromJson(JsonElement data, Paginator paginator = null)
    {
        return new SimulationTypeCollection(
            data.EnumerateArray()
                .Select(SimulationType.FromJson)
                .ToList(),
            paginator
        );
    }
}