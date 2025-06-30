using Productivity.Domain.Common.Models;
using Productivity.Domain.TeamAggregate.Entities;

namespace Productivity.Domain.TeamAggregate;

public sealed class Team : Entity<TeamId>
{
    public Team(TeamId id, string title, Guid companyId) : base(id)
    {
        Title = title;
        CompanyId = companyId;
    }

    public string Title { get; set; }
    public string? Description { get; set; }
    public Guid CompanyId { get; private set; }
    public ICollection<UserTeamMembership> Members { get; set; } = new List<UserTeamMembership>();
}
