using Productivity.Domain.Common.Models;

namespace Productivity.Domain.WorkspaceAggregate.ValueObjects;
public sealed class UserTeamMembershipId : ValueObject
{
    public Guid Value { get; }

    private UserTeamMembershipId(Guid value)
    {
        Value = value;
    }

    public static UserTeamMembershipId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}