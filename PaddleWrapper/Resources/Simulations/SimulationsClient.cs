using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Extensions;
using PaddleWrapper.Resources.Simulations.Operations;
using System.Text.Json;

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
            HttpResponseMessage response = await _client.GetRawAsync("/simulations", listOperation);
            JsonElement jsonElement = JsonDocument.Parse(await response.Content.ReadAsStringAsync()).RootElement;
            JsonElement data = jsonElement.GetProperty("data");
            JsonElement meta = jsonElement.GetProperty("meta");

            Paginator paginator = new(
                _client.HttpClient,
                Pagination.FromJson(meta),
                typeof(SimulationCollection)
            );

            return SimulationCollection.FromJson(data, paginator);
        }

        public async Task<Simulation> GetAsync(string id)
        {
            JsonDocument response = await _client.Get($"/simulations/{id}");
            return Simulation.FromJson(response.RootElement.GetProperty("data"));
        }

        public async Task<Simulation> CreateAsync(CreateSimulation createOperation)
        {
            JsonDocument response = await _client.Post("/simulations", createOperation);
            return Simulation.FromJson(response.RootElement.GetProperty("data"));
        }

        public async Task<Simulation> UpdateAsync(string id, UpdateSimulation operation)
        {
            JsonDocument response = await _client.Patch($"/simulations/{id}", operation);
            return Simulation.FromJson(response.RootElement.GetProperty("data"));
        }
    }
}