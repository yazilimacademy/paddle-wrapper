using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Events;
using DateTime = PaddleWrapper.Notifications.Entities.DateTime;
using IEntity = PaddleWrapper.Notifications.Entities.IEntity;

namespace PaddleWrapper.Notifications.Events;

public sealed class ReportCreated : Event
{
    public Report Report { get; }

    private ReportCreated(
        string eventId,
        EventTypeName eventType,
        DateTime occurredAt,
        Report report,
        string? notificationId) 
        : base(eventId, eventType, occurredAt, report, notificationId)
    {
        Report = report;
    }

    public static Event FromEvent(
        string eventId,
        EventTypeName eventType,
        DateTime occurredAt,
        IEntity data,
        string? notificationId = null)
    {
        if (data is not Report report)
        {
            throw new ArgumentException($"Expected data to be of type {nameof(Report)}", nameof(data));
        }

        return new ReportCreated(eventId, eventType, occurredAt, report, notificationId);
    }
} 