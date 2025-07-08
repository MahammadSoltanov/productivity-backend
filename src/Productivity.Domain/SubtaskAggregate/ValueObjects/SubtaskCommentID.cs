using Productivity.Domain.Common.Models;

namespace Productivity.Domain.EpicAggregate.ValueObjects;
public sealed class SubtaskCommentId : ValueObject
{
    public Guid Value { get; }

    private SubtaskCommentId(Guid value)
    {
        Value = value;
    }

    public static SubtaskCommentId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}