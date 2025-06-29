using Productivity.Domain.CompanyAggregate.ValueObjects;
using Productivity.Domain.UserAggregate.ValueObjects;

namespace Productivity.Domain.CompanyAggregate.Entities;
public sealed class UserCompanyMembership
{
    public UserId UserId { get; }
    public CompanyId CompanyId { get; }

    public UserCompanyMembership(UserId userId, CompanyId companyId)
    {
        UserId = userId;
        CompanyId = companyId;
    }
}
