using Productivity.Domain.Common.Models;

namespace Productivity.Domain.StoryAggregate.ValueObjects;
public sealed class StoryDependencyId : ValueObject
{
    public Guid Value { get; }

    private StoryDependencyId(Guid value)
    {
        Value = value;
    }

    public static StoryDependencyId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}