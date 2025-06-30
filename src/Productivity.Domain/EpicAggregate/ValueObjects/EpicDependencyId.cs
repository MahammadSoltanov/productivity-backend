using Productivity.Domain.Common.Models;

namespace Productivity.Domain.EpicAggregate.ValueObjects;
public sealed class EpicDependencyId : ValueObject
{
    public Guid Value { get; }

    private EpicDependencyId(Guid value)
    {
        Value = value;
    }

    public static EpicDependencyId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}