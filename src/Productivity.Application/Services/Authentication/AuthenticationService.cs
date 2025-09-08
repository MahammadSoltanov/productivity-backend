using Productivity.Application.Authentication.Shared;
using Productivity.Application.Common.Interfaces.Authentication;
using Productivity.Application.Common.Interfaces.Persistence;
using Productivity.Domain.Common.Enumerations;
using Productivity.Domain.UserAggregate;

namespace Productivity.Application.Services.Authentication;
public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<AuthenticationResult> Register(string firstName,
                                         string lastName,
                                         string email,
                                         string password)
    {
        //check if user already exists
        User? userWithSameEmail = await _userRepository.GetUserByEmail(email);

        if (userWithSameEmail is not null)
        {
            throw new Exception("User should be unique");
        }

        //Create user(generate unique ID)
        User newUser = User.Create(firstName,
                                   lastName,
                                   email,
                                   password,
                                   AuthenticationProvider.Email);

        //Persist the user
        _userRepository.Add(newUser);

        //Generate token and return to the client
        string token = _jwtTokenGenerator.GenerateToken(newUser.Id,
                                                        firstName,
                                                        lastName);

        var authenticationResult = new AuthenticationResult(firstName,
                                                            lastName,
                                                            email,
                                                            token);

        return authenticationResult;
    }

    public async Task<AuthenticationResult> Login(string email, string password)
    {

    }
}
