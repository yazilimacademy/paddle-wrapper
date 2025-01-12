using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Resources.Notifications.Operations;

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
            var response = await _client.GetRaw("/notifications", listOperation);
            ResponseParser parser = new(response);

            return NotificationCollection.From(
                parser.GetData(),
                new Paginator(_client, parser.GetPagination(), typeof(NotificationCollection))
            );
        }

        public async Task<Notification> GetAsync(string id)
        {
            HttpResponseMessage response = await _client.GetRaw($"/notifications/{id}");
            ResponseParser parser = new(response);

            return Notification.From(parser.GetData());
        }

        public async Task<string> ReplayAsync(string id)
        {
            var response = await _client.PostRawAsync($"/notifications/{id}/replay", null);
            ResponseParser parser = new(response);
            var data = parser.GetData();

            return data.GetProperty("notification_id").GetString() ?? string.Empty;
        }
    }
}