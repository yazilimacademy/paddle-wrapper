using System.Threading.Tasks;
using PaddleWrapper.Client;
using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Exceptions;
using PaddleWrapper.Resources.Notifications.Operations;

namespace PaddleWrapper.Resources.Notifications
{
    public class NotificationsClient
    {
        private readonly IPaddleClient _client;

        public NotificationsClient(IPaddleClient client)
        {
            _client = client;
        }

        public async Task<NotificationCollection> ListAsync(ListNotifications listOperation = null)
        {
            listOperation ??= new ListNotifications();
            var response = await _client.GetRawAsync("/notifications", listOperation);
            var parser = new ResponseParser(response);

            return NotificationCollection.From(
                parser.GetData(),
                new Paginator(_client, parser.GetPagination(), typeof(NotificationCollection))
            );
        }

        public async Task<Notification> GetAsync(string id)
        {
            var response = await _client.GetRawAsync($"/notifications/{id}");
            var parser = new ResponseParser(response);

            return Notification.From(parser.GetData());
        }

        public async Task<string> ReplayAsync(string id)
        {
            var response = await _client.PostRawAsync($"/notifications/{id}/replay", null);
            var parser = new ResponseParser(response);
            var data = parser.GetData();

            return data.GetProperty("notification_id").GetString() ?? string.Empty;
        }
    }
} 