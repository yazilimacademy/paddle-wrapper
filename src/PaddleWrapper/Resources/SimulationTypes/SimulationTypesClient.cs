using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Exceptions;
using PaddleWrapper.Exceptions.ApiErrors;
using PaddleWrapper.Exceptions.SdkExceptions;
using PaddleWrapper.Resources.SimulationTypes.Operations;
using System.Text.Json;

namespace PaddleWrapper.Resources.SimulationTypes
{
    public class SimulationTypesClient(Client client)
    {
        public async Task<SimulationTypeCollection> ListAsync(ListSimulationTypes listOperation = null)
        {
            try
            {
                HttpResponseMessage response = await client.GetRawAsync("/simulation-types", listOperation);
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonElement root = JsonDocument.Parse(jsonString).RootElement;

                if (!response.IsSuccessStatusCode)
                {
                    throw SimulationTypeApiError.FromJson(root);
                }

                JsonElement data = root.GetProperty("data");
                JsonElement meta = root.GetProperty("meta");

                Paginator paginator = new(
                    client.HttpClient,
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
}