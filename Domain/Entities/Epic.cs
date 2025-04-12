using Domain.Constants.Epic;
using Domain.Entities.Relations;
using Domain.Enumerations;
using Domain.Exceptions.Task;

namespace Domain.Entities;

public sealed class Epic : Task
{
    private ICollection<TaskDependency> _taskDependencies = new List<TaskDependency>();

    public Epic(string title, Workspace workspace, User creator) : base(title, workspace, creator)
    {
    }

    public new ICollection<TaskDependency> TaskDependencies
    {
        get => _taskDependencies;
        set
        {
            if (value.Any(td => td.DependentTaskType != TaskType.Epic))
                throw new InvalidTaskDependencyException(EpicErrorMessages.InvalidEpicDependency);
            _taskDependencies = value;
        }
    }


    public ICollection<Story> Stories { get; set; } = new List<Story>();
    public ICollection<Subtask> Subtasks { get; set; } = new List<Subtask>();
}
