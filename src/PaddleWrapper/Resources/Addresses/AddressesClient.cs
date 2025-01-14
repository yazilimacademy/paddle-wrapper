using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Exceptions;
using PaddleWrapper.Exceptions.ApiErrors;
using PaddleWrapper.Exceptions.SdkExceptions;
using PaddleWrapper.Resources.Addresses.Operations;
using System.Text.Json;

namespace PaddleWrapper.Resources.Addresses
{
    public class AddressesClient(Client client)
    {
        public async Task<AddressCollection> ListAsync(string customerId, ListAddresses listOperation = null)
        {
            try
            {
                listOperation ??= new ListAddresses();
                HttpResponseMessage response = await client.GetRawAsync($"/customers/{customerId}/addresses", listOperation);
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonElement jsonElement = JsonDocument.Parse(jsonString).RootElement;

                if (!response.IsSuccessStatusCode)
                {
                    throw AddressApiError.FromJson(jsonElement);
                }

                JsonElement data = jsonElement.GetProperty("data");
                JsonElement meta = jsonElement.GetProperty("meta");

                Paginator paginator = new(
                    client.HttpClient,
                    Pagination.FromJson(meta),
                    typeof(AddressCollection)
                );

                return AddressCollection.FromJson(data, paginator);
            }
            catch (JsonException ex)
            {
                throw new MalformedResponse("Failed to parse API response", ex);
            }
            catch (AddressApiError)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SdkException("An unexpected error occurred", ex);
            }
        }

        public async Task<Address> GetAsync(string customerId, string id)
        {
            try
            {
                HttpResponseMessage response = await client.GetRawAsync($"/customers/{customerId}/addresses/{id}");
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonElement root = JsonDocument.Parse(jsonString).RootElement;

                if (!response.IsSuccessStatusCode)
                {
                    throw AddressApiError.FromJson(root);
                }

                return Address.FromJson(root.GetProperty("data"));
            }
            catch (JsonException ex)
            {
                throw new MalformedResponse("Failed to parse API response", ex);
            }
            catch (AddressApiError)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SdkException("An unexpected error occurred", ex);
            }
        }

        public async Task<Address> CreateAsync(string customerId, CreateAddress createOperation)
        {
            try
            {
                HttpResponseMessage response = await client.PostRawAsync($"/customers/{customerId}/addresses", createOperation);
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonElement root = JsonDocument.Parse(jsonString).RootElement;

                if (!response.IsSuccessStatusCode)
                {
                    throw AddressApiError.FromJson(root);
                }

                return Address.FromJson(root.GetProperty("data"));
            }
            catch (JsonException ex)
            {
                throw new MalformedResponse("Failed to parse API response", ex);
            }
            catch (AddressApiError)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SdkException("An unexpected error occurred", ex);
            }
        }

        public async Task<Address> UpdateAsync(string customerId, string id, UpdateAddress operation)
        {
            try
            {
                HttpResponseMessage response = await client.PatchRawAsync($"/customers/{customerId}/addresses/{id}", operation);
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonElement root = JsonDocument.Parse(jsonString).RootElement;

                if (!response.IsSuccessStatusCode)
                {
                    throw AddressApiError.FromJson(root);
                }

                return Address.FromJson(root.GetProperty("data"));
            }
            catch (JsonException ex)
            {
                throw new MalformedResponse("Failed to parse API response", ex);
            }
            catch (AddressApiError)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SdkException("An unexpected error occurred", ex);
            }
        }

        public async Task<Address> ArchiveAsync(string customerId, string id)
        {
            return await UpdateAsync(customerId, id, new UpdateAddress { Status = Status.Archived });
        }
    }
}