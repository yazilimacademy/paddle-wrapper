using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Events;
using DateTime = PaddleWrapper.Notifications.Entities.DateTime;
using IEntity = PaddleWrapper.Notifications.Entities.IEntity;

namespace PaddleWrapper.Notifications.Events;

public sealed class CustomerImported : Event
{
    public Customer Customer { get; }

    private CustomerImported(
        string eventId,
        EventTypeName eventType,
        DateTime occurredAt,
        Customer customer,
        string? notificationId) 
        : base(eventId, eventType, occurredAt, customer, notificationId)
    {
        Customer = customer;
    }

    public static Event FromEvent(
        string eventId,
        EventTypeName eventType,
        DateTime occurredAt,
        IEntity data,
        string? notificationId = null)
    {
        if (data is not Customer customer)
        {
            throw new ArgumentException($"Expected data to be of type {nameof(Customer)}", nameof(data));
        }

        return new CustomerImported(eventId, eventType, occurredAt, customer, notificationId);
    }
} 