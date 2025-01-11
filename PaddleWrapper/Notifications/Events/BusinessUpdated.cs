using System;
using PaddleWrapper.Notifications.Entities;

namespace PaddleWrapper.Notifications.Events;

public sealed class BusinessUpdated : Event
{
    public Business Business { get; }

    private BusinessUpdated(
        string eventId,
        EventTypeName eventType,
        DateTime occurredAt,
        Business business,
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
        if (data is not Business business)
        {
            throw new ArgumentException($"Expected data to be of type {nameof(Business)}", nameof(data));
        }

        return new BusinessUpdated(eventId, eventType, occurredAt, business, notificationId);
    }
} 