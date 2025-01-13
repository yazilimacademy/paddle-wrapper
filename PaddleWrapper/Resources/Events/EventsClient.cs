using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Resources.Events.Operations;
using System.Text.Json;

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
            HttpResponseMessage response = await _client.GetRawAsync("/events", listOperation);
            JsonElement jsonElement = JsonDocument.Parse(await response.Content.ReadAsStringAsync()).RootElement;
            JsonElement data = jsonElement.GetProperty("data");
            JsonElement meta = jsonElement.GetProperty("meta");

            Paginator paginator = new(
                _client.HttpClient,
                Pagination.FromJson(meta),
                typeof(EventCollection)
            );

            return EventCollection.FromJson(data, paginator);
        }
    }
}