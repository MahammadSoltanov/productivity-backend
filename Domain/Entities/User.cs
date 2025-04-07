using Domain.Entities.Base;
using Domain.Enumerations;

namespace Domain.Entities;

public sealed class User : Entity
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string Email { get; set; }
    public string? PasswordHash { get; set; }
    public AuthenticationProvider AuthenticationProvider { get; set; }
}
