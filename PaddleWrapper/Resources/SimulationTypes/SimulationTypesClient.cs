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
            HttpResponseMessage response = await _client.GetRawAsync("/simulation-types");
            SimulationTypeCollection data = await ResponseParser.ParseResponse<SimulationTypeCollection>(response);
            return data;
        }
    }
}