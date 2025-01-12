using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Resources.SimulationRunEvents.Operations;

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
            var response = await _client.GetRaw($"/simulations/{simulationId}/runs/{runId}/events", listOperation);
            ResponseParser parser = new(response);

            return SimulationRunEventCollection.From(
                parser.GetData(),
                new Paginator(_client, parser.GetPagination(), typeof(SimulationRunEventCollection))
            );
        }

        public async Task<SimulationRunEvent> GetAsync(string simulationId, string runId, string id)
        {
            HttpResponseMessage response = await _client.GetRaw($"/simulations/{simulationId}/runs/{runId}/events/{id}");
            ResponseParser parser = new(response);

            return SimulationRunEvent.From(parser.GetData());
        }

        public async Task<SimulationRunEvent> ReplayAsync(string simulationId, string runId, string id)
        {
            var response = await _client.PostRawAsync($"/simulations/{simulationId}/runs/{runId}/events/{id}/replay");
            ResponseParser parser = new(response);

            return SimulationRunEvent.From(parser.GetData());
        }
    }
}