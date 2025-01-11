using System.Threading.Tasks;
using PaddleWrapper.Client;
using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Exceptions;
using PaddleWrapper.Resources.SimulationRunEvents.Operations;

namespace PaddleWrapper.Resources.SimulationRunEvents
{
    public class SimulationRunEventsClient
    {
        private readonly IPaddleClient _client;

        public SimulationRunEventsClient(IPaddleClient client)
        {
            _client = client;
        }

        public async Task<SimulationRunEventCollection> ListAsync(string simulationId, string runId, ListSimulationRunEvents listOperation = null)
        {
            listOperation ??= new ListSimulationRunEvents();
            var response = await _client.GetRawAsync($"/simulations/{simulationId}/runs/{runId}/events", listOperation);
            var parser = new ResponseParser(response);

            return SimulationRunEventCollection.From(
                parser.GetData(),
                new Paginator(_client, parser.GetPagination(), typeof(SimulationRunEventCollection))
            );
        }

        public async Task<SimulationRunEvent> GetAsync(string simulationId, string runId, string id)
        {
            var response = await _client.GetRawAsync($"/simulations/{simulationId}/runs/{runId}/events/{id}");
            var parser = new ResponseParser(response);

            return SimulationRunEvent.From(parser.GetData());
        }

        public async Task<SimulationRunEvent> ReplayAsync(string simulationId, string runId, string id)
        {
            var response = await _client.PostRawAsync($"/simulations/{simulationId}/runs/{runId}/events/{id}/replay");
            var parser = new ResponseParser(response);

            return SimulationRunEvent.From(parser.GetData());
        }
    }
} 