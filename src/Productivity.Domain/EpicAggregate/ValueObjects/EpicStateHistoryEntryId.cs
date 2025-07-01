using Productivity.Domain.Common.Models;

namespace Productivity.Domain.EpicAggregate.ValueObjects;
public sealed class EpicStateHistoryEntryId : ValueObject
{
    public Guid Value { get; }

    private EpicStateHistoryEntryId(Guid value)
    {
        Value = value;
    }

    public static EpicStateHistoryEntryId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}