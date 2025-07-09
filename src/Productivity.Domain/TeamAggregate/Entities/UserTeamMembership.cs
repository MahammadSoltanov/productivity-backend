using Productivity.Domain.Common.Enumerations;
using Productivity.Domain.Common.Exceptions;
using Productivity.Domain.Common.Models;
using Productivity.Domain.Common.ValueObjects;
using Productivity.Domain.TeamAggregate.Enumerations;

namespace Productivity.Domain.TeamAggregate.Entities;

public sealed class UserTeamMembership : Entity<UserTeamMembershipId>
{
    public UserId UserId { get; }
    public TeamRole Role { get; }
    public DateRange ValidityPeriod { get; private set; }
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

    public void End()
    {
        if (Status != MembershipStatus.Active)
        {
            throw new DomainException("Only active memberships can be ended.");
        }

        Status = MembershipStatus.Removed;

        ValidityPeriod = new DateRange(ValidityPeriod.From, DateTime.UtcNow);
    }
}