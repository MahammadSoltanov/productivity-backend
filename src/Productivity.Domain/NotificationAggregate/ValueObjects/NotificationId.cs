using Productivity.Domain.Common.Models;

namespace Productivity.Domain.StoryAggregate.ValueObjects;
public sealed class NotificationId : ValueObject
{
    public Guid Value { get; }

    private NotificationId(Guid value)
    {
        Value = value;
    }

    public static NotificationId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}