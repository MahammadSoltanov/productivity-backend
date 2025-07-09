using Productivity.Domain.Common.Models;

namespace Productivity.Domain.Common.ValueObjects;

public sealed class DateRange : ValueObject
{
    public DateTime From { get; }
    public DateTime? To { get; }

    internal DateRange(DateTime from, DateTime? to = null)
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
        return new(DateTime.MinValue, null);
    }

    public DateRange WithEnd(DateTime to)
    {
        return new DateRange(From, to);
    }

    internal bool IsWithinRange(DateTime date)
    {
        return date >= From && (!To.HasValue || date <= To.Value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return From;
        yield return To;
    }
}