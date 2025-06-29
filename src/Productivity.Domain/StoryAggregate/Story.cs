using Productivity.Domain.Entities.Abstract;
using Productivity.Domain.EpicAggregate;
using Productivity.Domain.SubtaskAggregate;

namespace Productivity.Domain.StoryAggregate;

public sealed class Story : TaskAbstract<StoryId>
{
    public ICollection<Subtask>? Subtasks { get; set; }
    public Guid EpicId { get; private set; }
    public Epic Epic { get; }

    private Story(StoryId id, string title, WorkspaceId workspaceId, UserId creatorId) : base(id, title, workspaceId, creatorId)
    {

    }

    public Story Create(string title, WorkspaceId workspaceId, UserId creatorId)
    {
        return new(StoryId.CreateUnique(), title, workspaceId, creatorId);
    }

}
