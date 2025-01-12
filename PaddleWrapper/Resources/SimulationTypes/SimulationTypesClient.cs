using PaddleWrapper.Entities.Collections;

namespace PaddleWrapper.Resources.SimulationTypes
{
    public class SimulationTypesClient
    {
        private readonly Client _client;

        public SimulationTypesClient(Client client)
        {
            _client = client;
        }

        public async Task<SimulationTypeCollection> ListAsync()
        {
            var response = await _client.GetRaw("/simulation-types");
            var parser = ResponseParser.ParseResponse(response);

            return SimulationTypeCollection.From(parser.GetData());
        }
    }
} 