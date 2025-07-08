using Productivity.Domain.Common.Enumerations;
using Productivity.Domain.Common.Models;

namespace Productivity.Domain.UserAggregate.Entities;
public sealed class AccountSettings : ValueObject
{
    public IReadOnlySet<NotificationChannel> EnabledChannels { get; }
    public IReadOnlySet<NotificationType> MutedNotificationTypes { get; }

    public AccountSettings(
      IEnumerable<NotificationChannel> channels,
      IEnumerable<NotificationType>? mutedTypes = null)
    {
        EnabledChannels = new HashSet<NotificationChannel>(channels);
        MutedNotificationTypes = mutedTypes is null
          ? new HashSet<NotificationType>()
          : new HashSet<NotificationType>(mutedTypes);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        foreach (var c in EnabledChannels) yield return c;
        foreach (var t in MutedNotificationTypes) yield return t;
    }
}

