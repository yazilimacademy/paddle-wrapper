using PaddleWrapper.Entities;
using PaddleWrapper.Resources.CustomerPortalSessions.Operations;

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
            var response = await _client.PostRawAsync($"/customers/{customerId}/portal-sessions", createOperation);
            ResponseParser parser = new(response);

            return CustomerPortalSession.From(parser.GetData());
        }
    }
}