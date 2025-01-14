using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Exceptions;
using PaddleWrapper.Exceptions.ApiErrors;
using PaddleWrapper.Exceptions.SdkExceptions;
using PaddleWrapper.Resources.NotificationSettings.Operations;
using System.Text.Json;

namespace PaddleWrapper.Resources.NotificationSettings
{
    public class NotificationSettingsClient(Client client)
    {
        public async Task<NotificationSettingCollection> ListAsync(ListNotificationSettings listOperation = null)
        {
            try
            {
                listOperation ??= new ListNotificationSettings();
                HttpResponseMessage response = await client.GetRawAsync("/notification-settings", listOperation);
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonElement jsonElement = JsonDocument.Parse(jsonString).RootElement;

                if (!response.IsSuccessStatusCode)
                {
                    throw NotificationSettingApiError.FromJson(jsonElement);
                }

                JsonElement data = jsonElement.GetProperty("data");
                JsonElement meta = jsonElement.GetProperty("meta");

                Paginator paginator = new(
                    client.HttpClient,
                    Pagination.FromJson(meta),
                    typeof(NotificationSettingCollection)
                );

                return NotificationSettingCollection.FromJson(data, paginator);
            }
            catch (JsonException ex)
            {
                throw new MalformedResponse("Failed to parse API response", ex);
            }
            catch (NotificationSettingApiError)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SdkException("An unexpected error occurred", ex);
            }
        }

        public async Task<NotificationSetting> GetAsync(string id)
        {
            try
            {
                HttpResponseMessage response = await client.GetRawAsync($"/notification-settings/{id}");
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonElement root = JsonDocument.Parse(jsonString).RootElement;

                if (!response.IsSuccessStatusCode)
                {
                    throw NotificationSettingApiError.FromJson(root);
                }

                return NotificationSetting.FromJson(root.GetProperty("data"));
            }
            catch (JsonException ex)
            {
                throw new MalformedResponse("Failed to parse API response", ex);
            }
            catch (NotificationSettingApiError)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SdkException("An unexpected error occurred", ex);
            }
        }

        public async Task<NotificationSetting> CreateAsync(CreateNotificationSetting createOperation)
        {
            try
            {
                HttpResponseMessage response = await client.PostRawAsync("/notification-settings", createOperation);
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonElement root = JsonDocument.Parse(jsonString).RootElement;

                if (!response.IsSuccessStatusCode)
                {
                    throw NotificationSettingApiError.FromJson(root);
                }

                return NotificationSetting.FromJson(root.GetProperty("data"));
            }
            catch (JsonException ex)
            {
                throw new MalformedResponse("Failed to parse API response", ex);
            }
            catch (NotificationSettingApiError)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SdkException("An unexpected error occurred", ex);
            }
        }

        public async Task<NotificationSetting> UpdateAsync(string id, UpdateNotificationSetting operation)
        {
            try
            {
                HttpResponseMessage response = await client.PatchRawAsync($"/notification-settings/{id}", operation);
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonElement root = JsonDocument.Parse(jsonString).RootElement;

                if (!response.IsSuccessStatusCode)
                {
                    throw NotificationSettingApiError.FromJson(root);
                }

                return NotificationSetting.FromJson(root.GetProperty("data"));
            }
            catch (JsonException ex)
            {
                throw new MalformedResponse("Failed to parse API response", ex);
            }
            catch (NotificationSettingApiError)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SdkException("An unexpected error occurred", ex);
            }
        }

        public async Task DeleteAsync(string id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteRawAsync($"/notification-settings/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    JsonElement root = JsonDocument.Parse(jsonString).RootElement;
                    throw NotificationSettingApiError.FromJson(root);
                }
            }
            catch (JsonException ex)
            {
                throw new MalformedResponse("Failed to parse API response", ex);
            }
            catch (NotificationSettingApiError)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SdkException("An unexpected error occurred", ex);
            }
        }
    }
}