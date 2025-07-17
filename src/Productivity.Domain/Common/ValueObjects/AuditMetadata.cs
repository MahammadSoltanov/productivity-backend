namespace Productivity.Domain.Common.ValueObjects;

public record AuditMetadata(
    UserId CreatorId,
    DateTime CreatedAt,
    UserId? ModifierId = null,
    DateTime? ModifiedAt = null)
{
    public AuditMetadata WithModification(UserId modifierId, DateTime when) => this with { ModifierId = modifierId, ModifiedAt = when };
}