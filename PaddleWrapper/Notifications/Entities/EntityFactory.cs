using System.Text.Json;

namespace PaddleWrapper.Notifications.Entities;

public static class EntityFactory
{
    private static readonly Dictionary<string, Type> EventEntityTypes = new()
    {
        { "payment_method.deleted", typeof(DeletedPaymentMethod) }
    };

    public static IEntity Create(string eventType, JsonElement data)
    {
        Type entityType = EventEntityTypes.TryGetValue(eventType, out Type? type)
            ? type
            : ResolveEntityType(eventType);

        System.Reflection.MethodInfo? fromJsonMethod = entityType.GetMethod("FromJson");
        if (fromJsonMethod == null)
        {
            throw new InvalidOperationException($"Entity type '{entityType.Name}' does not implement FromJson method");
        }

        return (IEntity)fromJsonMethod.Invoke(null, new object[] { data })!;
    }

    private static Type ResolveEntityType(string eventType)
    {
        string[] type = eventType.Split('.');
        string entity = SnakeToPascalCase(type[0] ?? "Unknown");
        string identifier = SnakeToPascalCase(string.Join("_", type));

        Type? entityType = Type.GetType($"PaddleWrapper.Notifications.Entities.{entity}, PaddleWrapper");
        if (entityType == null)
        {
            entityType = typeof(UndefinedEntity);
        }

        if (entityType == null || !typeof(IEntity).IsAssignableFrom(entityType))
        {
            throw new UnexpectedValueException($"Event type '{identifier}' cannot be mapped to an object");
        }

        return entityType;
    }

    private static string SnakeToPascalCase(string input)
    {
        return string.Join("", input.Split('_')
            .Select(word => char.ToUpper(word[0]) + word[1..].ToLower()));
    }
}