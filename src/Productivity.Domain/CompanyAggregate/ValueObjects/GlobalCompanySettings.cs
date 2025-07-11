using Productivity.Domain.Common.Enumerations;
using Productivity.Domain.Common.Models;

namespace Productivity.Domain.CompanyAggregate.ValueObjects;
public class GlobalCompanySettings : ValueObject
{
    public TimeZoneInfo DefaultTimeZone { get; }
    public bool RequireTwoFactorAuthentication { get; }
    public IReadOnlySet<NotificationChannel> DefaultNotificationChannels { get; }

    public GlobalCompanySettings(
        TimeZoneInfo defaultTimeZone,
        bool requireTwoFactorAuthentication,
        IEnumerable<NotificationChannel> defaultNotificationChannels)
    {
        DefaultTimeZone = defaultTimeZone;
        RequireTwoFactorAuthentication = requireTwoFactorAuthentication;
        DefaultNotificationChannels = new HashSet<NotificationChannel>(defaultNotificationChannels);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return DefaultTimeZone.Id;
        yield return RequireTwoFactorAuthentication;
        foreach (var c in DefaultNotificationChannels) yield return c;
    }
}
