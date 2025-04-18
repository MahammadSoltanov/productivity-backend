using Domain.Entities.Base;

namespace Domain.Entities.Relations;

public class TaskAssignment : Entity
{
    public TaskAssignment(Guid taskId, Guid assigneeId)
    {
        TaskId = taskId;
        AssigneeId = assigneeId;
    }

    public Guid TaskId { get; private set; }
    public Task Task { get; private set; }
    public Guid AssigneeId { get; private set; }
    public User Assignee { get; private set; }
}
