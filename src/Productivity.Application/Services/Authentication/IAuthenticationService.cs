using Productivity.Application.Authentication.Shared;

namespace Productivity.Application.Services.Authentication;
public interface IAuthenticationService
{
    Task<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
    Task<AuthenticationResult> Login(string email, string password);
}
