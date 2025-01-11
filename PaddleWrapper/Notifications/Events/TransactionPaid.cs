using System;
using PaddleWrapper.Notifications.Entities;

namespace PaddleWrapper.Notifications.Events;

public sealed class TransactionPaid : Event
{
    public Transaction Transaction { get; }

    private TransactionPaid(
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

        return new TransactionPaid(eventId, eventType, occurredAt, transaction, notificationId);
    }
} 