using TaskManagement.Application.UseCases.Interfaces;
using TaskManagement.Core.Entities;
using TaskManagement.Core.Repositories;

namespace TaskManagement.Application.UseCases;

public class ListWorkItemsUseCase : IListWorkItemsUseCase
{
    private readonly IWorkItemsRepository _workItemsRepository;

    public ListWorkItemsUseCase(IWorkItemsRepository workItemsRepository)
    {
        _workItemsRepository = workItemsRepository;
    }

    public async Task<IEnumerable<WorkItems>> ExecuteAsync(Guid projectID)
    {
        return await _workItemsRepository.GetAllByProjectIdAsync(projectID);
    }
}
