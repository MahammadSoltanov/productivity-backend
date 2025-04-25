namespace Domain.Entities.Relations;

public class EpicAssignment
{
    public EpicAssignment(Guid epicId, Guid assigneeId)
    {
        EpicId = epicId;
        AssigneeId = assigneeId;
    }

    public Guid EpicId { get; private set; }
    public Epic Epic { get; private set; }
    public Guid AssigneeId { get; private set; }
    public User Assignee { get; private set; }
}