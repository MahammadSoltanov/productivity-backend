using Domain.Entities.Base;
using Domain.Enumerations;

namespace Domain.Entities.HistoricalRecords;

public sealed class UserTeamMembership : HistoricalEntity
{
    public UserTeamMembership(Guid teamId, Guid userId, TeamRole role)
    {
        TeamId = teamId;
        UserId = userId;
        Role = role;
    }

    public Guid UserId { get; private set; }
    public User? User { get; private set; }
    public Guid TeamId { get; private set; }
    public Team? Team { get; private set; }
    public TeamRole Role { get; private set; }
}
