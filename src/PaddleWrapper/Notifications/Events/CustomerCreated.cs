using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Events;
using DateTime = PaddleWrapper.Notifications.Entities.DateTime;
using IEntity = PaddleWrapper.Notifications.Entities.IEntity;
using NotificationCustomer = PaddleWrapper.Notifications.Entities.Customer;

namespace PaddleWrapper.Notifications.Events;

public sealed class CustomerCreated : Event
{
    public NotificationCustomer Customer { get; }

    private CustomerCreated(
        string eventId,
        EventTypeName eventType,
        DateTime occurredAt,
        NotificationCustomer customer,
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
        if (data is not NotificationCustomer customer)
        {
            throw new ArgumentException($"Expected data to be of type {nameof(NotificationCustomer)}", nameof(data));
        }

        return new CustomerCreated(eventId, eventType, occurredAt, customer, notificationId);
    }
}