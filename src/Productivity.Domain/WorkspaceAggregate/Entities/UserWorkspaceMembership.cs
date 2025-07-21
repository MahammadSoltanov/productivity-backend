using Productivity.Domain.Common.Enumerations;
using Productivity.Domain.Common.Exceptions;
using Productivity.Domain.Common.Models;
using Productivity.Domain.Common.Time;
using Productivity.Domain.Common.ValueObjects;
using Productivity.Domain.WorkspaceAggregate.Enumerations;

namespace Productivity.Domain.WorkspaceAggregate.Entities;
public sealed class UserWorkspaceMembership : Entity<UserWorkspaceMembershipId>
{
    public UserId UserId { get; }
    public WorkspaceRole Role { get; }
    public DateRange ValidityPeriod { get; private set; }
    public MembershipStatus Status { get; private set; }

    private UserWorkspaceMembership(
        UserWorkspaceMembershipId id,
        UserId userId,
        WorkspaceRole role,
        DateRange validityPeriod
    ) : base(id)
    {
        UserId = userId;
        Role = role;
        ValidityPeriod = validityPeriod;
    }

    public static UserWorkspaceMembership Create(UserId userId,
                                                 WorkspaceRole role,
                                                 DateTimeOffset validFrom,
                                                 DateTimeOffset? validTo = null)
    {
        var period = new DateRange(validFrom, validTo);
        return new UserWorkspaceMembership(
            UserWorkspaceMembershipId.CreateUnique(),
            userId,
            role,
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