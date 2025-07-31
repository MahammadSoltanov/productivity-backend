using Productivity.Domain.Common.Enumerations;
using Productivity.Domain.Common.Models;

namespace Productivity.Domain.UserAggregate;
public sealed class User : AggregateRoot<UserId>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public AccountSettings AccountSettings { get; private set; }
    public AuthenticationProvider AuthenticationProvider { get; private set; }

    private User(UserId id,
                 string firstName,
                 string lastName,
                 string email,
                 string passwordHash,
                 AuthenticationProvider authenticationProvider) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PasswordHash = passwordHash;
        AuthenticationProvider = authenticationProvider;
    }

    private User() { }


    public static User Create(string firstName,
                       string lastName,
                       string email,
                       string passwordHash,
                       AuthenticationProvider authenticationProvider)
    {
        return new User(UserId.CreateUnique(), firstName, lastName, email, passwordHash, authenticationProvider);
    }
}