using System;
using PaddleWrapper.Notifications.Entities;

namespace PaddleWrapper.Notifications.Events;

public sealed class ProductImported : Event
{
    public Product Product { get; }

    private ProductImported(
        string eventId,
        EventTypeName eventType,
        DateTime occurredAt,
        Product product,
        string? notificationId) 
        : base(eventId, eventType, occurredAt, product, notificationId)
    {
        Product = product;
    }

    public static Event FromEvent(
        string eventId,
        EventTypeName eventType,
        DateTime occurredAt,
        IEntity data,
        string? notificationId = null)
    {
        if (data is not Product product)
        {
            throw new ArgumentException($"Expected data to be of type {nameof(Product)}", nameof(data));
        }

        return new ProductImported(eventId, eventType, occurredAt, product, notificationId);
    }
} 