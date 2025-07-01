using Productivity.Domain.Common.Models;
using Productivity.Domain.Common.ValueObjects;
using Productivity.Domain.Enumerations;

namespace Productivity.Domain.TeamAggregate.Entities;

public sealed class UserTeamMembership : Entity<UserTeamMembershipId>
{
    public UserId UserId { get; }
    public TeamId TeamId { get; }
    public TeamRole Role { get; }
    public DateRange ValidityPeriod { get; }

    private UserTeamMembership(UserTeamMembershipId id,
                               UserId userId,
                               TeamId teamId,
                               TeamRole role,
                               DateRange validityPeriod) : base(id)
    {
        UserId = userId;
        TeamId = teamId;
        Role = role;
        ValidityPeriod = validityPeriod;
    }

    public static UserTeamMembership Create(UserId userId,
                                            TeamId teamId,
                                            TeamRole role,
                                            DateRange validityPeriod)
    {
        return new UserTeamMembership(UserTeamMembershipId.CreateUnique(),
                                      userId,
                                      teamId,
                                      role,
                                      validityPeriod);
    }

    public bool IsActiveAt(DateTime at) => ValidityPeriod.IsWithinRange(at);
}
