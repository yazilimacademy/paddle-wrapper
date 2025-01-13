using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Extensions;
using PaddleWrapper.Resources.NotificationSettings.Operations;
using System.Text.Json;

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
            HttpResponseMessage response = await _client.GetRawAsync("notification-settings", listOperation);
            JsonElement jsonElement = JsonDocument.Parse(await response.Content.ReadAsStringAsync()).RootElement;
            JsonElement data = jsonElement.GetProperty("data");
            JsonElement meta = jsonElement.GetProperty("meta");

            Paginator paginator = new(
                _client.HttpClient,
                Pagination.FromJson(meta),
                typeof(NotificationSettingCollection)
            );

            return NotificationSettingCollection.FromJson(data, paginator);
        }

        public async Task<NotificationSetting> GetAsync(string id)
        {
            JsonDocument response = await _client.Get($"notification-settings/{id}");
            return NotificationSetting.FromJson(response.RootElement.GetProperty("data"));
        }

        public async Task<NotificationSetting> CreateAsync(CreateNotificationSetting createOperation)
        {
            JsonDocument response = await _client.Post("notification-settings", createOperation);
            return NotificationSetting.FromJson(response.RootElement.GetProperty("data"));
        }

        public async Task<NotificationSetting> UpdateAsync(string id, UpdateNotificationSetting operation)
        {
            JsonDocument response = await _client.Patch($"notification-settings/{id}", operation);
            return NotificationSetting.FromJson(response.RootElement.GetProperty("data"));
        }

        public async Task DeleteAsync(string id)
        {
            await _client.DeleteRawAsync($"notification-settings/{id}");
        }
    }
}