using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Exceptions;
using PaddleWrapper.Exceptions.ApiErrors;
using PaddleWrapper.Exceptions.SdkExceptions;
using System.Text.Json;

namespace PaddleWrapper.Resources.PaymentMethods
{
    public class PaymentMethodsClient(Client client)
    {
        public async Task<PaymentMethodCollection> ListAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetRawAsync("/payment-methods");
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonElement root = JsonDocument.Parse(jsonString).RootElement;

                if (!response.IsSuccessStatusCode)
                {
                    throw PaymentMethodApiError.FromJson(root);
                }

                JsonElement data = root.GetProperty("data");
                JsonElement meta = root.GetProperty("meta");

                Paginator paginator = new(
                    client.HttpClient,
                    Pagination.FromJson(meta),
                    typeof(PaymentMethodCollection)
                );

                return PaymentMethodCollection.FromJson(data, paginator);
            }
            catch (JsonException ex)
            {
                throw new MalformedResponse("Failed to parse API response", ex);
            }
            catch (PaymentMethodApiError)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SdkException("An unexpected error occurred", ex);
            }
        }

        public async Task<PaymentMethod> GetAsync(string id)
        {
            try
            {
                HttpResponseMessage response = await client.GetRawAsync($"/payment-methods/{id}");
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonElement root = JsonDocument.Parse(jsonString).RootElement;

                if (!response.IsSuccessStatusCode)
                {
                    throw PaymentMethodApiError.FromJson(root);
                }

                return PaymentMethod.FromJson(root.GetProperty("data"));
            }
            catch (JsonException ex)
            {
                throw new MalformedResponse("Failed to parse API response", ex);
            }
            catch (PaymentMethodApiError)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SdkException("An unexpected error occurred", ex);
            }
        }

        public async Task DeleteAsync(string id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteRawAsync($"/payment-methods/{id}");
                if (!response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    JsonElement root = JsonDocument.Parse(jsonString).RootElement;
                    throw PaymentMethodApiError.FromJson(root);
                }
            }
            catch (JsonException ex)
            {
                throw new MalformedResponse("Failed to parse API response", ex);
            }
            catch (PaymentMethodApiError)
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