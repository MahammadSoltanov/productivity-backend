using Productivity.Domain.Common.Interfaces;

namespace Productivity.Domain.Common.Time;
public static class DomainTime
{
    public static IClock Current { get; set; } = new DefaultClock();
}
