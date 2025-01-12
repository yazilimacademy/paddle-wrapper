using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Events;
using PaddleWrapper.Notifications.Entities;
using System.Text.Json;
using DateTime = PaddleWrapper.Notifications.Entities.DateTime;
using IEntity = PaddleWrapper.Notifications.Entities.IEntity;

namespace PaddleWrapper.Notifications.Events;

public sealed class UndefinedEvent : Event
{
    public JsonElement Data { get; }

    private UndefinedEvent(
        string eventId,
        EventTypeName eventType,
        DateTime occurredAt,
        JsonElement data,
        string? notificationId)
        : base(eventId, eventType, occurredAt, null, notificationId)
    {
        Data = data;
    }

    public static Event FromEvent(
        string eventId,
        EventTypeName eventType,
        DateTime occurredAt,
        IEntity data,
        string? notificationId = null)
    {
        if (data is not UndefinedEntity undefinedEntity)
        {
            throw new ArgumentException($"Expected data to be of type {nameof(UndefinedEntity)}", nameof(data));
        }

        return new UndefinedEvent(eventId, eventType, occurredAt, undefinedEntity.Data, notificationId);
    }
}