using Productivity.Domain.Common.Models;

namespace Productivity.Domain.EpicAggregate.Entities;
public sealed class SubtaskDependency : Entity<SubtaskDependencyId>
{
    public SubtaskId DependentId { get; private set; }
    public SubtaskId PrerequisiteId { get; private set; }
    public string? Reason { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private SubtaskDependency(SubtaskDependencyId id, SubtaskId dependentId, SubtaskId prerequisiteId, string? reason = null) : base(id)
    {
        DependentId = dependentId;
        PrerequisiteId = prerequisiteId;
        Reason = reason;
        CreatedAt = DateTime.UtcNow;
    }

    public static SubtaskDependency Create(SubtaskId dependentId, SubtaskId prerequisiteId, string? reason = null)
    {
        return new(SubtaskDependencyId.CreateUnique(), dependentId, prerequisiteId, reason);
    }
}