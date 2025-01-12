using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Events;
using DateTime = PaddleWrapper.Notifications.Entities.DateTime;
using IEntity = PaddleWrapper.Notifications.Entities.IEntity;

namespace PaddleWrapper.Notifications.Events;

public sealed class ProductCreated : Event
{
    public Product Product { get; }

    private ProductCreated(
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

        return new ProductCreated(eventId, eventType, occurredAt, product, notificationId);
    }
}