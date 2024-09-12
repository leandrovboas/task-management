using TaskManagement.Core.Entities;
using TaskManagement.Core.Enums;
using TaskManagement.Core.Repositories;
using TaskManagement.Infrastructure.Configurations;

namespace TaskManagement.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context) =>
        _context = context;

    public async Task<User> GetUserByIdAsync(Guid userID)
    {
        return new User() { Name = "Leandro", AccessType = AccessType.Manager };
    }
}
