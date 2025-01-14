using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Exceptions;
using PaddleWrapper.Exceptions.ApiErrors;
using PaddleWrapper.Exceptions.SdkExceptions;
using System.Text.Json;

namespace PaddleWrapper.Resources.EventTypes
{
    public class EventTypesClient(Client client)
    {
        public async Task<EventTypeCollection> ListAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetRawAsync("/event-types");
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonElement root = JsonDocument.Parse(jsonString).RootElement;

                if (!response.IsSuccessStatusCode)
                {
                    throw EventTypeApiError.FromJson(root);
                }

                return EventTypeCollection.FromJson(root.GetProperty("data"), null);
            }
            catch (JsonException ex)
            {
                throw new MalformedResponse("Failed to parse API response", ex);
            }
            catch (EventTypeApiError)
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