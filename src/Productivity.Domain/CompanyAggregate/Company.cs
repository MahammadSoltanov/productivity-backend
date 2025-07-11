using Productivity.Domain.Common.Models;
using Productivity.Domain.Common.ValueObjects;

namespace Productivity.Domain.CompanyAggregate;

public sealed class Company : AggregateRoot<CompanyId>
{
    private readonly List<UserId> _users = new();
    private readonly List<WorkspaceId> _workspaces = new();
    private readonly List<TeamId> _teams = new();


    public string Name { get; set; }
    public string? Description { get; set; }
    public ICollection<WorkspaceId> Workspaces => _workspaces.AsReadOnly();
    public ICollection<TeamId> Teams => _teams.AsReadOnly();
    public IReadOnlyCollection<UserId> Users => _users.AsReadOnly();
    public UserId OwnerId { get; }
    public AuditMetadata AuditMetadata { get; }
    public GlobalCompanySettings GlobalSettings { get; private set; }

    private Company(CompanyId id, string name, UserId creatorId) : base(id)
    {
        Name = name;
        OwnerId = creatorId;
        AuditMetadata = new AuditMetadata(creatorId, DateTime.UtcNow);
    }

    public static Company Create(string name, UserId creatorId)
    {
        return new(CompanyId.CreateUnique(), name, creatorId);
    }

    public void UpdateGlobalSettings(GlobalCompanySettings settings)
    {
        GlobalSettings = settings;
    }
}