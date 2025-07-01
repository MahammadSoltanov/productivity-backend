using Productivity.Domain.Common.Models;

namespace Productivity.Domain.SubtaskAggregate.ValueObjects;
public sealed class SubtaskStateHistoryEntryId : ValueObject
{
    public Guid Value { get; }

    private SubtaskStateHistoryEntryId(Guid value)
    {
        Value = value;
    }

    public static SubtaskStateHistoryEntryId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}


