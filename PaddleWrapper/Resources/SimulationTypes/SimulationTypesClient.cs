using System.Threading.Tasks;
using PaddleWrapper.Client;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Exceptions;

namespace PaddleWrapper.Resources.SimulationTypes
{
    public class SimulationTypesClient
    {
        private readonly IPaddleClient _client;

        public SimulationTypesClient(IPaddleClient client)
        {
            _client = client;
        }

        public async Task<SimulationTypeCollection> ListAsync()
        {
            var response = await _client.GetRawAsync("/simulation-types");
            var parser = new ResponseParser(response);

            return SimulationTypeCollection.From(parser.GetData());
        }
    }
} 