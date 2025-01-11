using System.Threading.Tasks;
using PaddleWrapper.Client;
using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Exceptions;
using PaddleWrapper.Resources.NotificationSettings.Operations;

namespace PaddleWrapper.Resources.NotificationSettings
{
    public class NotificationSettingsClient
    {
        private readonly IPaddleClient _client;

        public NotificationSettingsClient(IPaddleClient client)
        {
            _client = client;
        }

        public async Task<NotificationSettingCollection> ListAsync(ListNotificationSettings listOperation = null)
        {
            listOperation ??= new ListNotificationSettings();
            var response = await _client.GetRawAsync("notification-settings", listOperation);
            var parser = new ResponseParser(response);

            return NotificationSettingCollection.From(
                parser.GetData(),
                new Paginator(_client, parser.GetPagination(), typeof(NotificationSettingCollection))
            );
        }

        public async Task<NotificationSetting> GetAsync(string id)
        {
            var response = await _client.GetRawAsync($"notification-settings/{id}");
            var parser = new ResponseParser(response);

            return NotificationSetting.From(parser.GetData());
        }

        public async Task<NotificationSetting> CreateAsync(CreateNotificationSetting createOperation)
        {
            var response = await _client.PostRawAsync("notification-settings", createOperation);
            var parser = new ResponseParser(response);

            return NotificationSetting.From(parser.GetData());
        }

        public async Task<NotificationSetting> UpdateAsync(string id, UpdateNotificationSetting operation)
        {
            var response = await _client.PatchRawAsync($"notification-settings/{id}", operation);
            var parser = new ResponseParser(response);

            return NotificationSetting.From(parser.GetData());
        }

        public async Task DeleteAsync(string id)
        {
            var response = await _client.DeleteRawAsync($"notification-settings/{id}");
            _ = new ResponseParser(response);
        }
    }
} 