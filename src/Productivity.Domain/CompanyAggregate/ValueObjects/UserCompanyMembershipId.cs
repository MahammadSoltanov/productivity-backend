using Productivity.Domain.Common.Models;

namespace Productivity.Domain.CompanyAggregate.ValueObjects;
public sealed class UserCompanyMembershipId : ValueObject
{
    public Guid Value { get; }

    private UserCompanyMembershipId(Guid value)
    {
        Value = value;
    }

    public static UserCompanyMembershipId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
