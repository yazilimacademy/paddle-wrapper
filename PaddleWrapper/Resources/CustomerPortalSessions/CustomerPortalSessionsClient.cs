using System.Threading.Tasks;
using PaddleWrapper.Client;
using PaddleWrapper.Entities;
using PaddleWrapper.Exceptions;
using PaddleWrapper.Resources.CustomerPortalSessions.Operations;

namespace PaddleWrapper.Resources.CustomerPortalSessions
{
    public class CustomerPortalSessionsClient
    {
        private readonly IPaddleClient _client;

        public CustomerPortalSessionsClient(IPaddleClient client)
        {
            _client = client;
        }

        public async Task<CustomerPortalSession> CreateAsync(string customerId, CreateCustomerPortalSession createOperation)
        {
            var response = await _client.PostRawAsync($"/customers/{customerId}/portal-sessions", createOperation);
            var parser = new ResponseParser(response);

            return CustomerPortalSession.From(parser.GetData());
        }
    }
} 