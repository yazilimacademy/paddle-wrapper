using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Events;
using DateTime = PaddleWrapper.Notifications.Entities.DateTime;
using IEntity = PaddleWrapper.Notifications.Entities.IEntity;
using NotificationAddress = PaddleWrapper.Notifications.Entities.Address;

namespace PaddleWrapper.Notifications.Events;

public sealed class AddressUpdated : Event
{
    public NotificationAddress Address { get; }

    private AddressUpdated(
        string eventId,
        EventTypeName eventType,
        DateTime occurredAt,
        NotificationAddress address,
        string? notificationId)
        : base(eventId, eventType, occurredAt, address, notificationId)
    {
        Address = address;
    }

    public static Event FromEvent(
        string eventId,
        EventTypeName eventType,
        DateTime occurredAt,
        IEntity data,
        string? notificationId = null)
    {
        if (data is not NotificationAddress address)
        {
            throw new ArgumentException($"Expected data to be of type {nameof(NotificationAddress)}", nameof(data));
        }

        return new AddressUpdated(eventId, eventType, occurredAt, address, notificationId);
    }
}