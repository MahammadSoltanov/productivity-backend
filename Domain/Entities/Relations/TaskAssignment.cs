using Domain.Entities.Base;

namespace Domain.Entities.Relations;

public class TaskAssignment : Entity
{
    public TaskAssignment(Task task, User assignee)
    {
        Task = task;
        TaskId = task.Id;
        Assignee = assignee;
        AssigneeId = assignee.Id;
    }

    public Guid TaskId { get; private set; }
    public Task Task { get; private set; }
    public Guid AssigneeId { get; private set; }
    public User Assignee { get; private set; }
}
