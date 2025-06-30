using Productivity.Domain.Common.Models;

namespace Productivity.Domain.EpicAggregate.ValueObjects;
public sealed class SubtaskDependencyId : ValueObject
{
    public Guid Value { get; }

    private SubtaskDependencyId(Guid value)
    {
        Value = value;
    }

    public static SubtaskDependencyId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
