using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Events;
using DateTime = PaddleWrapper.Notifications.Entities.DateTime;
using IEntity = PaddleWrapper.Notifications.Entities.IEntity;

namespace PaddleWrapper.Notifications.Events;

public sealed class SubscriptionImported : Event
{
    public Subscription Subscription { get; }

    private SubscriptionImported(
        string eventId,
        EventTypeName eventType,
        DateTime occurredAt,
        Subscription subscription,
        string? notificationId) 
        : base(eventId, eventType, occurredAt, subscription, notificationId)
    {
        Subscription = subscription;
    }

    public static Event FromEvent(
        string eventId,
        EventTypeName eventType,
        DateTime occurredAt,
        IEntity data,
        string? notificationId = null)
    {
        if (data is not Subscription subscription)
        {
            throw new ArgumentException($"Expected data to be of type {nameof(Subscription)}", nameof(data));
        }

        return new SubscriptionImported(eventId, eventType, occurredAt, subscription, notificationId);
    }
} 