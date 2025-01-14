using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Exceptions;
using PaddleWrapper.Exceptions.ApiErrors;
using PaddleWrapper.Exceptions.SdkExceptions;
using PaddleWrapper.Resources.SimulationRuns.Operations;
using System.Text.Json;

namespace PaddleWrapper.Resources.SimulationRuns
{
    public class SimulationRunsClient(Client client)
    {
        public async Task<SimulationRunCollection> ListAsync(string simulationId, ListSimulationRuns listOperation = null)
        {
            try
            {
                listOperation ??= new ListSimulationRuns(simulationId);
                HttpResponseMessage response = await client.GetRawAsync($"/simulations/{simulationId}/runs", listOperation);
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonElement root = JsonDocument.Parse(jsonString).RootElement;

                if (!response.IsSuccessStatusCode)
                {
                    throw SimulationRunApiError.FromJson(root);
                }

                JsonElement data = root.GetProperty("data");
                JsonElement meta = root.GetProperty("meta");

                Paginator paginator = new(
                    client.HttpClient,
                    Pagination.FromJson(meta),
                    typeof(SimulationRunCollection)
                );

                return SimulationRunCollection.FromJson(data, paginator);
            }
            catch (JsonException ex)
            {
                throw new MalformedResponse("Failed to parse API response", ex);
            }
            catch (SimulationRunApiError)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SdkException("An unexpected error occurred", ex);
            }
        }

        public async Task<SimulationRun> GetAsync(string simulationId, string id, GetSimulationRuns getOperation = null)
        {
            try
            {
                getOperation ??= new GetSimulationRuns(simulationId, id);
                HttpResponseMessage response = await client.GetRawAsync($"/simulations/{simulationId}/runs/{id}", getOperation);
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonElement root = JsonDocument.Parse(jsonString).RootElement;

                if (!response.IsSuccessStatusCode)
                {
                    throw SimulationRunApiError.FromJson(root);
                }

                return SimulationRun.FromJson(root.GetProperty("data"));
            }
            catch (JsonException ex)
            {
                throw new MalformedResponse("Failed to parse API response", ex);
            }
            catch (SimulationRunApiError)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SdkException("An unexpected error occurred", ex);
            }
        }

        public async Task<SimulationRun> CreateAsync(string simulationId)
        {
            try
            {
                CreateSimulationRun createOperation = new(simulationId);
                HttpResponseMessage response = await client.PostRawAsync($"/simulations/{simulationId}/runs", createOperation);
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonElement root = JsonDocument.Parse(jsonString).RootElement;

                if (!response.IsSuccessStatusCode)
                {
                    throw SimulationRunApiError.FromJson(root);
                }

                return SimulationRun.FromJson(root.GetProperty("data"));
            }
            catch (JsonException ex)
            {
                throw new MalformedResponse("Failed to parse API response", ex);
            }
            catch (SimulationRunApiError)
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