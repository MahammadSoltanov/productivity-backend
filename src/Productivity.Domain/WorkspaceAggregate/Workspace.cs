using Productivity.Domain.Common.Models;
using Productivity.Domain.Common.ValueObjects;
using Productivity.Domain.WorkspaceAggregate.Entities;

namespace Productivity.Domain.WorkspaceAggregate;

public sealed class Workspace : AggregateRoot<WorkspaceId>
{
    private readonly List<EpicId> _epics = new();
    private readonly List<UserWorkspaceMembership> _userWorkspaceMemberships = new();
    private readonly List<TeamWorkspaceMembership> _teamWorkspaceMemberships = new();

    public string Name { get; set; }
    public string? Desciption { get; set; }
    public UserId OwnerId { get; private set; }
    public CompanyId? CompanyId { get; private set; }
    public UserId? DefaultAssigneeId { get; set; }
    public IReadOnlyCollection<EpicId> Epics => _epics.AsReadOnly();
    public AuditMetadata AuditMetadata { get; }
    public IReadOnlyCollection<UserWorkspaceMembership> UserWorkspaceMemberships => _userWorkspaceMemberships.AsReadOnly();
    public IReadOnlyCollection<TeamWorkspaceMembership> TeamWorkspaceMemberships => _teamWorkspaceMemberships.AsReadOnly();

    private Workspace(WorkspaceId id, string name, UserId ownerId, CompanyId? companyId) : base(id)
    {
        Name = name;
        OwnerId = ownerId;
    }

    public static Workspace Create(string name, UserId ownerId)
    {
        return new(WorkspaceId.CreateUnique(), name, ownerId, null);
    }

    public static Workspace CreateInCompany(string name, UserId ownerId, CompanyId companyId)
    {
        if (companyId is null)
        {
            throw new ArgumentNullException(nameof(companyId));
        }

        return new Workspace(WorkspaceId.CreateUnique(), name, ownerId, companyId);
    }
}
