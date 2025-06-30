using Productivity.Domain.Common.Models;
using Productivity.Domain.Common.ValueObjects;
using Productivity.Domain.Enumerations;

namespace Productivity.Domain.WorkspaceAggregate.Entities;
public sealed class UserWorkspaceMembership : Entity<UserWorkspaceMembershipId>
{
    public UserId UserId { get; }
    public WorkspaceId WorkspaceId { get; }
    public WorkspaceRole Role { get; }
    public DateRange ValidityPeriod { get; }

    private UserWorkspaceMembership(
        UserWorkspaceMembershipId id,
        UserId userId,
        WorkspaceId workspaceId,
        WorkspaceRole role,
        DateRange validityPeriod
    ) : base(id)
    {
        UserId = userId;
        WorkspaceId = workspaceId;
        Role = role;
        ValidityPeriod = validityPeriod;
    }

    public static UserWorkspaceMembership Create(
        UserId userId,
        WorkspaceId workspaceId,
        WorkspaceRole role,
        DateTime validFrom,
        DateTime? validTo = null
    )
    {
        var period = new DateRange(validFrom, validTo);
        return new UserWorkspaceMembership(
            UserWorkspaceMembershipId.CreateUnique(),
            userId,
            workspaceId,
            role,
            period
        );
    }

    public bool IsActiveAt(DateTime at) => ValidityPeriod.IsWithinRange(at);
}