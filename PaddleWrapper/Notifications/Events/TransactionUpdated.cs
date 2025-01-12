using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Events;
using DateTime = PaddleWrapper.Notifications.Entities.DateTime;
using IEntity = PaddleWrapper.Notifications.Entities.IEntity;

namespace PaddleWrapper.Notifications.Events;

public sealed class TransactionUpdated : Event
{
    public Transaction Transaction { get; }

    private TransactionUpdated(
        string eventId,
        EventTypeName eventType,
        DateTime occurredAt,
        Transaction transaction,
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
        if (data is not Transaction transaction)
        {
            throw new ArgumentException($"Expected data to be of type {nameof(Transaction)}", nameof(data));
        }

        return new TransactionUpdated(eventId, eventType, occurredAt, transaction, notificationId);
    }
}