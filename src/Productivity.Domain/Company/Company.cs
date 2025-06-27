using Productivity.Domain.Entities;
using Productivity.Domain.Entities.Base;
using Productivity.Domain.Entities.HistoricalRecords;

namespace Productivity.Domain.Company;

public class Company : AuditableEntity
{
    private readonly List<UserCompanyMembership> _users = new();
    private readonly List<Workspace> _workspaces = new();
    private readonly List<Team> _teams = new();

    public Company(string name, Guid ownerId)
    {
        Name = name;
        OwnerId = ownerId;
    }

    public string Name { get; set; }
    public string? Description { get; set; }
    public ICollection<Workspace> Workspaces => _workspaces.AsReadOnly();
    public ICollection<Team> Teams => _teams.AsReadOnly();
    public IReadOnlyCollection<UserCompanyMembership> Users => _users.AsReadOnly();
    public Guid OwnerId { get; set; }
    public User? Owner { get; set; }
}
