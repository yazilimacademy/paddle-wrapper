using System;
using PaddleWrapper.Notifications.Entities;

namespace PaddleWrapper.Notifications.Events;

public sealed class CustomerUpdated : Event
{
    public Customer Customer { get; }

    private CustomerUpdated(
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

        return new CustomerUpdated(eventId, eventType, occurredAt, customer, notificationId);
    }
} 