using Productivity.Domain.Common.Exceptions;
using Productivity.Domain.Common.Models;

namespace Productivity.Domain.Common.Abstract;
public abstract class TaskComment<TId> : Entity<TId> where TId : notnull
{
    public UserId AuthorId { get; }
    public string Text { get; private set; }
    public DateTime CreatedAt { get; }
    public DateTime? EditedAt { get; private set; }
    public bool IsDeleted { get; private set; }

    internal TaskComment(
      TId id,
      UserId authorId,
      string text) : base(id)
    {
        AuthorId = authorId;
        Text = text;
        CreatedAt = DateTime.UtcNow;
    }

    public void Edit(string newText)
    {
        if (IsDeleted)
        {
            throw new DomainException("Cannot edit a deleted comment");
        }

        Text = newText;
        EditedAt = DateTime.UtcNow;
    }

    public void Delete()
    {
        IsDeleted = true;
    }
}