using Productivity.Domain.Entities.Base;

namespace Productivity.Domain.Entities;

public class Company : AuditableEntity
{
    public Company(string name, Guid ownerId)
    {
        Name = name;
        OwnerId = ownerId;
    }

    public string Name { get; set; }
    public string? Description { get; set; }
    public ICollection<Workspace> Workspaces { get; set; } = new List<Workspace>();
    public ICollection<Team> Teams { get; set; } = new List<Team>();
    public Guid OwnerId { get; set; }
    public User? Owner { get; set; }
}
