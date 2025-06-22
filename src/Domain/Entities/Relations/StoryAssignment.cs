namespace Domain.Entities.Relations;
public class StoryAssignment
{
    public StoryAssignment(Guid storyId, Guid assigneeId)
    {
        StoryId = storyId;
        AssigneeId = assigneeId;
    }

    public Guid StoryId { get; private set; }
    public Story Story { get; private set; }
    public Guid AssigneeId { get; private set; }
    public User Assignee { get; private set; }
}
