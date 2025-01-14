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
    public class BusinessesClient(Client client)
    {
        public async Task<BusinessCollection> ListAsync(string customerId, ListBusinesses listOperation = null)
        {
            try
            {
                listOperation ??= new ListBusinesses();
                HttpResponseMessage response = await client.GetRawAsync($"/customers/{customerId}/businesses", listOperation);
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonElement jsonElement = JsonDocument.Parse(jsonString).RootElement;

                if (!response.IsSuccessStatusCode)
                {
                    throw BusinessApiError.FromJson(jsonElement);
                }

                JsonElement data = jsonElement.GetProperty("data");
                JsonElement meta = jsonElement.GetProperty("meta");

                Paginator paginator = new(
                    client.HttpClient,
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

        public async Task<Business> GetAsync(string customerId, string id)
        {
            try
            {
                HttpResponseMessage response = await client.GetRawAsync($"/customers/{customerId}/businesses/{id}");
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

        public async Task<Business> CreateAsync(string customerId, CreateBusiness createOperation)
        {
            try
            {
                HttpResponseMessage response = await client.PostRawAsync($"/customers/{customerId}/businesses", createOperation);
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

        public async Task<Business> UpdateAsync(string customerId, string id, UpdateBusiness operation)
        {
            try
            {
                HttpResponseMessage response = await client.PatchRawAsync($"/customers/{customerId}/businesses/{id}", operation);
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

        public async Task<Business> ArchiveAsync(string customerId, string id)
        {
            return await UpdateAsync(customerId, id, new UpdateBusiness { Status = Status.Archived });
        }
    }
}