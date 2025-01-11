using System;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace PaddleWrapper.Notifications.Entities;

public static class EntityFactory
{
    private static readonly Dictionary<string, Type> EventEntityTypes = new()
    {
        { "payment_method.deleted", typeof(DeletedPaymentMethod) }
    };

    public static IEntity Create(string eventType, JsonElement data)
    {
        Type entityType = EventEntityTypes.TryGetValue(eventType, out var type) 
            ? type 
            : ResolveEntityType(eventType);

        var fromJsonMethod = entityType.GetMethod("FromJson");
        if (fromJsonMethod == null)
        {
            throw new InvalidOperationException($"Entity type '{entityType.Name}' does not implement FromJson method");
        }

        return (IEntity)fromJsonMethod.Invoke(null, new object[] { data })!;
    }

    private static Type ResolveEntityType(string eventType)
    {
        var type = eventType.Split('.');
        var entity = SnakeToPascalCase(type[0] ?? "Unknown");
        var identifier = SnakeToPascalCase(string.Join("_", type));

        var entityType = Type.GetType($"PaddleWrapper.Notifications.Entities.{entity}, PaddleWrapper");
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