using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Events;
using DateTime = PaddleWrapper.Notifications.Entities.DateTime;
using IEntity = PaddleWrapper.Notifications.Entities.IEntity;

namespace PaddleWrapper.Notifications.Events;

public sealed class AddressCreated : Event
{
    public Address Address { get; }

    private AddressCreated(
        string eventId,
        EventTypeName eventType,
        DateTime occurredAt,
        Address address,
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
        if (data is not Address address)
        {
            throw new ArgumentException($"Expected data to be of type {nameof(Address)}", nameof(data));
        }

        return new AddressCreated(eventId, eventType, occurredAt, address, notificationId);
    }
}