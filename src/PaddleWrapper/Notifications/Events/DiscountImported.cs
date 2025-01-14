using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Events;
using DateTime = PaddleWrapper.Notifications.Entities.DateTime;
using IEntity = PaddleWrapper.Notifications.Entities.IEntity;
using NotificationDiscount = PaddleWrapper.Notifications.Entities.Discount;

namespace PaddleWrapper.Notifications.Events;

public sealed class DiscountImported : Event
{
    public NotificationDiscount Discount { get; }

    private DiscountImported(
        string eventId,
        EventTypeName eventType,
        DateTime occurredAt,
        NotificationDiscount discount,
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
        if (data is not NotificationDiscount discount)
        {
            throw new ArgumentException($"Expected data to be of type {nameof(NotificationDiscount)}", nameof(data));
        }

        return new DiscountImported(eventId, eventType, occurredAt, discount, notificationId);
    }
}