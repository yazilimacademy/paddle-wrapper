using PaddleWrapper.Entities;
using PaddleWrapper.Extensions;
using PaddleWrapper.Resources.CustomerPortalSessions.Operations;
using System.Text.Json;

namespace PaddleWrapper.Resources.CustomerPortalSessions
{
    public class CustomerPortalSessionsClient
    {
        private readonly Client _client;

        public CustomerPortalSessionsClient(Client client)
        {
            _client = client;
        }

        public async Task<CustomerPortalSession> CreateAsync(string customerId, CreateCustomerPortalSession createOperation)
        {
            JsonDocument response = await _client.Post($"/customers/{customerId}/portal-sessions", createOperation);
            return CustomerPortalSession.FromJson(response.RootElement.GetProperty("data"));
        }
    }
}