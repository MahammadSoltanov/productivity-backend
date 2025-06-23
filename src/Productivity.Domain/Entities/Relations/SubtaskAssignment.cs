namespace Productivity.Domain.Entities.Relations;
public class SubtaskAssignment
{
    public SubtaskAssignment(Guid subtaskId, Guid assigneeId)
    {
        SubtaskId = subtaskId;
        AssigneeId = assigneeId;
    }

    public Guid SubtaskId { get; private set; }
    public Subtask Subtask { get; private set; }
    public Guid AssigneeId { get; private set; }
    public User Assignee { get; private set; }
}