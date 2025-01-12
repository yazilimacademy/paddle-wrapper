using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Resources.Simulations.Operations;

namespace PaddleWrapper.Resources.Simulations
{
    public class SimulationsClient
    {
        private readonly Client _client;

        public SimulationsClient(Client client)
        {
            _client = client;
        }

        public async Task<SimulationCollection> ListAsync(ListSimulations listOperation = null)
        {
            listOperation ??= new ListSimulations();
            var response = await _client.GetRaw("/simulations", listOperation);
            ResponseParser parser = new(response);

            return SimulationCollection.From(
                parser.GetData(),
                new Paginator(_client, parser.GetPagination(), typeof(SimulationCollection))
            );
        }

        public async Task<Simulation> GetAsync(string id)
        {
            HttpResponseMessage response = await _client.GetRaw($"/simulations/{id}");
            ResponseParser parser = new(response);

            return Simulation.From(parser.GetData());
        }

        public async Task<Simulation> CreateAsync(CreateSimulation createOperation)
        {
            var response = await _client.PostRaw("/simulations", createOperation);
            ResponseParser parser = new(response);

            return Simulation.From(parser.GetData());
        }

        public async Task<Simulation> UpdateAsync(string id, UpdateSimulation operation)
        {
            var response = await _client.PatchRaw($"/simulations/{id}", operation);
            ResponseParser parser = new(response);

            return Simulation.From(parser.GetData());
        }
    }
}