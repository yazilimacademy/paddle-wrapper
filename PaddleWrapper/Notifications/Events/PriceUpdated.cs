using System;
using PaddleWrapper.Notifications.Entities;

namespace PaddleWrapper.Notifications.Events;

public sealed class PriceUpdated : Event
{
    public Price Price { get; }

    private PriceUpdated(
        string eventId,
        EventTypeName eventType,
        DateTime occurredAt,
        Price price,
        string? notificationId) 
        : base(eventId, eventType, occurredAt, price, notificationId)
    {
        Price = price;
    }

    public static Event FromEvent(
        string eventId,
        EventTypeName eventType,
        DateTime occurredAt,
        IEntity data,
        string? notificationId = null)
    {
        if (data is not Price price)
        {
            throw new ArgumentException($"Expected data to be of type {nameof(Price)}", nameof(data));
        }

        return new PriceUpdated(eventId, eventType, occurredAt, price, notificationId);
    }
} 