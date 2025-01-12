using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Resources.NotificationLogs.Operations;

namespace PaddleWrapper.Resources.NotificationLogs
{
    public class NotificationLogsClient
    {
        private readonly Client _client;

        public NotificationLogsClient(Client client)
        {
            _client = client;
        }

        public async Task<NotificationLogCollection> ListAsync(string notificationId, ListNotificationLogs listOperation = null)
        {
            listOperation ??= new ListNotificationLogs();
            var response = await _client.GetRaw($"/notifications/{notificationId}/logs", listOperation);
            ResponseParser parser = new(response);

            return NotificationLogCollection.From(
                parser.GetData(),
                new Paginator(_client, parser.GetPagination(), typeof(NotificationLogCollection))
            );
        }
    }
}