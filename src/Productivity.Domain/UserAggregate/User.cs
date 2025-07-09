using Productivity.Domain.Common.Enumerations;
using Productivity.Domain.Common.Models;
using Productivity.Domain.UserAggregate.Entities;

namespace Productivity.Domain.UserAggregate;

public sealed class User : AggregateRoot<UserId>
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string Email { get; private set; }
    public string? PasswordHash { get; private set; }
    public AccountSettings AccountSettings { get; }
    public AuthenticationProvider AuthenticationProvider { get; private set; }

    private User(UserId id, string email) : base(id)
    {
        Email = email;
    }

    public User Create(string email)
    {
        return new User(UserId.CreateUnique(), email);
    }
}