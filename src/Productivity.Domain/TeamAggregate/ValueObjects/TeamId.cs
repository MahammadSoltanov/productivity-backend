using Productivity.Domain.Common.Models;

namespace Productivity.Domain.TeamAggregate.ValueObjects;
public sealed class TeamId : ValueObject
{
    public Guid Value { get; }

    private TeamId(Guid value)
    {
        Value = value;
    }

    public static TeamId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}