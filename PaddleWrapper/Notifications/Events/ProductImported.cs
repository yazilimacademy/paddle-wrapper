using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Events;
using DateTime = PaddleWrapper.Notifications.Entities.DateTime;
using IEntity = PaddleWrapper.Notifications.Entities.IEntity;
using NotificationProduct = PaddleWrapper.Notifications.Entities.Product;

namespace PaddleWrapper.Notifications.Events;

public sealed class ProductImported : Event
{
    public NotificationProduct Product { get; }

    private ProductImported(
        string eventId,
        EventTypeName eventType,
        DateTime occurredAt,
        NotificationProduct product,
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
        if (data is not NotificationProduct product)
        {
            throw new ArgumentException($"Expected data to be of type {nameof(NotificationProduct)}", nameof(data));
        }

        return new ProductImported(eventId, eventType, occurredAt, product, notificationId);
    }
}