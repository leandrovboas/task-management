using TaskManagement.Core.Entities;

namespace TaskManagement.Core.Repositories;

public interface ICommentRepository
{
    Task<bool> AddCommentAsync(Comment comment);
}