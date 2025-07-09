using Productivity.Domain.Common.Exceptions;
using Productivity.Domain.Common.Models;

namespace Productivity.Domain.Common.ValueObjects;
public sealed class TaskStatusProgression : ValueObject
{
    static readonly TaskStatus[] _order = new[]
    {
        TaskStatus.Backlog,
        TaskStatus.InProgress,
        TaskStatus.Paused,
        TaskStatus.Completed
    };

    public TaskStatus Current { get; }

    private TaskStatusProgression(TaskStatus status) => Current = status;

    public static TaskStatusProgression Initial() => new(TaskStatus.Backlog);

    public TaskStatusProgression Start()
    {
        if (Current != TaskStatus.Backlog)
        {
            throw new DomainException($"Cannot start from {Current}");
        }

        return new(TaskStatus.InProgress);
    }

    public TaskStatusProgression Pause()
    {
        if (Current != TaskStatus.InProgress)
        {
            throw new DomainException($"Cannot pause from {Current}");
        }

        return new(TaskStatus.Paused);
    }

    public TaskStatusProgression Resume()
    {
        if (Current != TaskStatus.Paused)
        {
            throw new DomainException($"Cannot resume from {Current}");
        }

        return new(TaskStatus.InProgress);
    }

    public TaskStatusProgression Complete()
    {
        if (Current == TaskStatus.Completed)
            return this;
        var currentIndex = Array.IndexOf(_order, Current);
        var completedIndex = Array.IndexOf(_order, TaskStatus.Completed);
        if (currentIndex > completedIndex)
        {
            throw new DomainException($"Invalid transition from {Current} to Completed");
        }

        return new(TaskStatus.Completed);
    }

    public TaskStatusProgression Next()
    {
        var idx = Array.IndexOf(_order, Current);

        if (idx < 0 || idx + 1 >= _order.Length)
        {
            throw new DomainException($"No next status defined after {Current}");
        }

        return new(_order[idx + 1]);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Current;
    }
}