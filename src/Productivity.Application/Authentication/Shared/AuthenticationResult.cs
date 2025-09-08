namespace Productivity.Application.Authentication.Shared;

public record AuthenticationResult(string FirstName, string LastName, string Email, string Token);