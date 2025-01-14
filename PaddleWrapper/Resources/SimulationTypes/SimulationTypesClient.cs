using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Exceptions;
using PaddleWrapper.Exceptions.ApiErrors;
using PaddleWrapper.Exceptions.SdkExceptions;
using PaddleWrapper.Extensions;
using PaddleWrapper.Resources.SimulationTypes.Operations;
using System.Text.Json;

namespace PaddleWrapper.Resources.SimulationTypes;

public class SimulationTypesClient
{
    private readonly Client _client;

    public SimulationTypesClient(Client client)
    {
        _client = client;
    }

    public async Task<SimulationTypeCollection> ListAsync(ListSimulationTypes listOperation = null)
    {
        try
        {
            listOperation ??= new ListSimulationTypes();
            HttpResponseMessage response = await _client.GetRawAsync("/simulation-types", listOperation);
            string jsonString = await response.Content.ReadAsStringAsync();
            JsonElement jsonElement = JsonDocument.Parse(jsonString).RootElement;

            if (!response.IsSuccessStatusCode)
            {
                throw SimulationTypeApiError.FromJson(jsonElement);
            }

            JsonElement data = jsonElement.GetProperty("data");
            JsonElement meta = jsonElement.GetProperty("meta");

            Paginator paginator = new(
                _client.HttpClient,
                Pagination.FromJson(meta),
                typeof(SimulationTypeCollection)
            );

            return SimulationTypeCollection.FromJson(data, paginator);
        }
        catch (JsonException ex)
        {
            throw new MalformedResponse("Failed to parse API response", ex);
        }
        catch (SimulationTypeApiError)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new SdkException("An unexpected error occurred", ex);
        }
    }
}