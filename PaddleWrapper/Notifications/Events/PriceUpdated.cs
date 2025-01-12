using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Events;
using DateTime = PaddleWrapper.Notifications.Entities.DateTime;
using IEntity = PaddleWrapper.Notifications.Entities.IEntity;
using NotificationPrice = PaddleWrapper.Notifications.Entities.Price;

namespace PaddleWrapper.Notifications.Events;

public sealed class PriceUpdated : Event
{
    public NotificationPrice Price { get; }

    private PriceUpdated(
        string eventId,
        EventTypeName eventType,
        DateTime occurredAt,
        NotificationPrice price,
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
        if (data is not NotificationPrice price)
        {
            throw new ArgumentException($"Expected data to be of type {nameof(NotificationPrice)}", nameof(data));
        }

        return new PriceUpdated(eventId, eventType, occurredAt, price, notificationId);
    }
}