using PaddleWrapper.Entities;
using PaddleWrapper.Exceptions;
using PaddleWrapper.Exceptions.ApiErrors;
using PaddleWrapper.Exceptions.SdkExceptions;
using PaddleWrapper.Resources.CustomerPortalSessions.Operations;
using System.Text.Json;

namespace PaddleWrapper.Resources.CustomerPortalSessions
{
    public class CustomerPortalSessionsClient(Client client)
    {
        public async Task<CustomerPortalSession> CreateAsync(string customerId, CreateCustomerPortalSession createOperation)
        {
            try
            {
                HttpResponseMessage response = await client.PostRawAsync($"/customers/{customerId}/portal-sessions", createOperation);
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonElement root = JsonDocument.Parse(jsonString).RootElement;

                if (!response.IsSuccessStatusCode)
                {
                    throw CustomerPortalSessionApiError.FromJson(root);
                }

                return CustomerPortalSession.FromJson(root.GetProperty("data"));
            }
            catch (JsonException ex)
            {
                throw new MalformedResponse("Failed to parse API response", ex);
            }
            catch (CustomerPortalSessionApiError)
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