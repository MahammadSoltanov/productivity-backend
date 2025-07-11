using Productivity.Domain.Common.Enumerations;
using Productivity.Domain.Common.Models;

namespace Productivity.Domain.WorkspaceAggregate.ValueObjects;
public sealed class UserWorkspaceSettings : ValueObject
{
    public TaskViewMode? PreferredTaskView { get; }
    public int? PageSize { get; }
    public IReadOnlySet<NotificationChannel> NotificationChannels { get; }
    public IReadOnlySet<NotificationType> MutedNotificationTypes { get; }
    public IReadOnlySet<string> CollapsedSections { get; }

    public UserWorkspaceSettings(TaskViewMode? preferredTaskView,
                                 int? pageSize,
                                 IEnumerable<NotificationChannel> notificationChannels,
                                 IEnumerable<NotificationType>? mutedNotificationTypes,
                                 IEnumerable<string>? collapsedSections)
    {
        PreferredTaskView = preferredTaskView;
        PageSize = pageSize;
        NotificationChannels = new HashSet<NotificationChannel>(notificationChannels);
        MutedNotificationTypes = mutedNotificationTypes is null
                                  ? new HashSet<NotificationType>()
                                  : new HashSet<NotificationType>(mutedNotificationTypes);
        CollapsedSections = collapsedSections is null
                                  ? new HashSet<string>()
                                  : new HashSet<string>(collapsedSections);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        if (PreferredTaskView.HasValue) yield return PreferredTaskView.Value;
        if (PageSize is not null) yield return PageSize.Value;
        foreach (var c in NotificationChannels) yield return c;
        foreach (var t in MutedNotificationTypes) yield return t;
        foreach (var s in CollapsedSections) yield return s;
    }
}