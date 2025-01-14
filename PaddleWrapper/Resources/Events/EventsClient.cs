using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Exceptions;
using PaddleWrapper.Exceptions.ApiErrors;
using PaddleWrapper.Exceptions.SdkExceptions;
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
            try
            {
                listOperation ??= new ListEvents();
                HttpResponseMessage response = await _client.GetRawAsync("/events", listOperation);
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonElement jsonElement = JsonDocument.Parse(jsonString).RootElement;

                if (!response.IsSuccessStatusCode)
                {
                    throw EventApiError.FromJson(jsonElement);
                }

                JsonElement data = jsonElement.GetProperty("data");
                JsonElement meta = jsonElement.GetProperty("meta");

                Paginator paginator = new(
                    _client.HttpClient,
                    Pagination.FromJson(meta),
                    typeof(EventCollection)
                );

                return EventCollection.FromJson(data, paginator);
            }
            catch (JsonException ex)
            {
                throw new MalformedResponse("Failed to parse API response", ex);
            }
            catch (EventApiError)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SdkException("An unexpected error occurred", ex);
            }
        }

        public async Task<Event> GetAsync(string id)
        {
            try
            {
                HttpResponseMessage response = await _client.GetRawAsync($"/events/{id}");
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonElement root = JsonDocument.Parse(jsonString).RootElement;

                if (!response.IsSuccessStatusCode)
                {
                    throw EventApiError.FromJson(root);
                }

                return Event.FromJson(root.GetProperty("data"));
            }
            catch (JsonException ex)
            {
                throw new MalformedResponse("Failed to parse API response", ex);
            }
            catch (EventApiError)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SdkException("An unexpected error occurred", ex);
            }
        }
    }
}