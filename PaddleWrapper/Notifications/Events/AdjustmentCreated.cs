using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Events;
using DateTime = PaddleWrapper.Notifications.Entities.DateTime;
using IEntity = PaddleWrapper.Notifications.Entities.IEntity;
using NotificationAdjustment = PaddleWrapper.Notifications.Entities.Adjustment;

namespace PaddleWrapper.Notifications.Events;

public sealed class AdjustmentCreated : Event
{
    public NotificationAdjustment Adjustment { get; }

    private AdjustmentCreated(
        string eventId,
        EventTypeName eventType,
        DateTime occurredAt,
        NotificationAdjustment adjustment,
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
        if (data is not NotificationAdjustment adjustment)
        {
            throw new ArgumentException($"Expected data to be of type {nameof(NotificationAdjustment)}", nameof(data));
        }

        return new AdjustmentCreated(eventId, eventType, occurredAt, adjustment, notificationId);
    }
}