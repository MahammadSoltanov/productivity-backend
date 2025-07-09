using Productivity.Domain.Common.Abstract;

namespace Productivity.Domain.SubtaskAggregate.Entities;
public class SubtaskComment : TaskComment<SubtaskCommentId>
{
    private SubtaskComment(SubtaskCommentId id,
                               UserId authorId,
                               string text) : base(id, authorId, text)
    {

    }

    internal SubtaskComment Create(UserId authorId, string text)
    {
        return new(SubtaskCommentId.CreateUnique(), authorId, text);
    }
}