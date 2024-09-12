using TaskManagement.Core.Entities;

namespace TaskManagement.Core.Repositories;

public interface IProjectRepository
{
    Task<Project> GetByIdAsync(Guid id);
    Task<IEnumerable<Project>> GetAllByUserIdAsync(Guid userID);
    Task<bool> CreateAsync(Project project);
    Task<bool> DeleteAsync(Guid projectID);
}