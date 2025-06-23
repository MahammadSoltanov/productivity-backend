using Productivity.Domain.Constants.Story;
using Productivity.Domain.Entities.Relations;
using Productivity.Domain.Enumerations;
using Productivity.Domain.Exceptions.Task;

namespace Productivity.Domain.Entities;

public sealed class Story : Task
{
    private ICollection<TaskDependency> _taskDependencies = new List<TaskDependency>();

    public Story(string title, Guid workspaceId, Guid creatorId, Guid epicId) : base(title, workspaceId, creatorId)
    {
        EpicId = epicId;
    }

    public new ICollection<TaskDependency> TaskDependencies
    {
        get => _taskDependencies;
        set
        {
            if (value.Any(td => td.DependentTaskType != TaskType.Story))
            {
                throw new InvalidTaskDependencyException(StoryErrorMessages.InvalidStoryDependency);
            }

            _taskDependencies = value;
        }
    }

    public ICollection<Subtask>? Subtasks { get; set; }
    public Guid EpicId { get; private set; }
    public Epic Epic { get; }
}
