using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Extensions;
using PaddleWrapper.Resources.SimulationRunEvents.Operations;
using System.Text.Json;

namespace PaddleWrapper.Resources.SimulationRunEvents
{
    public class SimulationRunEventsClient
    {
        private readonly Client _client;

        public SimulationRunEventsClient(Client client)
        {
            _client = client;
        }

        public async Task<SimulationRunEventCollection> ListAsync(string simulationId, string runId, ListSimulationRunEvents listOperation = null)
        {
            listOperation ??= new ListSimulationRunEvents();
            HttpResponseMessage response = await _client.GetRawAsync($"/simulations/{simulationId}/runs/{runId}/events", listOperation);
            JsonElement jsonElement = JsonDocument.Parse(await response.Content.ReadAsStringAsync()).RootElement;
            JsonElement data = jsonElement.GetProperty("data");
            JsonElement meta = jsonElement.GetProperty("meta");

            Paginator paginator = new(
                _client.HttpClient,
                Pagination.FromJson(meta),
                typeof(SimulationRunEventCollection)
            );

            return SimulationRunEventCollection.FromJson(data, paginator);
        }

        public async Task<SimulationRunEvent> GetAsync(string simulationId, string runId, string id)
        {
            JsonDocument response = await _client.Get($"/simulations/{simulationId}/runs/{runId}/events/{id}");
            return SimulationRunEvent.FromJson(response.RootElement.GetProperty("data"));
        }

        public async Task<SimulationRunEvent> ReplayAsync(string simulationId, string runId, string id)
        {
            JsonDocument response = await _client.Post($"/simulations/{simulationId}/runs/{runId}/events/{id}/replay");
            return SimulationRunEvent.FromJson(response.RootElement.GetProperty("data"));
        }
    }
}