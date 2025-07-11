using Productivity.Domain.Common.Enumerations;
using Productivity.Domain.Common.Models;

namespace Productivity.Domain.WorkspaceAggregate.ValueObjects;
public sealed class GlobalWorkspaceSettings : ValueObject
{
    public TaskViewMode DefaultTaskView { get; }
    public TimeSpan WorkDayStart { get; }
    public TimeSpan WorkDayEnd { get; }
    public int DefaultPageSize { get; }
    public IReadOnlySet<NotificationChannel> DefaultNotificationChannels { get; }

    public GlobalWorkspaceSettings(TaskViewMode defaultTaskView,
                                   TimeSpan workDayStart,
                                   TimeSpan workDayEnd,
                                   int defaultPageSize,
                                   IEnumerable<NotificationChannel> defaultNotificationChannels)
    {
        DefaultTaskView = defaultTaskView;
        WorkDayStart = workDayStart;
        WorkDayEnd = workDayEnd;
        DefaultPageSize = defaultPageSize;
        DefaultNotificationChannels = new HashSet<NotificationChannel>(defaultNotificationChannels);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return DefaultTaskView;
        yield return WorkDayStart;
        yield return WorkDayEnd;
        yield return DefaultPageSize;
        foreach (var c in DefaultNotificationChannels) yield return c;
    }
}