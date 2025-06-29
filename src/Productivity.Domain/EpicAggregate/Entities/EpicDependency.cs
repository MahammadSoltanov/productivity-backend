namespace Productivity.Domain.EpicAggregate.Entities;
public sealed class EpicDependency
{
    public EpicId EpicId { get; private set; }
    public EpicId PrerequisiteId { get; private set; }
    public string? Reason { get; private set; }
    public DateTime CreatedAt { get; private set; }

    internal EpicDependency(EpicId epicId, EpicId prerequisiteId, string? reason = null)
    {
        EpicId = epicId;
        PrerequisiteId = prerequisiteId;
        Reason = reason;
        CreatedAt = DateTime.UtcNow;
    }
}
