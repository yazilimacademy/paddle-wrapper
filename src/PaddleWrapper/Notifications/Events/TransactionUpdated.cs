using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Events;
using DateTime = PaddleWrapper.Notifications.Entities.DateTime;
using IEntity = PaddleWrapper.Notifications.Entities.IEntity;
using NotificationTransaction = PaddleWrapper.Notifications.Entities.Transaction;

namespace PaddleWrapper.Notifications.Events;

public sealed class TransactionUpdated : Event
{
    public NotificationTransaction Transaction { get; }

    private TransactionUpdated(
        string eventId,
        EventTypeName eventType,
        DateTime occurredAt,
        NotificationTransaction transaction,
        string? notificationId)
        : base(eventId, eventType, occurredAt, transaction, notificationId)
    {
        Transaction = transaction;
    }

    public static Event FromEvent(
        string eventId,
        EventTypeName eventType,
        DateTime occurredAt,
        IEntity data,
        string? notificationId = null)
    {
        if (data is not NotificationTransaction transaction)
        {
            throw new ArgumentException($"Expected data to be of type {nameof(NotificationTransaction)}", nameof(data));
        }

        return new TransactionUpdated(eventId, eventType, occurredAt, transaction, notificationId);
    }
}