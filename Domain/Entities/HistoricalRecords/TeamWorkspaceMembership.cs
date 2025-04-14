using Domain.Entities.Base;

namespace Domain.Entities.HistoricalRecords;

public sealed class TeamWorkspaceMembership : HistoricalEntity
{
    public TeamWorkspaceMembership(Team team, Workspace workspace)
    {
        Team = team;
        TeamId = team.Id;
        Workspace = workspace;
        WorkspaceId = workspace.Id;
    }

    public Guid TeamId { get; private set; }
    public Team Team { get; private set; }
    public Guid WorkspaceId { get; private set; }
    public Workspace Workspace { get; private set; }
}
