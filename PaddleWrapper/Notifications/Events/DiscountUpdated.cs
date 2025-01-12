using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Events;
using DateTime = PaddleWrapper.Notifications.Entities.DateTime;
using IEntity = PaddleWrapper.Notifications.Entities.IEntity;

namespace PaddleWrapper.Notifications.Events;

public sealed class DiscountUpdated : Event
{
    public Discount Discount { get; }

    private DiscountUpdated(
        string eventId,
        EventTypeName eventType,
        DateTime occurredAt,
        Discount discount,
        string? notificationId)
        : base(eventId, eventType, occurredAt, discount, notificationId)
    {
        Discount = discount;
    }

    public static Event FromEvent(
        string eventId,
        EventTypeName eventType,
        DateTime occurredAt,
        IEntity data,
        string? notificationId = null)
    {
        if (data is not Discount discount)
        {
            throw new ArgumentException($"Expected data to be of type {nameof(Discount)}", nameof(data));
        }

        return new DiscountUpdated(eventId, eventType, occurredAt, discount, notificationId);
    }
}