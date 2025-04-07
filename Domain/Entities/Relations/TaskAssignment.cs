namespace Domain.Entities.Relations;

using Domain.Entities.Base;

public class TaskAssignment : Entity
{
    public Guid TaskId { get; set; }
    public Task Task { get; set; }
    public Guid AssigneeId { get; set; }
    public User Assignee { get; set; }
}
