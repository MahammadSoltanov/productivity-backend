using Domain.Entities.Base;

namespace Domain.Entities.Relations;

public class TaskAssignment : Entity
{
    public Guid TaskId { get; set; }
    public Task Task { get; set; }
    public Guid AssigneeId { get; set; }
    public User Assignee { get; set; }
}
