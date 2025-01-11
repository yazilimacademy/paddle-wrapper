using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Events;
using DateTime = PaddleWrapper.Notifications.Entities.DateTime;
using IEntity = PaddleWrapper.Notifications.Entities.IEntity;

namespace PaddleWrapper.Notifications.Events;

public sealed class PriceImported : Event
{
    public Price Price { get; }

    private PriceImported(
        string eventId,
        EventTypeName eventType,
        DateTime occurredAt,
        Price price,
        string? notificationId) 
        : base(eventId, eventType, occurredAt, price, notificationId)
    {
        Price = price;
    }

    public static Event FromEvent(
        string eventId,
        EventTypeName eventType,
        DateTime occurredAt,
        IEntity data,
        string? notificationId = null)
    {
        if (data is not Price price)
        {
            throw new ArgumentException($"Expected data to be of type {nameof(Price)}", nameof(data));
        }

        return new PriceImported(eventId, eventType, occurredAt, price, notificationId);
    }
} 