using Productivity.Domain.Common.Models;
using Productivity.Domain.Common.Time;

namespace Productivity.Domain.StoryAggregate.Entities;
public sealed class StoryDependency : Entity<StoryDependencyId>
{
    public StoryId DependentId { get; }
    public StoryId PrerequisiteId { get; }
    public string? Reason { get; }
    public UserId CreatorId { get; set; }
    public DateTimeOffset CreatedAt { get; }

    private StoryDependency(StoryDependencyId id,
                            StoryId dependentId,
                            StoryId prerequisiteId,
                            UserId creatorId,
                            string? reason = null) : base(id)
    {
        DependentId = dependentId;
        PrerequisiteId = prerequisiteId;
        CreatorId = creatorId;
        Reason = reason;
        CreatedAt = DomainTime.Current.UtcNow;
    }

    public static StoryDependency Create(StoryId dependentId, StoryId prerequisiteId, UserId creatorId, string? reason = null)
    {
        return new(StoryDependencyId.CreateUnique(), dependentId, prerequisiteId, creatorId, reason);
    }
}