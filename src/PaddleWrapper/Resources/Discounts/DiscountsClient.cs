using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Exceptions;
using PaddleWrapper.Exceptions.ApiErrors;
using PaddleWrapper.Exceptions.SdkExceptions;
using PaddleWrapper.Resources.Discounts.Operations;
using System.Text.Json;

namespace PaddleWrapper.Resources.Discounts
{
    public class DiscountsClient(Client client)
    {
        public async Task<DiscountCollection> ListAsync(ListDiscounts listOperation = null)
        {
            try
            {
                listOperation ??= new ListDiscounts();
                HttpResponseMessage response = await client.GetRawAsync("/discounts", listOperation);
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonElement jsonElement = JsonDocument.Parse(jsonString).RootElement;

                if (!response.IsSuccessStatusCode)
                {
                    throw DiscountApiError.FromJson(jsonElement);
                }

                JsonElement data = jsonElement.GetProperty("data");
                JsonElement meta = jsonElement.GetProperty("meta");

                Paginator paginator = new(
                    client.HttpClient,
                    Pagination.FromJson(meta),
                    typeof(DiscountCollection)
                );

                return DiscountCollection.FromJson(data, paginator);
            }
            catch (JsonException ex)
            {
                throw new MalformedResponse("Failed to parse API response", ex);
            }
            catch (DiscountApiError)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SdkException("An unexpected error occurred", ex);
            }
        }

        public async Task<Discount> GetAsync(string id)
        {
            try
            {
                HttpResponseMessage response = await client.GetRawAsync($"/discounts/{id}");
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonElement root = JsonDocument.Parse(jsonString).RootElement;

                if (!response.IsSuccessStatusCode)
                {
                    throw DiscountApiError.FromJson(root);
                }

                return Discount.FromJson(root.GetProperty("data"));
            }
            catch (JsonException ex)
            {
                throw new MalformedResponse("Failed to parse API response", ex);
            }
            catch (DiscountApiError)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SdkException("An unexpected error occurred", ex);
            }
        }

        public async Task<Discount> CreateAsync(CreateDiscount createOperation)
        {
            try
            {
                HttpResponseMessage response = await client.PostRawAsync("/discounts", createOperation);
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonElement root = JsonDocument.Parse(jsonString).RootElement;

                if (!response.IsSuccessStatusCode)
                {
                    throw DiscountApiError.FromJson(root);
                }

                return Discount.FromJson(root.GetProperty("data"));
            }
            catch (JsonException ex)
            {
                throw new MalformedResponse("Failed to parse API response", ex);
            }
            catch (DiscountApiError)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SdkException("An unexpected error occurred", ex);
            }
        }

        public async Task<Discount> UpdateAsync(string id, UpdateDiscount operation)
        {
            try
            {
                HttpResponseMessage response = await client.PatchRawAsync($"/discounts/{id}", operation);
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonElement root = JsonDocument.Parse(jsonString).RootElement;

                if (!response.IsSuccessStatusCode)
                {
                    throw DiscountApiError.FromJson(root);
                }

                return Discount.FromJson(root.GetProperty("data"));
            }
            catch (JsonException ex)
            {
                throw new MalformedResponse("Failed to parse API response", ex);
            }
            catch (DiscountApiError)
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