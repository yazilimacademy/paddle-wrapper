using System.Threading.Tasks;
using PaddleWrapper.Client;
using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Exceptions;
using PaddleWrapper.Resources.Simulations.Operations;

namespace PaddleWrapper.Resources.Simulations
{
    public class SimulationsClient
    {
        private readonly IPaddleClient _client;

        public SimulationsClient(IPaddleClient client)
        {
            _client = client;
        }

        public async Task<SimulationCollection> ListAsync(ListSimulations listOperation = null)
        {
            listOperation ??= new ListSimulations();
            var response = await _client.GetRawAsync("/simulations", listOperation);
            var parser = new ResponseParser(response);

            return SimulationCollection.From(
                parser.GetData(),
                new Paginator(_client, parser.GetPagination(), typeof(SimulationCollection))
            );
        }

        public async Task<Simulation> GetAsync(string id)
        {
            var response = await _client.GetRawAsync($"/simulations/{id}");
            var parser = new ResponseParser(response);

            return Simulation.From(parser.GetData());
        }

        public async Task<Simulation> CreateAsync(CreateSimulation createOperation)
        {
            var response = await _client.PostRawAsync("/simulations", createOperation);
            var parser = new ResponseParser(response);

            return Simulation.From(parser.GetData());
        }

        public async Task<Simulation> UpdateAsync(string id, UpdateSimulation operation)
        {
            var response = await _client.PatchRawAsync($"/simulations/{id}", operation);
            var parser = new ResponseParser(response);

            return Simulation.From(parser.GetData());
        }
    }
} 