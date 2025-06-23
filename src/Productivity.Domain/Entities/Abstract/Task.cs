using Productivity.Domain.Entities.Base;
using Productivity.Domain.Entities.Relations;
using Productivity.Domain.Enumerations;

namespace Productivity.Domain.Entities.Abstract;

public abstract class Task : AuditableEntity
{
    protected Task(string title, Guid workspaceId, Guid creatorId)
    {
        Title = title;
        WorkspaceId = workspaceId;
        CreatorId = creatorId;
    }

    public string Title { get; set; }
    public string? Description { get; set; }

    public TaskStatus Status { get; protected set; } = TaskStatus.Pending;
    public TaskPriority Priority { get; set; } = TaskPriority.Medium;

    public User? Creator { get; protected set; }

    public Guid WorkspaceId { get; protected set; }
    public Workspace? Workspace { get; protected set; }

    public Guid AssigneeId { get; protected set; }
    public User? Assignee { get; protected set; }

    public DateTime EstimatedStartDate { get; protected set; }
    public DateTime EstimatedCompletionDate { get; protected set; }
    public DateTime ActualStartDate { get; protected set; }
    public DateTime ActualCompletionDate { get; protected set; }

    public ICollection<string> Tags { get; set; } = new List<string>();
    public ICollection<TaskAttachment> TaskAttachments { get; set; } = new List<TaskAttachment>();
    public ICollection<TaskDependency> TaskDependencies { get; set; } = new List<TaskDependency>();

    internal void StartTask()
    {

    }

    internal void PauseTask()
    {

    }

    internal void CompleteTask()
    {

    }
}
