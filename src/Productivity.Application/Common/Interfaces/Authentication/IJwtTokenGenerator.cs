using Productivity.Domain.UserAggregate.ValueObjects;

namespace Productivity.Application.Common.Interfaces.Authentication;
public interface IJwtTokenGenerator
{
    string GenerateToken(UserId userId, string firstName, string lastName);
}
