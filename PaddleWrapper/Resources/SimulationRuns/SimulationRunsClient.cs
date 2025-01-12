using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Resources.SimulationRuns.Operations;

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
            var response = await _client.GetRaw($"/simulations/{simulationId}/runs", listOperation);
            ResponseParser parser = new(response);

            return SimulationRunCollection.From(
                parser.GetData(),
                new Paginator(_client, parser.GetPagination(), typeof(SimulationRunCollection))
            );
        }

        public async Task<SimulationRun> GetAsync(string simulationId, string id, GetSimulationRuns getOperation = null)
        {
            getOperation ??= new GetSimulationRuns();
            var response = await _client.GetRaw($"/simulations/{simulationId}/runs/{id}", getOperation);
            ResponseParser parser = new(response);

            return SimulationRun.From(parser.GetData());
        }

        public async Task<SimulationRun> CreateAsync(string simulationId)
        {
            var response = await _client.PostRaw($"/simulations/{simulationId}/runs");
            ResponseParser parser = new(response);

            return SimulationRun.From(parser.GetData());
        }
    }
}