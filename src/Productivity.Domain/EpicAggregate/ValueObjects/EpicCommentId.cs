using Productivity.Domain.Common.Models;

namespace Productivity.Domain.EpicAggregate.ValueObjects;
public sealed class EpicCommentId : ValueObject
{
    public Guid Value { get; }

    private EpicCommentId(Guid value)
    {
        Value = value;
    }

    public static EpicCommentId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}