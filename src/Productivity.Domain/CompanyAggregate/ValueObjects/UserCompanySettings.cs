using Productivity.Domain.Common.Enumerations;
using Productivity.Domain.Common.Models;

namespace Productivity.Domain.CompanyAggregate.ValueObjects;
public sealed class UserCompanySettings : ValueObject
{
    public IReadOnlySet<NotificationChannel> NotificationChannels { get; }
    public IReadOnlySet<NotificationType> MutedNotificationTypes { get; }
    public TaskViewMode DefaultTaskView { get; }
    public bool ShowCompanyAnnouncements { get; }

    public UserCompanySettings(
        IEnumerable<NotificationChannel> notificationChannels,
        IEnumerable<NotificationType>? mutedNotificationTypes,
        TaskViewMode defaultTaskView,
        bool showCompanyAnnouncements)
    {
        NotificationChannels = new HashSet<NotificationChannel>(notificationChannels);
        MutedNotificationTypes = mutedNotificationTypes is null
                                   ? new HashSet<NotificationType>()
                                   : new HashSet<NotificationType>(mutedNotificationTypes);
        DefaultTaskView = defaultTaskView;
        ShowCompanyAnnouncements = showCompanyAnnouncements;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        foreach (var c in NotificationChannels) yield return c;
        foreach (var t in MutedNotificationTypes) yield return t;
        yield return DefaultTaskView;
        yield return ShowCompanyAnnouncements;
    }
}