using Productivity.Domain.Common.Models;

namespace Productivity.Domain.Common.ValueObjects;
public sealed class FileId : ValueObject
{
    public Guid Value { get; }

    private FileId(Guid value)
    {
        Value = value;
    }

    public static FileId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}