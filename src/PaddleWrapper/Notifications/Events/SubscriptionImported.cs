using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Events;
using DateTime = PaddleWrapper.Notifications.Entities.DateTime;
using IEntity = PaddleWrapper.Notifications.Entities.IEntity;
using NotificationSubscription = PaddleWrapper.Notifications.Entities.Subscription;

namespace PaddleWrapper.Notifications.Events;

public sealed class SubscriptionImported : Event
{
    public NotificationSubscription Subscription { get; }

    private SubscriptionImported(
        string eventId,
        EventTypeName eventType,
        DateTime occurredAt,
        NotificationSubscription subscription,
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
        if (data is not NotificationSubscription subscription)
        {
            throw new ArgumentException($"Expected data to be of type {nameof(NotificationSubscription)}", nameof(data));
        }

        return new SubscriptionImported(eventId, eventType, occurredAt, subscription, notificationId);
    }
}