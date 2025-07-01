using Productivity.Domain.Common.Models;
using Productivity.Domain.TeamAggregate.Entities;

namespace Productivity.Domain.TeamAggregate;

public sealed class Team : AggregateRoot<TeamId>
{
    private List<UserTeamMembership> _members = new();

    public string Title { get; set; }
    public string? Description { get; set; }
    public CompanyId CompanyId { get; private set; }
    public IReadOnlyCollection<UserTeamMembership> Members => _members.AsReadOnly();

    private Team(TeamId id, string title, CompanyId companyId) : base(id)
    {
        Title = title;
        CompanyId = companyId;
    }

    public Team Create(string title, CompanyId companyId)
    {
        return new(TeamId.CreateUnique(), title, companyId);
    }
}
