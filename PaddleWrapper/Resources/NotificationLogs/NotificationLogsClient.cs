using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Resources.NotificationLogs.Operations;
using System.Text.Json;

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
            HttpResponseMessage response = await _client.GetRawAsync($"/notifications/{notificationId}/logs", listOperation);
            JsonElement jsonElement = JsonDocument.Parse(await response.Content.ReadAsStringAsync()).RootElement;
            JsonElement data = jsonElement.GetProperty("data");
            JsonElement meta = jsonElement.GetProperty("meta");

            Paginator paginator = new(
                _client.HttpClient,
                Pagination.FromJson(meta),
                typeof(NotificationLogCollection)
            );

            return NotificationLogCollection.FromJson(data, paginator);
        }
    }
}