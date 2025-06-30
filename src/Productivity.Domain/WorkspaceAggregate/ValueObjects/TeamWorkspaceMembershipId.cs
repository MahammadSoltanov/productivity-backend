using Productivity.Domain.Common.Models;

namespace Productivity.Domain.WorkspaceAggregate.ValueObjects;
public sealed class TeamWorkspaceMembershipId : ValueObject
{
    public Guid Value { get; }

    private TeamWorkspaceMembershipId(Guid value)
    {
        Value = value;
    }

    public static TeamWorkspaceMembershipId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}