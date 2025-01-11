using System.Threading.Tasks;
using PaddleWrapper.Client;
using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Exceptions;
using PaddleWrapper.Resources.Events.Operations;

namespace PaddleWrapper.Resources.Events
{
    public class EventsClient
    {
        private readonly IPaddleClient _client;

        public EventsClient(IPaddleClient client)
        {
            _client = client;
        }

        public async Task<EventCollection> ListAsync(ListEvents listOperation = null)
        {
            listOperation ??= new ListEvents();
            var response = await _client.GetRawAsync("/events", listOperation);
            var parser = new ResponseParser(response);

            return EventCollection.From(
                parser.GetData(),
                new Paginator(_client, parser.GetPagination(), typeof(EventCollection))
            );
        }
    }
} 