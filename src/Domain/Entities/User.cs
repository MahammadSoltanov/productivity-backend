using Domain.Entities.Base;
using Domain.Entities.HistoricalRecords;
using Domain.Entities.Relations;
using Domain.Enumerations;

namespace Domain.Entities;

public sealed class User : AuditableEntity
{
    private readonly List<UserTeamMembership> _teamMemberships = new();
    private readonly List<UserWorkspaceMembership> _workspaceMemberships = new();
    private readonly List<EpicAssignment> _epicAssignments = new();
    private readonly List<StoryAssignment> _storyAssignments = new();
    private readonly List<SubtaskAssignment> _subtaskAssignments = new();

    public User(string email)
    {
        Email = email;
    }

    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string Email { get; private set; }
    public string? PasswordHash { get; private set; }
    public AuthenticationProvider AuthenticationProvider { get; private set; }
    public IReadOnlyCollection<UserTeamMembership> TeamMemberships => _teamMemberships.AsReadOnly();
    public IReadOnlyCollection<UserWorkspaceMembership> WorkspaceMemberships => _workspaceMemberships.AsReadOnly();
    public IReadOnlyCollection<EpicAssignment> EpicAssignments => _epicAssignments.AsReadOnly();
    public IReadOnlyCollection<StoryAssignment> StoryAssignments => _storyAssignments.AsReadOnly();
    public IReadOnlyCollection<SubtaskAssignment> SubtaskAssignments => _subtaskAssignments.AsReadOnly();
}
