using Productivity.Domain.Common.Enumerations;
using Productivity.Domain.Common.Models;

namespace Productivity.Domain.UserAggregate;

public sealed class User : AggregateRoot<UserId>
{
    private User(UserId id, string email) : base(id)
    {
        Email = email;
    }

    public User Create(string email)
    {
        return new User(UserId.CreateUnique(), email);
    }

    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string Email { get; private set; }
    public string? PasswordHash { get; private set; }
    public AuthenticationProvider AuthenticationProvider { get; private set; }
}
