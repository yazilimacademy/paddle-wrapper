using System;
using PaddleWrapper.Notifications.Entities;

namespace PaddleWrapper.Notifications.Events;

public sealed class SubscriptionCanceled : Event
{
    public Subscription Subscription { get; }

    private SubscriptionCanceled(
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

        return new SubscriptionCanceled(eventId, eventType, occurredAt, subscription, notificationId);
    }
} 