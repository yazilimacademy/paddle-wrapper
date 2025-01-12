using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Events;
using DateTime = PaddleWrapper.Notifications.Entities.DateTime;
using IEntity = PaddleWrapper.Notifications.Entities.IEntity;

namespace PaddleWrapper.Notifications.Events;

public sealed class PaymentMethodSaved : Event
{
    public PaymentMethod PaymentMethod { get; }

    private PaymentMethodSaved(
        string eventId,
        EventTypeName eventType,
        DateTime occurredAt,
        PaymentMethod paymentMethod,
        string? notificationId)
        : base(eventId, eventType, occurredAt, paymentMethod, notificationId)
    {
        PaymentMethod = paymentMethod;
    }

    public static Event FromEvent(
        string eventId,
        EventTypeName eventType,
        DateTime occurredAt,
        IEntity data,
        string? notificationId = null)
    {
        if (data is not PaymentMethod paymentMethod)
        {
            throw new ArgumentException($"Expected data to be of type {nameof(PaymentMethod)}", nameof(data));
        }

        return new PaymentMethodSaved(eventId, eventType, occurredAt, paymentMethod, notificationId);
    }
}