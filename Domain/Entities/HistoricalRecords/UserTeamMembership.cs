using Domain.Entities.Base;

namespace Domain.Entities.HistoricalRecords;

public sealed class UserTeamMembership : HistoricalEntity
{
    public UserTeamMembership(Team team, User user)
    {
        Team = team;
        TeamId = team.Id;
        User = user;
        UserId = user.Id;
    }

    public Guid UserId { get; private set; }
    public User User { get; private set; }
    public Guid TeamId { get; private set; }
    public Team Team { get; private set; }
}
