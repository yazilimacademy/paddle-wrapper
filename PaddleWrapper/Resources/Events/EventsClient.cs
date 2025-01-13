using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Resources.Events.Operations;

namespace PaddleWrapper.Resources.Events
{
    public class EventsClient
    {
        private readonly Client _client;

        public EventsClient(Client client)
        {
            _client = client;
        }

        public async Task<EventCollection> ListAsync(ListEvents listOperation = null)
        {
            listOperation ??= new ListEvents();
            var response = await _client.GetRawAsync("/events", listOperation);
            ResponseParser parser = new(response);

            return EventCollection.From(
                parser.GetData(),
                new Paginator(_client, parser.GetPagination(), typeof(EventCollection))
            );
        }
    }
}