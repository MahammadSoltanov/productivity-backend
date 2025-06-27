using Productivity.Domain.Common.Models;

namespace Productivity.Domain.Entities.Base;
public class AuditableEntity<TId> : Entity<TId> where TId : notnull
{
    public AuditableEntity(TId Id) : base(Id) => CreatedAt = DateTime.UtcNow;

    public void MarkAsModified(Guid modifierId)
    {
        ModifiedAt = DateTime.UtcNow;
        ModifierId = modifierId;
    }

    public Guid CreatorId { get; set; }
    public Guid? ModifierId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? ModifiedAt { get; private set; }
}