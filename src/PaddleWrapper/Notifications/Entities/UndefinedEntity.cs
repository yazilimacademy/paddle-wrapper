using System.Text.Json;

namespace PaddleWrapper.Notifications.Entities;

public class UndefinedEntity : IEntity
{
    public JsonElement Data { get; }

    private UndefinedEntity(JsonElement data)
    {
        Data = data;
    }

    public static IEntity FromJson(JsonElement data)
    {
        return new UndefinedEntity(data);
    }
}