using Productivity.Domain.Common.Models;

namespace Productivity.Domain.Common.ValueObjects;

public sealed class DateRange : ValueObject
{
    public DateTimeOffset From { get; }
    public DateTimeOffset? To { get; }

    internal DateRange(DateTimeOffset from, DateTimeOffset? to = null)
    {
        if (to.HasValue && to < from)
        {
            throw new ArgumentException("Invalid period: 'To' is before 'From'.", nameof(To));
        }

        From = from;
        To = to;
    }

    public static DateRange Empty()
    {
        return new(DateTimeOffset.MinValue, null);
    }

    public DateRange WithEnd(DateTimeOffset to)
    {
        return new DateRange(From, to);
    }

    internal bool IsWithinRange(DateTimeOffset date)
    {
        return date >= From && (!To.HasValue || date <= To.Value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return From;
        yield return To;
    }
}