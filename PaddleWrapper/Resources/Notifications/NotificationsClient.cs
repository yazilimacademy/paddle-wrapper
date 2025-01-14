using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Exceptions;
using PaddleWrapper.Exceptions.ApiErrors;
using PaddleWrapper.Exceptions.SdkExceptions;
using PaddleWrapper.Resources.Notifications.Operations;
using System.Text.Json;

namespace PaddleWrapper.Resources.Notifications;

public class NotificationsClient
{
    private readonly Client _client;

    public NotificationsClient(Client client)
    {
        _client = client;
    }

    public async Task<NotificationCollection> ListAsync(ListNotifications listOperation = null)
    {
        try
        {
            listOperation ??= new ListNotifications();
            HttpResponseMessage response = await _client.GetRawAsync("/notifications", listOperation);
            string jsonString = await response.Content.ReadAsStringAsync();
            JsonElement jsonElement = JsonDocument.Parse(jsonString).RootElement;

            if (!response.IsSuccessStatusCode)
            {
                throw NotificationApiError.FromJson(jsonElement);
            }

            JsonElement data = jsonElement.GetProperty("data");
            JsonElement meta = jsonElement.GetProperty("meta");

            Paginator paginator = new(
                _client.HttpClient,
                Pagination.FromJson(meta),
                typeof(NotificationCollection)
            );

            return NotificationCollection.FromJson(data, paginator);
        }
        catch (JsonException ex)
        {
            throw new MalformedResponse("Failed to parse API response", ex);
        }
        catch (NotificationApiError)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new SdkException("An unexpected error occurred", ex);
        }
    }

    public async Task<Notification> GetAsync(string id)
    {
        try
        {
            HttpResponseMessage response = await _client.GetRawAsync($"/notifications/{id}");
            string jsonString = await response.Content.ReadAsStringAsync();
            JsonElement root = JsonDocument.Parse(jsonString).RootElement;

            if (!response.IsSuccessStatusCode)
            {
                throw NotificationApiError.FromJson(root);
            }

            return Notification.FromJson(root.GetProperty("data"));
        }
        catch (JsonException ex)
        {
            throw new MalformedResponse("Failed to parse API response", ex);
        }
        catch (NotificationApiError)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new SdkException("An unexpected error occurred", ex);
        }
    }

    public async Task<Notification> ReplayAsync(string id)
    {
        try
        {
            HttpResponseMessage response = await _client.PostRawAsync($"/notifications/{id}/replay", null);
            string jsonString = await response.Content.ReadAsStringAsync();
            JsonElement root = JsonDocument.Parse(jsonString).RootElement;

            if (!response.IsSuccessStatusCode)
            {
                throw NotificationApiError.FromJson(root);
            }

            return Notification.FromJson(root.GetProperty("data"));
        }
        catch (JsonException ex)
        {
            throw new MalformedResponse("Failed to parse API response", ex);
        }
        catch (NotificationApiError)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new SdkException("An unexpected error occurred", ex);
        }
    }
}