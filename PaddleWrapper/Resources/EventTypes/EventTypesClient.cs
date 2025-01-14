using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Exceptions;
using PaddleWrapper.Exceptions.ApiErrors;
using PaddleWrapper.Exceptions.SdkExceptions;
using PaddleWrapper.Extensions;
using PaddleWrapper.Resources.EventTypes.Operations;
using System.Text.Json;

namespace PaddleWrapper.Resources.EventTypes;

public class EventTypesClient
{
    private readonly Client _client;

    public EventTypesClient(Client client)
    {
        _client = client;
    }

    public async Task<EventTypeCollection> ListAsync(ListEventTypes listOperation = null)
    {
        try
        {
            listOperation ??= new ListEventTypes();
            HttpResponseMessage response = await _client.GetRawAsync("/event-types", listOperation);
            string jsonString = await response.Content.ReadAsStringAsync();
            JsonElement jsonElement = JsonDocument.Parse(jsonString).RootElement;

            if (!response.IsSuccessStatusCode)
            {
                throw EventTypeApiError.FromJson(jsonElement);
            }

            JsonElement data = jsonElement.GetProperty("data");
            JsonElement meta = jsonElement.GetProperty("meta");

            Paginator paginator = new(
                _client.HttpClient,
                Pagination.FromJson(meta),
                typeof(EventTypeCollection)
            );

            return EventTypeCollection.FromJson(data, paginator);
        }
        catch (JsonException ex)
        {
            throw new MalformedResponse("Failed to parse API response", ex);
        }
        catch (EventTypeApiError)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new SdkException("An unexpected error occurred", ex);
        }
    }

    public async Task<EventType> GetAsync(string name)
    {
        try
        {
            HttpResponseMessage response = await _client.GetRawAsync($"/event-types/{name}");
            string jsonString = await response.Content.ReadAsStringAsync();
            JsonElement root = JsonDocument.Parse(jsonString).RootElement;

            if (!response.IsSuccessStatusCode)
            {
                throw EventTypeApiError.FromJson(root);
            }

            return EventType.FromJson(root.GetProperty("data"));
        }
        catch (JsonException ex)
        {
            throw new MalformedResponse("Failed to parse API response", ex);
        }
        catch (EventTypeApiError)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new SdkException("An unexpected error occurred", ex);
        }
    }
}