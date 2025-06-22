using Domain.Entities.Base;
using Domain.Entities.HistoricalRecords;

namespace Domain.Entities;

public sealed class Team : AuditableEntity
{
    public Team(string title, Guid companyId)
    {
        Title = title;
        CompanyId = companyId;
    }

    public string Title { get; set; }
    public string? Description { get; set; }
    public Guid CompanyId { get; private set; }
    public Company? Company { get; }
    public ICollection<UserTeamMembership> Members { get; set; } = new List<UserTeamMembership>();
    public ICollection<TeamWorkspaceMembership> WorkspaceMemberships { get; set; } = new List<TeamWorkspaceMembership>();
}
