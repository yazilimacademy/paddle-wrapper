using System.Text.Json;

namespace PaddleWrapper.Notifications.Entities;

public interface IEntity
{
    /// <summary>
    /// A static factory for the entity that confirms to the Paddle API.
    /// </summary>
    static abstract IEntity FromJson(JsonElement data);
} 