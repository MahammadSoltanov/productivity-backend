using Domain.Entities.Relations;
using Domain.Enumerations;
using Domain.Exceptions.Task;

namespace Domain.Entities;

public sealed class Epic : Task
{
    private ICollection<TaskDependency> _taskDependencies = new List<TaskDependency>();

    public ICollection<TaskDependency> TaskDependencies
    {
        get => _taskDependencies;
        set
        {
            if (value.Any(td => td.DependentTaskType != TaskType.Epic))
                throw new InvalidTaskDependencyException("Epics can only have dependencies of type Epic.");
            _taskDependencies = value;
        }
    }


    public ICollection<Story>? Stories { get; set; }
}
