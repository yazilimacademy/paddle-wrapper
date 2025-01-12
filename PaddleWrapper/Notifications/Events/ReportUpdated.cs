using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Events;
using DateTime = PaddleWrapper.Notifications.Entities.DateTime;
using IEntity = PaddleWrapper.Notifications.Entities.IEntity;
using NotificationReport = PaddleWrapper.Notifications.Entities.Report;

namespace PaddleWrapper.Notifications.Events;

public sealed class ReportUpdated : Event
{
    public NotificationReport Report { get; }

    private ReportUpdated(
        string eventId,
        EventTypeName eventType,
        DateTime occurredAt,
        NotificationReport report,
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
        if (data is not NotificationReport report)
        {
            throw new ArgumentException($"Expected data to be of type {nameof(NotificationReport)}", nameof(data));
        }

        return new ReportUpdated(eventId, eventType, occurredAt, report, notificationId);
    }
}