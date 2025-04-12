using Domain.Entities.Relations;
using Domain.Enumerations;
using Domain.Exceptions.Task;

namespace Domain.Entities;

public sealed class Subtask : Task
{
    private ICollection<TaskDependency> _taskDependencies = new List<TaskDependency>();

    public Subtask(User assignee, string title, Workspace workspace, User creator, Story story) : base(title, workspace, creator)
    {
        Assignee = assignee;
    }

    public new ICollection<TaskDependency> TaskDependencies
    {
        get => _taskDependencies;
        set
        {
            if (value.Any(td => td.DependentTaskType != TaskType.Subtask))
                throw new InvalidTaskDependencyException();
            _taskDependencies = value;
        }
    }

    public Guid? StoryId { get; set; }
    public Guid? EpicId { get; set; }
    public new User Assignee { get; set; }
}
