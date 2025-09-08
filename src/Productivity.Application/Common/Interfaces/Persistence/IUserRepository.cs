using Productivity.Domain.UserAggregate;

namespace Productivity.Application.Common.Interfaces.Persistence;
public interface IUserRepository
{
    Task<User?> GetUserByEmail(string email);
    Task Add(User user);
}
