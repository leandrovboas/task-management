using TaskManagement.Core.Entities;
using TaskManagement.Core.Repositories;

namespace TaskManagement.Infrastructure.Persistence
{
    public class CommentRepository : ICommentRepository
    {
        public async Task<bool> AddCommentAsync(Comment comment)
        {
            return true;
        }
    }
}
