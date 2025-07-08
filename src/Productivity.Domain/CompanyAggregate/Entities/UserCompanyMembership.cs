using Productivity.Domain.Common.Enumerations;
using Productivity.Domain.Common.Exceptions;
using Productivity.Domain.Common.Models;
using Productivity.Domain.Common.ValueObjects;
using Productivity.Domain.CompanyAggregate.Enumerations;

namespace Productivity.Domain.CompanyAggregate.Entities;
public class UserCompanyMembership : Entity<UserCompanyMembershipId>
{
    public UserId UserId { get; }
    public CompanyRole Role { get; private set; }
    public MembershipStatus Status { get; private set; }
    public DateRange ValidityPeriod { get; private set; }

    private UserCompanyMembership(UserCompanyMembershipId id, UserId userId, CompanyRole role) : base(id)
    {
        UserId = userId;
        Role = role;
        ValidityPeriod = new DateRange(DateTime.UtcNow);
    }

    public static UserCompanyMembership Create(UserId userId, CompanyRole role)
    {
        return new(UserCompanyMembershipId.CreateUnique(), userId, role);
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
