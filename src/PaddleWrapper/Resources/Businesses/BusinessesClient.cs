using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Exceptions;
using PaddleWrapper.Exceptions.ApiErrors;
using PaddleWrapper.Exceptions.SdkExceptions;
using PaddleWrapper.Resources.Businesses.Operations;
using System.Text.Json;

namespace PaddleWrapper.Resources.Businesses
{
    public class BusinessesClient
    {
        private readonly Client _client;

        public BusinessesClient(Client client)
        {
            _client = client;
        }

        public async Task<BusinessCollection> ListAsync(ListBusinesses listOperation = null)
        {
            try
            {
                listOperation ??= new ListBusinesses();
                HttpResponseMessage response = await _client.GetRawAsync("/businesses", listOperation);
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonElement jsonElement = JsonDocument.Parse(jsonString).RootElement;

                if (!response.IsSuccessStatusCode)
                {
                    throw BusinessApiError.FromJson(jsonElement);
                }

                JsonElement data = jsonElement.GetProperty("data");
                JsonElement meta = jsonElement.GetProperty("meta");

                Paginator paginator = new(
                    _client.HttpClient,
                    Pagination.FromJson(meta),
                    typeof(BusinessCollection)
                );

                return BusinessCollection.FromJson(data, paginator);
            }
            catch (JsonException ex)
            {
                throw new MalformedResponse("Failed to parse API response", ex);
            }
            catch (BusinessApiError)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SdkException("An unexpected error occurred", ex);
            }
        }

        public async Task<Business> GetAsync(string id)
        {
            try
            {
                HttpResponseMessage response = await _client.GetRawAsync($"/businesses/{id}");
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonElement root = JsonDocument.Parse(jsonString).RootElement;

                if (!response.IsSuccessStatusCode)
                {
                    throw BusinessApiError.FromJson(root);
                }

                return Business.FromJson(root.GetProperty("data"));
            }
            catch (JsonException ex)
            {
                throw new MalformedResponse("Failed to parse API response", ex);
            }
            catch (BusinessApiError)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SdkException("An unexpected error occurred", ex);
            }
        }

        public async Task<Business> CreateAsync(CreateBusiness createOperation)
        {
            try
            {
                HttpResponseMessage response = await _client.PostRawAsync("/businesses", createOperation);
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonElement root = JsonDocument.Parse(jsonString).RootElement;

                if (!response.IsSuccessStatusCode)
                {
                    throw BusinessApiError.FromJson(root);
                }

                return Business.FromJson(root.GetProperty("data"));
            }
            catch (JsonException ex)
            {
                throw new MalformedResponse("Failed to parse API response", ex);
            }
            catch (BusinessApiError)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SdkException("An unexpected error occurred", ex);
            }
        }

        public async Task<Business> UpdateAsync(string id, UpdateBusiness operation)
        {
            try
            {
                HttpResponseMessage response = await _client.PatchRawAsync($"/businesses/{id}", operation);
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonElement root = JsonDocument.Parse(jsonString).RootElement;

                if (!response.IsSuccessStatusCode)
                {
                    throw BusinessApiError.FromJson(root);
                }

                return Business.FromJson(root.GetProperty("data"));
            }
            catch (JsonException ex)
            {
                throw new MalformedResponse("Failed to parse API response", ex);
            }
            catch (BusinessApiError)
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