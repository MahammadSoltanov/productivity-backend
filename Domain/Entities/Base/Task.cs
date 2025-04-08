using Domain.Entities.Relations;
using Domain.Enumerations;

namespace Domain.Entities.Base;

public abstract class Task : AuditableEntity
{
    protected Task(string title, Workspace workspace, User creator)
    {
        Title = title;
        Workspace = workspace;
        Creator = creator;
    }

    public string Title { get; set; }

    public string? Description { get; set; }
    public TaskStatus Status { get; set; } = TaskStatus.Pending;
    public TaskPriority Priority { get; set; } = TaskPriority.Medium;
    public Workspace Workspace { get; set; }
    public Guid WorkspaceId { get; set; }
    public Guid CreatorId { get; set; }
    public User Creator { get; set; }
    public Guid AssigneeId { get; set; }
    public User? Assignee { get; set; }
    public DateTime EstimatedStartDate { get; set; }
    public DateTime EstimatedCompletionDate { get; set; }
    public DateTime ActualStartDate { get; set; }
    public DateTime ActualCompletionDate { get; set; }
    public ICollection<string> Tags { get; set; } = new List<string>();
    public ICollection<TaskAttachment> TaskAttachments { get; set; } = new List<TaskAttachment>();
    public ICollection<TaskDependency> TaskDependencies { get; set; } = new List<TaskDependency>();
}
