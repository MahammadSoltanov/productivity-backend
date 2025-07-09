using Productivity.Domain.Common.Abstract;

namespace Productivity.Domain.StoryAggregate.Entities;
public class StoryComment : TaskComment<StoryCommentId>
{
    private StoryComment(StoryCommentId id,
                               UserId authorId,
                               string text) : base(id, authorId, text)
    {

    }

    internal StoryComment Create(UserId authorId, string text)
    {
        return new(StoryCommentId.CreateUnique(), authorId, text);
    }
}