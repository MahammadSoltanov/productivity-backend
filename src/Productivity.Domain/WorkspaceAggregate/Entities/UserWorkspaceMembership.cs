using Productivity.Domain.Common.Enumerations;
using Productivity.Domain.Common.Models;
using Productivity.Domain.Common.ValueObjects;
using Productivity.Domain.WorkspaceAggregate.Enumerations;

namespace Productivity.Domain.WorkspaceAggregate.Entities;
public sealed class UserWorkspaceMembership : Entity<UserWorkspaceMembershipId>
{
    public UserId UserId { get; }
    public WorkspaceRole Role { get; }
    public DateRange ValidityPeriod { get; }
    public MembershipStatus Status { get; private set; }

    private UserWorkspaceMembership(
        UserWorkspaceMembershipId id,
        WorkspaceRole role,
        DateRange validityPeriod
    ) : base(id)
    {
        Role = role;
        ValidityPeriod = validityPeriod;
    }

    public static UserWorkspaceMembership Create(
        WorkspaceRole role,
        DateTime validFrom,
        DateTime? validTo = null
    )
    {
        var period = new DateRange(validFrom, validTo);
        return new UserWorkspaceMembership(
            UserWorkspaceMembershipId.CreateUnique(),
            role,
            period
        );
    }

    public bool IsActiveAt(DateTime at) => ValidityPeriod.IsWithinRange(at);
}