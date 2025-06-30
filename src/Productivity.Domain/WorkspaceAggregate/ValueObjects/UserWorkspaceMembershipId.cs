using Productivity.Domain.Common.Models;

namespace Productivity.Domain.WorkspaceAggregate.ValueObjects;
public sealed class UserWorkspaceMembershipId : ValueObject
{
    public Guid Value { get; }

    private UserWorkspaceMembershipId(Guid value)
    {
        Value = value;
    }

    public static UserWorkspaceMembershipId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}