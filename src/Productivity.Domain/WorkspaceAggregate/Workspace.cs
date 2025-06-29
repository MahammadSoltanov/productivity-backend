using Productivity.Domain.CompanyAggregate.ValueObjects;
using Productivity.Domain.Entities.Base;
using Productivity.Domain.EpicAggregate.ValueObjects;
using Productivity.Domain.UserAggregate.ValueObjects;
using Productivity.Domain.WorkspaceAggregate.Entities;
using Productivity.Domain.WorkspaceAggregate.ValueObjects;

namespace Productivity.Domain.WorkspaceAggregate;

public sealed class Workspace : AuditableEntity<WorkspaceId>
{
    private readonly List<EpicId> _epics = new();
    private readonly List<UserWorkspaceMembership> _userWorkspaceMemberships = new();
    private readonly List<TeamWorkspaceMembership> _teamWorkspaceMemberships = new();

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

    public string Name { get; set; }
    public string? Desciption { get; set; }
    public UserId OwnerId { get; private set; }
    public CompanyId? CompanyId { get; private set; }
    public UserId? DefaultAssigneeId { get; set; }
    public IReadOnlyCollection<EpicId> Epics => _epics.AsReadOnly();
    public IReadOnlyCollection<UserWorkspaceMembership> UserWorkspaceMemberships => _userWorkspaceMemberships.AsReadOnly();
    public IReadOnlyCollection<TeamWorkspaceMembership> TeamWorkspaceMemberships => _teamWorkspaceMemberships.AsReadOnly();
}
