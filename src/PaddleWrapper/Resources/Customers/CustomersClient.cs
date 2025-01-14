using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Exceptions;
using PaddleWrapper.Exceptions.ApiErrors;
using PaddleWrapper.Exceptions.SdkExceptions;
using PaddleWrapper.Extensions;
using PaddleWrapper.Resources.Customers.Operations;
using System.Text.Json;

namespace PaddleWrapper.Resources.Customers
{
    public class CustomersClient(Client client)
    {
        public async Task<CustomerCollection> ListAsync(ListCustomers listOperation = null)
        {
            try
            {
                listOperation ??= new ListCustomers();
                HttpResponseMessage response = await client.GetRawAsync("/customers", listOperation);
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonElement jsonElement = JsonDocument.Parse(jsonString).RootElement;

                if (!response.IsSuccessStatusCode)
                {
                    throw CustomerApiError.FromJson(jsonElement);
                }

                JsonElement data = jsonElement.GetProperty("data");
                JsonElement meta = jsonElement.GetProperty("meta");

                Paginator paginator = new(
                    client.HttpClient,
                    Pagination.FromJson(meta),
                    typeof(CustomerCollection)
                );

                return CustomerCollection.FromJson(data, paginator);
            }
            catch (JsonException ex)
            {
                throw new MalformedResponse("Failed to parse API response", ex);
            }
            catch (CustomerApiError)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SdkException("An unexpected error occurred", ex);
            }
        }

        public async Task<Customer> GetAsync(string id)
        {
            try
            {
                HttpResponseMessage response = await client.GetRawAsync($"/customers/{id}");
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonElement root = JsonDocument.Parse(jsonString).RootElement;

                if (!response.IsSuccessStatusCode)
                {
                    throw CustomerApiError.FromJson(root);
                }

                return Customer.FromJson(root.GetProperty("data"));
            }
            catch (JsonException ex)
            {
                throw new MalformedResponse("Failed to parse API response", ex);
            }
            catch (CustomerApiError)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SdkException("An unexpected error occurred", ex);
            }
        }

        public async Task<Customer> CreateAsync(CreateCustomer createOperation)
        {
            try
            {
                HttpResponseMessage response = await client.PostRawAsync("/customers", createOperation);
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonElement root = JsonDocument.Parse(jsonString).RootElement;

                if (!response.IsSuccessStatusCode)
                {
                    throw CustomerApiError.FromJson(root);
                }

                return Customer.FromJson(root.GetProperty("data"));
            }
            catch (JsonException ex)
            {
                throw new MalformedResponse("Failed to parse API response", ex);
            }
            catch (CustomerApiError)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SdkException("An unexpected error occurred", ex);
            }
        }

        public async Task<Customer> UpdateAsync(string id, UpdateCustomer operation)
        {
            try
            {
                HttpResponseMessage response = await client.PatchRawAsync($"/customers/{id}", operation);
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonElement root = JsonDocument.Parse(jsonString).RootElement;

                if (!response.IsSuccessStatusCode)
                {
                    throw CustomerApiError.FromJson(root);
                }

                return Customer.FromJson(root.GetProperty("data"));
            }
            catch (JsonException ex)
            {
                throw new MalformedResponse("Failed to parse API response", ex);
            }
            catch (CustomerApiError)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SdkException("An unexpected error occurred", ex);
            }
        }

        public async Task<Customer> ArchiveAsync(string id)
        {
            return await UpdateAsync(id, new UpdateCustomer { Status = Status.Archived });
        }

        public async Task<CreditBalanceCollection> GetCreditBalancesAsync(string id, ListCreditBalances operation = null)
        {
            operation ??= new ListCreditBalances();
            JsonDocument response = await client.Get($"/customers/{id}/credit-balances", operation);
            return CreditBalanceCollection.FromJson(response.RootElement.GetProperty("data"), null);
        }

        public async Task<CustomerAuthToken> GenerateAuthTokenAsync(string id)
        {
            JsonDocument response = await client.Post($"/customers/{id}/auth-token", null);
            return CustomerAuthToken.FromJson(response.RootElement.GetProperty("data"));
        }
    }
}