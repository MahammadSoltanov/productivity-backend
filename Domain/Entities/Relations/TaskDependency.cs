using Domain.Entities.Base;
using Domain.Enumerations;

namespace Domain.Entities.Relations;

public sealed class TaskDependency : Entity
{
    public Guid TaskId { get; set; }
    public Task Task { get; set; }
    public Guid DependentTaskId { get; set; }
    public Task DependentTask { get; set; }
    public TaskType DependentTaskType { get; set; }
}
