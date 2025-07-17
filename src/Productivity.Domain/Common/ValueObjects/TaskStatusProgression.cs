using Productivity.Domain.Common.Exceptions;
using Productivity.Domain.Common.Models;

namespace Productivity.Domain.Common.ValueObjects;
public sealed class TaskStatusProgression : ValueObject
{
    private static readonly TaskStatus[] _order = new[]
    {
        TaskStatus.Backlog,
        TaskStatus.Planned,
        TaskStatus.InProgress,
        TaskStatus.Awaiting,
        TaskStatus.Completed,
        TaskStatus.Archived
    };

    public TaskStatus Current { get; }

    private TaskStatusProgression(TaskStatus status) => Current = status;

    public static TaskStatusProgression Initial() => new(TaskStatus.Backlog);

    public TaskStatusProgression Plan()
    {
        if (Current != TaskStatus.Backlog)
        {
            throw new DomainException($"Cannot move to Planned from {Current}.");
        }
        return new(TaskStatus.Planned);
    }

    public TaskStatusProgression Start()
    {
        if (Current != TaskStatus.Planned)
        {
            throw new DomainException($"Cannot start from {Current}.");
        }

        return new(TaskStatus.InProgress);
    }

    public TaskStatusProgression Await()
    {
        if (Current != TaskStatus.InProgress)
        {
            throw new DomainException($"Cannot move to Awaiting from {Current}.");
        }

        return new(TaskStatus.Awaiting);
    }

    public TaskStatusProgression Resume()
    {
        if (Current != TaskStatus.Awaiting)
        {
            throw new DomainException($"Cannot resume from {Current}.");
        }

        return new(TaskStatus.InProgress);
    }

    public TaskStatusProgression Complete()
    {
        if (Current == TaskStatus.Completed || Current == TaskStatus.Archived)
        {
            return this;
        }

        var currentIndex = Array.IndexOf(_order, Current);
        var completedIndex = Array.IndexOf(_order, TaskStatus.Completed);

        if (currentIndex < 0 || currentIndex > completedIndex)
        {
            throw new DomainException($"Invalid transition from {Current} to Completed.");
        }

        return new(TaskStatus.Completed);
    }

    public TaskStatusProgression Archive()
    {
        if (Current != TaskStatus.Completed)
        {
            throw new DomainException($"Can only archive from Completed, not {Current}.");
        }

        return new(TaskStatus.Archived);
    }

    public TaskStatusProgression Next()
    {
        var idx = Array.IndexOf(_order, Current);

        if (idx < 0 || idx + 1 >= _order.Length)
        {
            throw new DomainException($"No next status defined after {Current}.");
        }

        return new(_order[idx + 1]);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Current;
    }
}