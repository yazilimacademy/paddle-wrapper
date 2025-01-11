using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Events;
using DateTime = PaddleWrapper.Notifications.Entities.DateTime;
using IEntity = PaddleWrapper.Notifications.Entities.IEntity;

namespace PaddleWrapper.Notifications.Events;

public sealed class PayoutCreated : Event
{
    public Payout Payout { get; }

    private PayoutCreated(
        string eventId,
        EventTypeName eventType,
        DateTime occurredAt,
        Payout payout,
        string? notificationId) 
        : base(eventId, eventType, occurredAt, payout, notificationId)
    {
        Payout = payout;
    }

    public static Event FromEvent(
        string eventId,
        EventTypeName eventType,
        DateTime occurredAt,
        IEntity data,
        string? notificationId = null)
    {
        if (data is not Payout payout)
        {
            throw new ArgumentException($"Expected data to be of type {nameof(Payout)}", nameof(data));
        }

        return new PayoutCreated(eventId, eventType, occurredAt, payout, notificationId);
    }
} 