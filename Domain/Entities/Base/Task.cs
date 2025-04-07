namespace Domain.Entities.Base;

using Domain.Entities.Relations;
using Domain.Enumerations;

public abstract class Task : AuditableEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public TaskStatus Status { get; set; } = TaskStatus.Pending;
    public TaskPriority Priority { get; set; } = TaskPriority.Medium;
    public Workspace Workspace { get; set; }
    public Guid WorkspaceId { get; set; }
    public Guid CreatorId { get; set; }
    public User Creator { get; set; }
    public ICollection<TaskAssignment> TaskAssignments { get; set; }
    public DateTime EstimatedStartDate { get; set; }
    public DateTime EstimatedCompletionDate { get; set; }
    public DateTime ActualStartDate { get; set; }
    public DateTime ActualCompletionDate { get; set; }
    public ICollection<string> Tags { get; set; }
    public ICollection<TaskAttachment> TaskAttachments { get; set; }
    public ICollection<TaskDependency> TaskDependencies { get; set; }
}
