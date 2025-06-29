using Productivity.Domain.Common.Models;

namespace Productivity.Domain.WorkspaceAggregate.ValueObjects;
public sealed class WorkspaceId : ValueObject
{
    public Guid Value { get; }

    private WorkspaceId(Guid value)
    {
        Value = value;
    }

    public static WorkspaceId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
