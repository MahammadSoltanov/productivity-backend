using Productivity.Domain.Common.Enumerations;
using Productivity.Domain.Common.Models;

namespace Productivity.Domain.UserAggregate.ValueObjects;
public sealed class AccountSettings : ValueObject
{
    public ThemePreference Theme { get; private set; }
    public int ItemsPerPage { get; private set; }
    public TimeZoneInfo? DefaultTimeZone { get; private set; }
    public IReadOnlySet<NotificationChannel> EnabledChannels { get; private set; }
    public IReadOnlySet<NotificationType> MutedNotificationTypes { get; private set; }

    public AccountSettings(IEnumerable<NotificationChannel> channels,
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

    private AccountSettings() { }

    public override IEnumerable<object> GetEqualityComponents()
    {
        foreach (var c in EnabledChannels)
        {
            yield return c;
        }

        foreach (var t in MutedNotificationTypes)
        {
            yield return t;
        }
    }
}