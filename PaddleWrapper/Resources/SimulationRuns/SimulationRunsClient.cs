using System.Threading.Tasks;
using PaddleWrapper.Client;
using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Exceptions;
using PaddleWrapper.Resources.SimulationRuns.Operations;

namespace PaddleWrapper.Resources.SimulationRuns
{
    public class SimulationRunsClient
    {
        private readonly IPaddleClient _client;

        public SimulationRunsClient(IPaddleClient client)
        {
            _client = client;
        }

        public async Task<SimulationRunCollection> ListAsync(string simulationId, ListSimulationRuns listOperation = null)
        {
            listOperation ??= new ListSimulationRuns();
            var response = await _client.GetRawAsync($"/simulations/{simulationId}/runs", listOperation);
            var parser = new ResponseParser(response);

            return SimulationRunCollection.From(
                parser.GetData(),
                new Paginator(_client, parser.GetPagination(), typeof(SimulationRunCollection))
            );
        }

        public async Task<SimulationRun> GetAsync(string simulationId, string id, GetSimulationRuns getOperation = null)
        {
            getOperation ??= new GetSimulationRuns();
            var response = await _client.GetRawAsync($"/simulations/{simulationId}/runs/{id}", getOperation);
            var parser = new ResponseParser(response);

            return SimulationRun.From(parser.GetData());
        }

        public async Task<SimulationRun> CreateAsync(string simulationId)
        {
            var response = await _client.PostRawAsync($"/simulations/{simulationId}/runs");
            var parser = new ResponseParser(response);

            return SimulationRun.From(parser.GetData());
        }
    }
} 