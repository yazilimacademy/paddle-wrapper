using System.Threading.Tasks;
using PaddleWrapper.Client;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Exceptions;

namespace PaddleWrapper.Resources.EventTypes
{
    public class EventTypesClient
    {
        private readonly IPaddleClient _client;

        public EventTypesClient(IPaddleClient client)
        {
            _client = client;
        }

        public async Task<EventTypeCollection> ListAsync()
        {
            var response = await _client.GetRawAsync("/event-types");
            var parser = new ResponseParser(response);

            return EventTypeCollection.From(parser.GetData());
        }
    }
} 