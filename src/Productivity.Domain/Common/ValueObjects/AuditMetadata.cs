namespace Productivity.Domain.Common.ValueObjects;

public record AuditMetadata(
    UserId CreatorId,
    DateTimeOffset CreatedAt,
    UserId? ModifierId = null,
    DateTimeOffset? ModifiedAt = null)
{
    public AuditMetadata WithModification(UserId modifierId, DateTimeOffset when) => this with { ModifierId = modifierId, ModifiedAt = when };
}