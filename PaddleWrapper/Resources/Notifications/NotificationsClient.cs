using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Extensions;
using PaddleWrapper.Resources.Notifications.Operations;
using System.Text.Json;

namespace PaddleWrapper.Resources.Notifications
{
    public class NotificationsClient
    {
        private readonly Client _client;

        public NotificationsClient(Client client)
        {
            _client = client;
        }

        public async Task<NotificationCollection> ListAsync(ListNotifications listOperation = null)
        {
            listOperation ??= new ListNotifications();
            HttpResponseMessage response = await _client.GetRawAsync("/notifications", listOperation);
            JsonElement jsonElement = JsonDocument.Parse(await response.Content.ReadAsStringAsync()).RootElement;
            JsonElement data = jsonElement.GetProperty("data");
            JsonElement meta = jsonElement.GetProperty("meta");

            Paginator paginator = new(
                _client.HttpClient,
                Pagination.FromJson(meta),
                typeof(NotificationCollection)
            );

            return NotificationCollection.FromJson(data, paginator);
        }

        public async Task<Notification> GetAsync(string id)
        {
            JsonDocument response = await _client.Get($"/notifications/{id}");
            return Notification.FromJson(response.RootElement.GetProperty("data"));
        }

        public async Task<string> ReplayAsync(string id)
        {
            JsonDocument response = await _client.Post($"/notifications/{id}/replay", null);
            return response.RootElement.GetProperty("data").GetProperty("notification_id").GetString() ?? string.Empty;
        }
    }
}