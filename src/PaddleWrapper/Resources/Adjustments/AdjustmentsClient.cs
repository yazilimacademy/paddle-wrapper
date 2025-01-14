using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Exceptions;
using PaddleWrapper.Exceptions.ApiErrors;
using PaddleWrapper.Exceptions.SdkExceptions;
using PaddleWrapper.Resources.Adjustments.Operations;
using System.Text.Json;

namespace PaddleWrapper.Resources.Adjustments
{
    public class AdjustmentsClient
    {
        private readonly Client _client;

        public AdjustmentsClient(Client client)
        {
            _client = client;
        }

        public async Task<AdjustmentCollection> ListAsync(ListAdjustments listOperation = null)
        {
            try
            {
                listOperation ??= new ListAdjustments();
                HttpResponseMessage response = await _client.GetRawAsync("/adjustments", listOperation);
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonElement jsonElement = JsonDocument.Parse(jsonString).RootElement;

                if (!response.IsSuccessStatusCode)
                {
                    throw AdjustmentApiError.FromJson(jsonElement);
                }

                JsonElement data = jsonElement.GetProperty("data");
                JsonElement meta = jsonElement.GetProperty("meta");

                Paginator paginator = new(
                    _client.HttpClient,
                    Pagination.FromJson(meta),
                    typeof(AdjustmentCollection)
                );

                return AdjustmentCollection.FromJson(data, paginator);
            }
            catch (JsonException ex)
            {
                throw new MalformedResponse("Failed to parse API response", ex);
            }
            catch (AdjustmentApiError)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SdkException("An unexpected error occurred", ex);
            }
        }

        public async Task<Adjustment> GetAsync(string id)
        {
            try
            {
                HttpResponseMessage response = await _client.GetRawAsync($"/adjustments/{id}");
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonElement root = JsonDocument.Parse(jsonString).RootElement;

                if (!response.IsSuccessStatusCode)
                {
                    throw AdjustmentApiError.FromJson(root);
                }

                return Adjustment.FromJson(root.GetProperty("data"));
            }
            catch (JsonException ex)
            {
                throw new MalformedResponse("Failed to parse API response", ex);
            }
            catch (AdjustmentApiError)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SdkException("An unexpected error occurred", ex);
            }
        }

        public async Task<Adjustment> CreateAsync(CreateAdjustment createOperation)
        {
            try
            {
                HttpResponseMessage response = await _client.PostRawAsync("/adjustments", createOperation);
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonElement root = JsonDocument.Parse(jsonString).RootElement;

                if (!response.IsSuccessStatusCode)
                {
                    throw AdjustmentApiError.FromJson(root);
                }

                return Adjustment.FromJson(root.GetProperty("data"));
            }
            catch (JsonException ex)
            {
                throw new MalformedResponse("Failed to parse API response", ex);
            }
            catch (AdjustmentApiError)
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