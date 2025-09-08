using MediatR;
using Productivity.Application.Authentication.Shared;

namespace Productivity.Application.Authentication.RegisterUser;
public record RegisterUserCommand : IRequest<AuthenticationResult>;
