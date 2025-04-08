using Domain.Entities.Relations;
using Domain.Enumerations;
using Domain.Exceptions.Task;

namespace Domain.Entities;

public sealed class Subtask : Task
{
    private ICollection<TaskDependency> _taskDependencies = new List<TaskDependency>();

    public ICollection<TaskDependency> TaskDependencies
    {
        get => _taskDependencies;
        set
        {
            if (value.Any(td => td.DependentTaskType != TaskType.Subtask))
                throw new InvalidTaskDependencyException("Subtasks can only have dependencies of type Subtask.");
            _taskDependencies = value;
        }
    }

    public Story Story { get; set; }
}
