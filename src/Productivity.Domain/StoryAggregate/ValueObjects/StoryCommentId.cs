using Productivity.Domain.Common.Models;

namespace Productivity.Domain.EpicAggregate.ValueObjects;
public sealed class StoryCommentId : ValueObject
{
    public Guid Value { get; }

    private StoryCommentId(Guid value)
    {
        Value = value;
    }

    public static StoryCommentId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}