using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Events;
using DateTime = PaddleWrapper.Notifications.Entities.DateTime;
using IEntity = PaddleWrapper.Notifications.Entities.IEntity;

namespace PaddleWrapper.Notifications.Events;

public sealed class PaymentMethodDeleted : Event
{
    public DeletedPaymentMethod DeletedPaymentMethod { get; }

    private PaymentMethodDeleted(
        string eventId,
        EventTypeName eventType,
        DateTime occurredAt,
        DeletedPaymentMethod deletedPaymentMethod,
        string? notificationId) 
        : base(eventId, eventType, occurredAt, deletedPaymentMethod, notificationId)
    {
        DeletedPaymentMethod = deletedPaymentMethod;
    }

    public static Event FromEvent(
        string eventId,
        EventTypeName eventType,
        DateTime occurredAt,
        IEntity data,
        string? notificationId = null)
    {
        if (data is not DeletedPaymentMethod deletedPaymentMethod)
        {
            throw new ArgumentException($"Expected data to be of type {nameof(DeletedPaymentMethod)}", nameof(data));
        }

        return new PaymentMethodDeleted(eventId, eventType, occurredAt, deletedPaymentMethod, notificationId);
    }
} 