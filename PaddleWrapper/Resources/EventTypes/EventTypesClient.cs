using PaddleWrapper.Entities.Collections;

namespace PaddleWrapper.Resources.EventTypes
{
    public class EventTypesClient
    {
        private readonly Client _client;

        public EventTypesClient(Client client)
        {
            _client = client;
        }

        public async Task<EventTypeCollection> ListAsync()
        {
            HttpResponseMessage response = await _client.GetRaw("/event-types");
            ResponseParser parser = new(response);

            return EventTypeCollection.From(parser.GetData());
        }
    }
}