using Domain.Entities.Base;
using Domain.Enumerations;

namespace Domain.Entities.Relations;

public sealed class TaskDependency : Entity
{
    public TaskDependency(Task task, Task dependentTask, TaskType dependentTaskType)
    {
        Task = task;
        TaskId = task.Id;
        DependentTask = dependentTask;
        DependentTaskId = dependentTask.Id;
        DependentTaskType = dependentTaskType;
    }

    public Guid TaskId { get; set; }
    public Task Task { get; set; }
    public Guid DependentTaskId { get; set; }
    public Task DependentTask { get; set; }
    public TaskType DependentTaskType { get; set; }
}
