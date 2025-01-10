using System.Text.Json;
using System.Threading.Tasks;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Entities.Notifications;

namespace PaddleWrapper.Clients
{
    public class NotificationsClient
    {
        private readonly PaddleClient _paddleClient;

        public NotificationsClient(PaddleClient paddleClient)
        {
            _paddleClient = paddleClient;
        }

        public async Task<NotificationCollection> ListNotificationsAsync()
        {
            var response = await _paddleClient.SendRequestAsync("notifications/list", new { });
            return NotificationCollection.FromList(response.EnumerateArray());
        }

        public async Task<Notification> GetNotificationAsync(string notificationId)
        {
            var response = await _paddleClient.SendRequestAsync($"notifications/{notificationId}", new { });
            return Notification.FromDict(response);
        }

        public async Task<string> ReplayNotificationAsync(string notificationId)
        {
            var response = await _paddleClient.SendRequestAsync($"notifications/{notificationId}/replay", new { });
            return response.GetProperty("notification_id").GetString();
        }
    }
} 