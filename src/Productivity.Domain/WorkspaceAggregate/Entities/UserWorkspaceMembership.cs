using Productivity.Domain.Entities.Base;
using Productivity.Domain.Enumerations;
using Productivity.Domain.UserAggregate;

namespace Productivity.Domain.WorkspaceAggregate.Entities;

public sealed class UserWorkspaceMembership : HistoricalEntity
{
    public UserWorkspaceMembership(Guid userId, Guid workspaceId, WorkspaceRole role)
    {
        UserId = userId;
        WorkspaceId = workspaceId;
        Role = role;
    }

    public Guid UserId { get; private set; }
    public User? User { get; private set; }
    public Guid WorkspaceId { get; private set; }
    public Workspace? Workspace { get; private set; }
    public WorkspaceRole Role { get; private set; }
}
