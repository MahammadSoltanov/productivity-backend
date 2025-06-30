using Productivity.Domain.Common.Models;
using Productivity.Domain.Common.ValueObjects;

namespace Productivity.Domain.WorkspaceAggregate.Entities;

public sealed class TeamWorkspaceMembership : Entity<TeamWorkspaceMembershipId>
{
    public TeamId TeamId { get; }
    public WorkspaceId WorkspaceId { get; }
    public DateRange ValidityPeriod { get; }

    private TeamWorkspaceMembership(
        TeamWorkspaceMembershipId id,
        TeamId teamId,
        WorkspaceId workspaceId,
        DateRange validityPeriod
    ) : base(id)
    {
        TeamId = teamId;
        WorkspaceId = workspaceId;
        ValidityPeriod = validityPeriod;
    }

    public static TeamWorkspaceMembership Create(
        TeamId teamId,
        WorkspaceId workspaceId,
        DateTime validFrom,
        DateTime? validTo = null
    )
    {
        var period = new DateRange(validFrom, validTo);
        return new TeamWorkspaceMembership(
            TeamWorkspaceMembershipId.CreateUnique(),
            teamId,
            workspaceId,
            period
        );
    }

    public bool IsActiveAt(DateTime at) => ValidityPeriod.IsWithinRange(at);
}