using Domain.Entities.Base;
using Domain.Entities.HistoricalRecords;

namespace Domain.Entities;

public sealed class Workspace : AuditableEntity
{
    private readonly List<Epic> _epics = new();
    private readonly List<UserWorkspaceMembership> _userWorkspaceMemberships = new();
    private readonly List<TeamWorkspaceMembership> _teamWorkspaceMemberships = new();

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
    public User? Creator { get; private set; }
    public Guid? CompanyId { get; private set; }
    public Company? Company { get; private set; }
    public Guid? DefaultAssigneeId { get; set; }
    public User? DefaultAssignee { get; set; }
    public IReadOnlyCollection<Epic> Epics => _epics.AsReadOnly();
    public IReadOnlyCollection<UserWorkspaceMembership> UserWorkspaceMemberships => _userWorkspaceMemberships.AsReadOnly();
    public IReadOnlyCollection<TeamWorkspaceMembership> TeamWorkspaceMemberships => _teamWorkspaceMemberships.AsReadOnly();
}
