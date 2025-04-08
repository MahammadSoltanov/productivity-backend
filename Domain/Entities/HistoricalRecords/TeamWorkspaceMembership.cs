namespace Domain.Entities.HistoricalRecords;

using Domain.Entities.Base;

public sealed class TeamWorkspaceMembership : HistoricalEntity
{
    public Guid TeamId { get; set; }
    public Team Team { get; set; }
    public Guid WorkspaceId { get; set; }
    public Workspace Workspace { get; set; }
}
