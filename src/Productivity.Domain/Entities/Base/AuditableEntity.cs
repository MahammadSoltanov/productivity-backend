using Productivity.Domain.Common.Models;
using Productivity.Domain.UserAggregate.ValueObjects;

namespace Productivity.Domain.Entities.Base;
public class AuditableEntity<TId> : Entity<TId> where TId : notnull
{
    public AuditableEntity(TId Id) : base(Id) { }

    public UserId CreatorId { get; set; }
    public UserId? ModifierId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? ModifiedAt { get; private set; }
}