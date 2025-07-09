using Productivity.Domain.Common.Models;

namespace Productivity.Domain.SubtaskAggregate.ValueObjects;
public sealed class SubtaskId : ValueObject
{
    public Guid Value { get; }

    private SubtaskId(Guid value)
    {
        Value = value;
    }

    public static SubtaskId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}