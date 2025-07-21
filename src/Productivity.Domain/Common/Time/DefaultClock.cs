using Productivity.Domain.Common.Interfaces;

namespace Productivity.Domain.Common.Time;
internal sealed class DefaultClock : IClock
{
    public DateTimeOffset UtcNow => DomainTime.Current.UtcNow;
}