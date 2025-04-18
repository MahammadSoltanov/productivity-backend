using Domain.Entities.Base;

namespace Domain.Entities.HistoricalRecords;

public sealed class UserWorkspaceMembership : HistoricalEntity
{
    public UserWorkspaceMembership(Guid userId, Guid workspaceId)
    {
        UserId = userId;
        WorkspaceId = workspaceId;
    }

    public Guid UserId { get; private set; }
    public User User { get; private set; }
    public Guid WorkspaceId { get; private set; }
    public Workspace Workspace { get; private set; }
}
