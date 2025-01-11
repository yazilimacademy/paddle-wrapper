using System.Threading.Tasks;
using PaddleWrapper.Client;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Exceptions;
using PaddleWrapper.Resources.NotificationLogs.Operations;

namespace PaddleWrapper.Resources.NotificationLogs
{
    public class NotificationLogsClient
    {
        private readonly IPaddleClient _client;

        public NotificationLogsClient(IPaddleClient client)
        {
            _client = client;
        }

        public async Task<NotificationLogCollection> ListAsync(string notificationId, ListNotificationLogs listOperation = null)
        {
            listOperation ??= new ListNotificationLogs();
            var response = await _client.GetRawAsync($"/notifications/{notificationId}/logs", listOperation);
            var parser = new ResponseParser(response);

            return NotificationLogCollection.From(
                parser.GetData(),
                new Paginator(_client, parser.GetPagination(), typeof(NotificationLogCollection))
            );
        }
    }
} 