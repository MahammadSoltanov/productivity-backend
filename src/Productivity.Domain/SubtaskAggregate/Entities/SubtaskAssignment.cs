using Productivity.Domain.SubtaskAggregate.ValueObjects;
using Productivity.Domain.UserAggregate;
using Productivity.Domain.UserAggregate.ValueObjects;

namespace Productivity.Domain.SubtaskAggregate.Entities;
public class SubtaskAssignment
{
    public SubtaskAssignment(SubtaskId subtaskId, UserId assigneeId)
    {
        SubtaskId = subtaskId;
        AssigneeId = assigneeId;
    }

    public SubtaskId SubtaskId { get; private set; }
    public Subtask Subtask { get; private set; }
    public UserId AssigneeId { get; private set; }
    public User Assignee { get; private set; }
}