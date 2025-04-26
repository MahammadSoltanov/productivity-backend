using Domain.Entities.Base;
using Domain.Entities.Relations;
using Domain.Enumerations;

namespace Domain.Entities.Abstract;

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
    public TaskStatus Status { get; private set; } = TaskStatus.Pending;
    public TaskPriority Priority { get; set; } = TaskPriority.Medium;
    public Guid WorkspaceId { get; private set; }
    public Workspace? Workspace { get; private set; }
    public Guid CreatorId { get; set; }
    public User? Creator { get; set; }
    public Guid AssigneeId { get; set; }
    public User? Assignee { get; set; }
    public DateTime EstimatedStartDate { get; set; }
    public DateTime EstimatedCompletionDate { get; set; }
    public DateTime ActualStartDate { get; set; }
    public DateTime ActualCompletionDate { get; set; }
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
