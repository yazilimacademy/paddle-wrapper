using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Extensions;
using PaddleWrapper.Resources.SimulationRuns.Operations;
using System.Text.Json;

namespace PaddleWrapper.Resources.SimulationRuns
{
    public class SimulationRunsClient
    {
        private readonly Client _client;

        public SimulationRunsClient(Client client)
        {
            _client = client;
        }

        public async Task<SimulationRunCollection> ListAsync(string simulationId, ListSimulationRuns listOperation = null)
        {
            listOperation ??= new ListSimulationRuns();
            HttpResponseMessage response = await _client.GetRawAsync($"/simulations/{simulationId}/runs", listOperation);
            JsonElement jsonElement = JsonDocument.Parse(await response.Content.ReadAsStringAsync()).RootElement;
            JsonElement data = jsonElement.GetProperty("data");
            JsonElement meta = jsonElement.GetProperty("meta");

            Paginator paginator = new(
                _client.HttpClient,
                Pagination.FromJson(meta),
                typeof(SimulationRunCollection)
            );

            return SimulationRunCollection.FromJson(data, paginator);
        }

        public async Task<SimulationRun> GetAsync(string simulationId, string id, GetSimulationRuns getOperation = null)
        {
            getOperation ??= new GetSimulationRuns();
            JsonDocument response = await _client.Get($"/simulations/{simulationId}/runs/{id}", getOperation);
            return SimulationRun.FromJson(response.RootElement.GetProperty("data"));
        }

        public async Task<SimulationRun> CreateAsync(string simulationId)
        {
            JsonDocument response = await _client.Post($"/simulations/{simulationId}/runs");
            return SimulationRun.FromJson(response.RootElement.GetProperty("data"));
        }
    }
}