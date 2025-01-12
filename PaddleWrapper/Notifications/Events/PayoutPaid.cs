using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Events;
using PaddleWrapper.Notifications.Entities;
using DateTime = PaddleWrapper.Notifications.Entities.DateTime;
using IEntity = PaddleWrapper.Notifications.Entities.IEntity;

namespace PaddleWrapper.Notifications.Events;

public sealed class PayoutPaid : Event
{
    public Payout Payout { get; }

    private PayoutPaid(
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

        return new PayoutPaid(eventId, eventType, occurredAt, payout, notificationId);
    }
} 