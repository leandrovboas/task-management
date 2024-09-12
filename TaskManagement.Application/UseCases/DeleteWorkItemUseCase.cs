using TaskManagement.Application.UseCases.Interfaces;
using TaskManagement.Core.Exceptions;
using TaskManagement.Core.Repositories;

namespace TaskManagement.Application.UseCases;

public class DeleteWorkItemUseCase : IDeleteWorkItemUseCase
{
    private readonly IWorkItemsRepository _workItemsRepository;

    public DeleteWorkItemUseCase(IWorkItemsRepository workItemsRepository) => _workItemsRepository = workItemsRepository;


    public async Task<bool> ExecuteAsync(Guid id)
    {
        var workItems = await _workItemsRepository.GetByIdAsync(id);

        return workItems == null
            ? throw new WorkItemException($"tarefa não encontrado com o id {id}")
            : await _workItemsRepository.DeleteAsync(id);
    }
}
