using Productivity.Domain.Constants.Subtask;
using Productivity.Domain.Entities.Relations;
using Productivity.Domain.Enumerations;
using Productivity.Domain.Exceptions.Task;

namespace Productivity.Domain.Entities;

public sealed class Subtask : Task
{
    private ICollection<TaskDependency> _taskDependencies = new List<TaskDependency>();

    public Subtask(User assignee, string title, Guid workspaceId, Guid creatorId, Story story) : base(title, workspaceId, creatorId)
    {
        Assignee = assignee;
    }

    public new ICollection<TaskDependency> TaskDependencies
    {
        get => _taskDependencies;
        set
        {
            if (value.Any(td => td.DependentTaskType != TaskType.Subtask))
            {
                throw new InvalidTaskDependencyException(SubtaskErrorMessages.InvalidSubtaskDependency);
            }

            _taskDependencies = value;
        }
    }

    public Guid? StoryId { get; set; }
    public Story? Story { get; }
    public Guid? EpicId { get; set; }
    public Epic? Epic { get; }
    public new Guid AssigneeId { get; set; }
    public new User Assignee { get; }
}
