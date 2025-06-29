using Productivity.Domain.UserAggregate;

namespace Productivity.Domain.EpicAggregate.Entities;

public class EpicAssignment
{
    public EpicAssignment(EpicId epicId, UserId assigneeId)
    {
        EpicId = epicId;
        AssigneeId = assigneeId;
    }

    public EpicId EpicId { get; private set; }
    public Epic Epic { get; private set; }
    public UserId AssigneeId { get; private set; }
    public User Assignee { get; private set; }
}