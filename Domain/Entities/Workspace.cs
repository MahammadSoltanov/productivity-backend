using Domain.Entities.Base;
using Domain.Entities.HistoricalRecords;

namespace Domain.Entities;

public sealed class Workspace : AuditableEntity
{
    public Workspace(string name, Guid creatorId)
    {
        Name = name;
        CreatorId = creatorId;
    }

    public Workspace(string name, Guid creatorId, Guid companyId)
    {
        Name = name;
        CreatorId = creatorId;
        CompanyId = companyId;
    }

    public string Name { get; set; }
    public string? Desciption { get; set; }
    public Guid CreatorId { get; set; }
    public User? Creator { get; set; }
    public Guid? CompanyId { get; set; }
    public Company? Company { get; set; }
    public Guid? DefaultAssigneeId { get; set; }
    public User? DefaultAssignee { get; set; }
    public ICollection<Epic> Epics { get; set; } = new List<Epic>();
    public ICollection<UserWorkspaceMembership> UserWorkspaceMemberships { get; set; } = new List<UserWorkspaceMembership>();
    public ICollection<TeamWorkspaceMembership> TeamWorkspaceMemberships { get; set; } = new List<TeamWorkspaceMembership>();
}
