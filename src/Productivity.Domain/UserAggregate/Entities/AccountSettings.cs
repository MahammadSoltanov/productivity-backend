using Productivity.Domain.Common.Enumerations;
using Productivity.Domain.Common.Models;

namespace Productivity.Domain.UserAggregate.Entities;
public sealed class AccountSettings : ValueObject
{
    public ThemePreference Theme { get; }
    public int ItemsPerPage { get; }
    public TimeZoneInfo? DefaultTimeZone { get; }
    public IReadOnlySet<NotificationChannel> EnabledChannels { get; }
    public IReadOnlySet<NotificationType> MutedNotificationTypes { get; }

    public AccountSettings(
      IEnumerable<NotificationChannel> channels,
      IEnumerable<NotificationType>? muted,
      ThemePreference theme,
      int itemsPerPage,
      TimeZoneInfo? defaultTimeZone = null)
    {
        EnabledChannels = new HashSet<NotificationChannel>(channels);
        MutedNotificationTypes = muted is null
          ? new HashSet<NotificationType>()
          : new HashSet<NotificationType>(muted);
        Theme = theme;
        ItemsPerPage = itemsPerPage;
        DefaultTimeZone = defaultTimeZone;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        foreach (var c in EnabledChannels) yield return c;
        foreach (var t in MutedNotificationTypes) yield return t;
    }
}