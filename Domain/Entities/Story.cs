using Domain.Entities.Relations;
using Domain.Enumerations;
using Domain.Exceptions.Task;

namespace Domain.Entities;

public sealed class Story : Task
{
    private ICollection<TaskDependency> _taskDependencies = new List<TaskDependency>();

    public Story(string title, Workspace workspace, User creator, Epic epic) : base(title, workspace, creator)
    {
        Epic = epic;
    }

    public new ICollection<TaskDependency> TaskDependencies
    {
        get => _taskDependencies;
        set
        {
            if (value.Any(td => td.DependentTaskType != TaskType.Story))
                throw new InvalidTaskDependencyException("Stories can only have dependencies of type Story.");
            _taskDependencies = value;
        }
    }

    public ICollection<Subtask>? Subtasks { get; set; }

    public Epic Epic { get; set; }
}
