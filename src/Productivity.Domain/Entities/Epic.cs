using Productivity.Domain.Constants.Epic;
using Productivity.Domain.Entities.Relations;
using Productivity.Domain.Enumerations;
using Productivity.Domain.Exceptions.Task;

namespace Productivity.Domain.Entities;

public sealed class Epic : Task
{
    private ICollection<TaskDependency> _taskDependencies = new List<TaskDependency>();

    public Epic(string title, Guid workspaceId, Guid creatorId) : base(title, workspaceId, creatorId)
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

    //If this property is true then the Assignee user of the Epic should be a team leader in a team that is within the given workspace.
    //If the value of the property is set to "true", then the team leader gains access to assign tasks to the team within the given epic.
    public bool IsAssignedToTeam { get; private set; }
    public ICollection<Story> Stories { get; set; } = new List<Story>();
    public ICollection<Subtask> Subtasks { get; set; } = new List<Subtask>();
}
