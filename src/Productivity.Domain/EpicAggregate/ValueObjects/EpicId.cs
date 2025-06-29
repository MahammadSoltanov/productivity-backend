using Productivity.Domain.Common.Models;

namespace Productivity.Domain.EpicAggregate.ValueObjects;
public sealed class EpicId : ValueObject
{
    public Guid Value { get; }

    private EpicId(Guid value)
    {
        Value = value;
    }

    public static EpicId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}