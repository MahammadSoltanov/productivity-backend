using Domain.Entities.Base;

namespace Domain.Entities.HistoricalRecords;

public sealed class UserWorkspaceMembership : HistoricalEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Guid WorkspaceId { get; set; }
    public Workspace Workspace { get; set; }
}
