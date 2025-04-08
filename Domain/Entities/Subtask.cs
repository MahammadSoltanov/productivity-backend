using Domain.Entities.Relations;
using Domain.Enumerations;
using Domain.Exceptions.Task;

namespace Domain.Entities;

public sealed class Subtask : Task
{
    private ICollection<TaskDependency> _taskDependencies = new List<TaskDependency>();

    public Subtask(User assignee, string title, Workspace workspace, User creator) : base(title, workspace, creator)
    {
        Assignee = assignee;
    }

    public new ICollection<TaskDependency> TaskDependencies
    {
        get => _taskDependencies;
        set
        {
            if (value.Any(td => td.DependentTaskType != TaskType.Subtask))
                throw new InvalidTaskDependencyException("Subtasks can only have dependencies of type Subtask.");
            _taskDependencies = value;
        }
    }

    public Story? Story { get; set; }
    public Epic? Epic { get; set; }
    public new User Assignee { get; set; }
}
