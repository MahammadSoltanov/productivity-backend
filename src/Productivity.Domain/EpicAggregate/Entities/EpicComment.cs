using Productivity.Domain.Common.Abstract;

namespace Productivity.Domain.EpicAggregate.Entities;
public class EpicComment : TaskComment<EpicCommentId>
{
    private EpicComment(EpicCommentId id,
                               UserId authorId,
                               string text) : base(id, authorId, text)
    {

    }

    internal EpicComment Create(UserId authorId, string text)
    {
        return new(EpicCommentId.CreateUnique(), authorId, text);
    }
}