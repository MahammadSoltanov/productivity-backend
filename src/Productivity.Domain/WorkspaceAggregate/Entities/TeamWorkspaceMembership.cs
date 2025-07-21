using Productivity.Domain.Common.Enumerations;
using Productivity.Domain.Common.Exceptions;
using Productivity.Domain.Common.Models;
using Productivity.Domain.Common.Time;
using Productivity.Domain.Common.ValueObjects;

namespace Productivity.Domain.WorkspaceAggregate.Entities;

public sealed class TeamWorkspaceMembership : Entity<TeamWorkspaceMembershipId>
{
    public TeamId TeamId { get; }
    public DateRange ValidityPeriod { get; private set; }
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
        DateTimeOffset validFrom,
        DateTimeOffset? validTo = null
    )
    {
        var period = new DateRange(validFrom, validTo);
        return new TeamWorkspaceMembership(
            TeamWorkspaceMembershipId.CreateUnique(),
            teamId,
            period
        );
    }

    public bool IsActiveAt(DateTimeOffset at) => ValidityPeriod.IsWithinRange(at);

    public void End()
    {
        if (Status != MembershipStatus.Active)
        {
            throw new DomainException("Only active memberships can be ended.");
        }

        Status = MembershipStatus.Removed;

        ValidityPeriod = new DateRange(ValidityPeriod.From, DomainTime.Current.UtcNow);
    }
}