using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Events;
using DateTime = PaddleWrapper.Notifications.Entities.DateTime;
using IEntity = PaddleWrapper.Notifications.Entities.IEntity;
using NotificationBusiness = PaddleWrapper.Notifications.Entities.Business;

namespace PaddleWrapper.Notifications.Events;

public sealed class BusinessUpdated : Event
{
    public NotificationBusiness Business { get; }

    private BusinessUpdated(
        string eventId,
        EventTypeName eventType,
        DateTime occurredAt,
        NotificationBusiness business,
        string? notificationId)
        : base(eventId, eventType, occurredAt, business, notificationId)
    {
        Business = business;
    }

    public static Event FromEvent(
        string eventId,
        EventTypeName eventType,
        DateTime occurredAt,
        IEntity data,
        string? notificationId = null)
    {
        if (data is not NotificationBusiness business)
        {
            throw new ArgumentException($"Expected data to be of type {nameof(NotificationBusiness)}", nameof(data));
        }

        return new BusinessUpdated(eventId, eventType, occurredAt, business, notificationId);
    }
}