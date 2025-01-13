using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Extensions;
using System.Text.Json;

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
            JsonDocument response = await _client.Get("/event-types");
            return EventTypeCollection.FromJson(response.RootElement.GetProperty("data"), null);
        }
    }
}