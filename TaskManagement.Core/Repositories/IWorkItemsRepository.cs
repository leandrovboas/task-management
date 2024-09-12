using TaskManagement.Core.Entities;

namespace TaskManagement.Core.Repositories;

public interface IWorkItemsRepository
{
    Task<WorkItems> GetByIdAsync(Guid id);
    Task<IEnumerable<WorkItems>> GetAllByProjectIdAsync(Guid projectId);
    Task<IEnumerable<WorkItems>> GetAll();
    Task CreateAsync(WorkItems WorkItems);
    Task UpdateAsync(WorkItems WorkItems);
    Task<bool> DeleteAsync(Guid id);
}