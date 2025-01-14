using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Exceptions;
using PaddleWrapper.Exceptions.ApiErrors;
using PaddleWrapper.Exceptions.SdkExceptions;
using PaddleWrapper.Extensions;
using PaddleWrapper.Resources.SimulationRunEvents.Operations;
using System.Text.Json;

namespace PaddleWrapper.Resources.SimulationRunEvents;

public class SimulationRunEventsClient
{
    private readonly Client _client;

    public SimulationRunEventsClient(Client client)
    {
        _client = client;
    }

    public async Task<SimulationRunEventCollection> ListAsync(ListSimulationRunEvents listOperation = null)
    {
        try
        {
            listOperation ??= new ListSimulationRunEvents();
            HttpResponseMessage response = await _client.GetRawAsync("/simulation-run-events", listOperation);
            string jsonString = await response.Content.ReadAsStringAsync();
            JsonElement jsonElement = JsonDocument.Parse(jsonString).RootElement;

            if (!response.IsSuccessStatusCode)
            {
                throw SimulationRunEventApiError.FromJson(jsonElement);
            }

            JsonElement data = jsonElement.GetProperty("data");
            JsonElement meta = jsonElement.GetProperty("meta");

            Paginator paginator = new(
                _client.HttpClient,
                Pagination.FromJson(meta),
                typeof(SimulationRunEventCollection)
            );

            return SimulationRunEventCollection.FromJson(data, paginator);
        }
        catch (JsonException ex)
        {
            throw new MalformedResponse("Failed to parse API response", ex);
        }
        catch (SimulationRunEventApiError)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new SdkException("An unexpected error occurred", ex);
        }
    }

    public async Task<SimulationRunEvent> GetAsync(string id)
    {
        try
        {
            HttpResponseMessage response = await _client.GetRawAsync($"/simulation-run-events/{id}");
            string jsonString = await response.Content.ReadAsStringAsync();
            JsonElement root = JsonDocument.Parse(jsonString).RootElement;

            if (!response.IsSuccessStatusCode)
            {
                throw SimulationRunEventApiError.FromJson(root);
            }

            return SimulationRunEvent.FromJson(root.GetProperty("data"));
        }
        catch (JsonException ex)
        {
            throw new MalformedResponse("Failed to parse API response", ex);
        }
        catch (SimulationRunEventApiError)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new SdkException("An unexpected error occurred", ex);
        }
    }
}