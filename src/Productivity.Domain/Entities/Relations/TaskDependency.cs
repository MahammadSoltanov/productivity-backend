using Productivity.Domain.Enumerations;

namespace Productivity.Domain.Entities.Relations;

public sealed class TaskDependency /*: Entity*/
{
    public TaskDependency(Guid taskId, Guid dependentTaskId, TaskType dependentTaskType)
    {
        TaskId = taskId;
        DependentTaskId = dependentTaskId;
        DependentTaskType = dependentTaskType;
    }

    public Guid TaskId { get; set; }
    public TaskBase Task { get; set; }
    public Guid DependentTaskId { get; set; }
    public TaskBase DependentTask { get; set; }
    public TaskType DependentTaskType { get; set; }
}
