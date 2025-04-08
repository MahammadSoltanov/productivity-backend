using Domain.Entities.Base;
using Domain.Entities.HistoricalRecords;
using Domain.Enumerations;

namespace Domain.Entities;

public sealed class User : AuditableEntity
{
    public User(string email)
    {
        Email = email;
    }

    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string Email { get; set; }
    public string? PasswordHash { get; set; }
    public ICollection<UserTeamMembership> TeamMemberships { get; set; } = new List<UserTeamMembership>();
    public ICollection<UserWorkspaceMembership> WorkspaceMemberships { get; set; } = new List<UserWorkspaceMembership>();
    public ICollection<Epic> Epics { get; set; } = new List<Epic>();
    public ICollection<Story> Stories { get; set; } = new List<Story>();
    public ICollection<Subtask> Subtasks { get; set; } = new List<Subtask>();
    public AuthenticationProvider AuthenticationProvider { get; set; }
}
