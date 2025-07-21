using Productivity.Domain.Common.Models;
using Productivity.Domain.Common.Time;

namespace Productivity.Domain.EpicAggregate.Entities;
public sealed class EpicDependency : Entity<EpicDependencyId>
{
    public EpicId DependentId { get; }
    public EpicId PrerequisiteId { get; }
    public string? Reason { get; }
    public DateTimeOffset CreatedAt { get; }
    public UserId CreatorId { get; }
    internal EpicDependency(EpicDependencyId id,
                            EpicId dependentId,
                            EpicId prerequisiteId,
                            UserId creatorId,
                            string? reason = null) : base(id)
    {
        DependentId = dependentId;
        PrerequisiteId = prerequisiteId;
        CreatorId = creatorId;
        Reason = reason;
        CreatedAt = DomainTime.Current.UtcNow;
    }

    public static EpicDependency Create(EpicId dependentId,
                                        EpicId prerequisiteId,
                                        UserId creatorId,
                                        string? reason = null)
    {
        return new(EpicDependencyId.CreateUnique(),
                   dependentId,
                   prerequisiteId,
                   creatorId,
                   reason);
    }
}