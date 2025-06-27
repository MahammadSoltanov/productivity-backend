using Productivity.Domain.Common.Models;

namespace Productivity.Domain.Company.ValueObjects;
public sealed class CompanyId : ValueObject
{
    public CompanyId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }



    public static CompanyId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}
