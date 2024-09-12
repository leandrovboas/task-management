using TaskManagement.Core.Entities;

namespace TaskManagement.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(Guid userID);
    }
}
