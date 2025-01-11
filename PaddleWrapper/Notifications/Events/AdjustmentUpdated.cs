using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Events;
using DateTime = PaddleWrapper.Notifications.Entities.DateTime;
using IEntity = PaddleWrapper.Notifications.Entities.IEntity;

namespace PaddleWrapper.Notifications.Events;

public sealed class AdjustmentUpdated : Event
{
    public Adjustment Adjustment { get; }

    private AdjustmentUpdated(
        string eventId,
        EventTypeName eventType,
        DateTime occurredAt,
        Adjustment adjustment,
        string? notificationId) 
        : base(eventId, eventType, occurredAt, adjustment, notificationId)
    {
        Adjustment = adjustment;
    }

    public static Event FromEvent(
        string eventId,
        EventTypeName eventType,
        DateTime occurredAt,
        IEntity data,
        string? notificationId = null)
    {
        if (data is not Adjustment adjustment)
        {
            throw new ArgumentException($"Expected data to be of type {nameof(Adjustment)}", nameof(data));
        }

        return new AdjustmentUpdated(eventId, eventType, occurredAt, adjustment, notificationId);
    }
} 