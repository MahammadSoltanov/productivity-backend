using Productivity.Domain.Common.Models;
using Productivity.Domain.Common.ValueObjects;
using Productivity.Domain.CompanyAggregate.Entities;

namespace Productivity.Domain.CompanyAggregate;

public sealed class Company : AggregateRoot<CompanyId>
{
    private readonly List<UserCompanyMembership> _users = new();
    private readonly List<WorkspaceId> _workspaces = new();
    private readonly List<TeamId> _teams = new();

    public string Name { get; set; }
    public string? Description { get; set; }
    public ICollection<WorkspaceId> Workspaces => _workspaces.AsReadOnly();
    public ICollection<TeamId> Teams => _teams.AsReadOnly();
    public IReadOnlyCollection<UserCompanyMembership> Users => _users.AsReadOnly();
    public UserId OwnerId { get; }
    public AuditMetadata AuditMetadata { get; }

    private Company(CompanyId id, string name, UserId ownerId) : base(id)
    {
        Name = name;
        OwnerId = ownerId;
    }

    public static Company Create(string name, UserId ownerId)
    {
        return new(CompanyId.CreateUnique(), name, ownerId);
    }
}
