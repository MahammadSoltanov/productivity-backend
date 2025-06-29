using Productivity.Domain.StoryAggregate.ValueObjects;
using Productivity.Domain.UserAggregate;
using Productivity.Domain.UserAggregate.ValueObjects;

namespace Productivity.Domain.StoryAggregate.Entities;
public class StoryAssignment
{
    public StoryAssignment(StoryId storyId, UserId assigneeId)
    {
        StoryId = storyId;
        AssigneeId = assigneeId;
    }

    public StoryId StoryId { get; private set; }
    public Story Story { get; private set; }
    public UserId AssigneeId { get; private set; }
    public User Assignee { get; private set; }
}
