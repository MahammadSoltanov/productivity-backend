using Productivity.Domain.Common.Models;
using Productivity.Domain.Common.ValueObjects;
using Productivity.Domain.Enumerations;

namespace Productivity.Domain.Common.Abstract;

public abstract class TaskStateHistoryEntry<TId, TTaskId> : Entity<TId>
{
    public TTaskId TaskId { get; }
    public DateRange ValidityPeriod { get; }
    public TaskStatus Status { get; }
    public TaskPriority Priority { get; }

    public TaskStateHistoryEntry(TId id, TTaskId taskId, TaskStatus status, TaskPriority priority, DateRange validityPeriod) : base(id)
    {
        TaskId = taskId;
        Status = status;
        Priority = priority;
        ValidityPeriod = validityPeriod;
    }
}
