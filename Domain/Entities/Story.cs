using Domain.Constants.Story;
using Domain.Entities.Relations;
using Domain.Enumerations;
using Domain.Exceptions.Task;

namespace Domain.Entities;

public sealed class Story : Task
{
    private ICollection<TaskDependency> _taskDependencies = new List<TaskDependency>();

    public Story(string title, Workspace workspace, User creator, Guid epicId) : base(title, workspace, creator)
    {
        EpicId = epicId;
    }

    public new ICollection<TaskDependency> TaskDependencies
    {
        get => _taskDependencies;
        set
        {
            if (value.Any(td => td.DependentTaskType != TaskType.Story))
                throw new InvalidTaskDependencyException(StoryErrorMessages.InvalidStoryDependency);
            _taskDependencies = value;
        }
    }

    public ICollection<Subtask>? Subtasks { get; set; }
    public Guid EpicId { get; private set; }
}
