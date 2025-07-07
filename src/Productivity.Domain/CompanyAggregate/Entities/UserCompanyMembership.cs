using Productivity.Domain.Common.Models;
using Productivity.Domain.CompanyAggregate.Enumerations;

namespace Productivity.Domain.CompanyAggregate.Entities;
public class UserCompanyMembership : Entity<UserCompanyMembershipId>
{
    public UserId UserId { get; }
    public CompanyRole Role { get; private set; }

    public UserCompanyMembership(UserCompanyMembershipId id, UserId userId, CompanyRole role) : base(id)
    {
        UserId = userId;
        Role = role;
    }

    public static UserCompanyMembership Create(UserId userId, CompanyRole role)
    {
        return new(UserCompanyMembershipId.CreateUnique(), userId, role);
    }
}
