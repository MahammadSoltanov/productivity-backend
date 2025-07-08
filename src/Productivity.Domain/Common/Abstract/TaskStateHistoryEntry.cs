using Productivity.Domain.Common.Enumerations;
using Productivity.Domain.Common.Exceptions;
using Productivity.Domain.Common.Models;
using Productivity.Domain.Common.ValueObjects;

namespace Productivity.Domain.Common.Abstract;

public abstract class TaskStateHistoryEntry<TId, TTaskId> : Entity<TId> where TId : notnull
{
    public TTaskId TaskId { get; }
    public TaskStatus Status { get; }
    public TaskPriority Priority { get; }
    public DateRange ValidityPeriod { get; private set; }

    internal TaskStateHistoryEntry(TId id, TTaskId taskId, TaskStatus status, TaskPriority priority, DateRange validityPeriod) : base(id)
    {
        TaskId = taskId;
        Status = status;
        Priority = priority;
        ValidityPeriod = validityPeriod;
    }

    public void ClosePeriod(DateTime end)
    {
        if (ValidityPeriod.To.HasValue)
        {
            throw new DomainException("History entry already closed.");
        }

        ValidityPeriod = new DateRange(ValidityPeriod.From, end);
    }
}
