using Productivity.Domain.Common.Enumerations;
using Productivity.Domain.Common.Models;
using Productivity.Domain.Common.ValueObjects;
using Productivity.Domain.TeamAggregate.Enumerations;

namespace Productivity.Domain.TeamAggregate.Entities;

public sealed class UserTeamMembership : Entity<UserTeamMembershipId>
{
    public UserId UserId { get; }
    public TeamRole Role { get; }
    public DateRange ValidityPeriod { get; }
    public MembershipStatus Status { get; private set; }

    private UserTeamMembership(UserTeamMembershipId id,
                               UserId userId,
                               TeamRole role,
                               DateRange validityPeriod) : base(id)
    {
        UserId = userId;
        Role = role;
        ValidityPeriod = validityPeriod;
    }

    public static UserTeamMembership Create(UserId userId,
                                            TeamRole role,
                                            DateRange validityPeriod)
    {
        return new UserTeamMembership(UserTeamMembershipId.CreateUnique(),
                                      userId,
                                      role,
                                      validityPeriod);
    }

    public bool IsActiveAt(DateTime at) => ValidityPeriod.IsWithinRange(at);
}
