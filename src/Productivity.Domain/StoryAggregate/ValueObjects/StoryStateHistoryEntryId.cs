using Productivity.Domain.Common.Models;

namespace Productivity.Domain.StoryAggregate.ValueObjects;
public sealed class StoryStateHistoryEntryId : ValueObject
{
    public Guid Value { get; }

    private StoryStateHistoryEntryId(Guid value)
    {
        Value = value;
    }

    public static StoryStateHistoryEntryId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}

