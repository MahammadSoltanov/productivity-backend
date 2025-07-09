using Productivity.Domain.Common.Models;

namespace Productivity.Domain.CompanyAggregate.ValueObjects;
public sealed class CompanyId : ValueObject
{
    public Guid Value { get; }

    private CompanyId(Guid value)
    {
        Value = value;
    }

    public static CompanyId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}