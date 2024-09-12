using TaskManagement.Core.Entities;

namespace TaskManagement.Application.UseCases.Interfaces;

public interface IListWorkItemsUseCase
{
    Task<IEnumerable<WorkItems>> ExecuteAsync(Guid projectID);
}
