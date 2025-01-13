using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Resources.NotificationSettings.Operations;

namespace PaddleWrapper.Resources.NotificationSettings
{
    public class NotificationSettingsClient
    {
        private readonly Client _client;

        public NotificationSettingsClient(Client client)
        {
            _client = client;
        }

        public async Task<NotificationSettingCollection> ListAsync(ListNotificationSettings listOperation = null)
        {
            listOperation ??= new ListNotificationSettings();
            var response = await _client.GetRawAsync("notification-settings", listOperation);
            ResponseParser parser = new(response);

            return NotificationSettingCollection.From(
                parser.GetData(),
                new Paginator(_client, parser.GetPagination(), typeof(NotificationSettingCollection))
            );
        }

        public async Task<NotificationSetting> GetAsync(string id)
        {
            HttpResponseMessage response = await _client.GetRawAsync($"notification-settings/{id}");
            ResponseParser parser = new(response);

            return NotificationSetting.From(parser.GetData());
        }

        public async Task<NotificationSetting> CreateAsync(CreateNotificationSetting createOperation)
        {
            var response = await _client.PostRawAsync("notification-settings", createOperation);
            ResponseParser parser = new(response);

            return NotificationSetting.From(parser.GetData());
        }

        public async Task<NotificationSetting> UpdateAsync(string id, UpdateNotificationSetting operation)
        {
            var response = await _client.PatchRawAsync($"notification-settings/{id}", operation);
            ResponseParser parser = new(response);

            return NotificationSetting.From(parser.GetData());
        }

        public async Task DeleteAsync(string id)
        {
            HttpResponseMessage response = await _client.DeleteRawAsync($"notification-settings/{id}");
            _ = new ResponseParser(response);
        }
    }
}