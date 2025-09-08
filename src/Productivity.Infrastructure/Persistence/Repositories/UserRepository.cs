using Microsoft.EntityFrameworkCore;
using Productivity.Application.Common.Interfaces.Persistence;
using Productivity.Domain.UserAggregate;

namespace Productivity.Infrastructure.Persistence.Repositories;
public class UserRepository : IUserRepository
{
    private readonly ProductivityDbContext _context;

    public async Task Add(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
}
