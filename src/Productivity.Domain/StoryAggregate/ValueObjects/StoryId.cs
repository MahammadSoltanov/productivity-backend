using Productivity.Domain.Common.Models;

namespace Productivity.Domain.StoryAggregate.ValueObjects;
public sealed class StoryId : ValueObject
{
    public Guid Value { get; }

    private StoryId(Guid value)
    {
        Value = value;
    }

    public static StoryId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}