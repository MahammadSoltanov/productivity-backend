using Productivity.Domain.Common.Enumerations;
using Productivity.Domain.Common.Models;
using Productivity.Domain.Common.ValueObjects;

namespace Productivity.Domain.WorkspaceAggregate.Entities;

public sealed class TeamWorkspaceMembership : Entity<TeamWorkspaceMembershipId>
{
    public TeamId TeamId { get; }
    public DateRange ValidityPeriod { get; }
    public MembershipStatus Status { get; private set; }

    private TeamWorkspaceMembership(
        TeamWorkspaceMembershipId id,
        TeamId teamId,
        DateRange validityPeriod
    ) : base(id)
    {
        TeamId = teamId;
        ValidityPeriod = validityPeriod;
    }

    public static TeamWorkspaceMembership Create(
        TeamId teamId,
        DateTime validFrom,
        DateTime? validTo = null
    )
    {
        var period = new DateRange(validFrom, validTo);
        return new TeamWorkspaceMembership(
            TeamWorkspaceMembershipId.CreateUnique(),
            teamId,
            period
        );
    }

    public bool IsActiveAt(DateTime at) => ValidityPeriod.IsWithinRange(at);
}