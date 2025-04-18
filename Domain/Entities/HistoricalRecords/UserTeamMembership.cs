using Domain.Entities.Base;

namespace Domain.Entities.HistoricalRecords;

public sealed class UserTeamMembership : HistoricalEntity
{
    public UserTeamMembership(Guid teamId, Guid userId)
    {
        TeamId = teamId;
        UserId = userId;
    }

    public Guid UserId { get; private set; }
    public User User { get; private set; }
    public Guid TeamId { get; private set; }
    public Team Team { get; private set; }
}
