using TaskManagement.API.DTOs;
using TaskManagement.Application.UseCases.Interfaces;
using TaskManagement.Core.Entities;
using TaskManagement.Core.Exceptions;
using TaskManagement.Core.Repositories;

namespace TaskManagement.Application.UseCases;

public class UpdateWorkItemsUseCase : IUpdateWorkItemsUseCase
{
    private readonly IWorkItemsRepository _workItemsRepository;
    private readonly IWorkItemsHistoryRepository _workItemsHistoryRepository;
    private WorkItems _workItem;
    private List<WorkItemsHistory> _listWorkItemHistory = [];

    public UpdateWorkItemsUseCase(IWorkItemsRepository WorkItemsRepository, IWorkItemsHistoryRepository WorkItemsHistoryRepository)
    {
        _workItemsRepository = WorkItemsRepository;
        _workItemsHistoryRepository = WorkItemsHistoryRepository;
    }

    public async Task<bool> ExecuteAsync(Guid WorkItemsId, UpdateWorkItemsRequest updateWorkItem)
    {
        _workItem = await _workItemsRepository.GetByIdAsync(WorkItemsId)
            ?? throw new WorkItemException("Tarefa não encontrada.");

        ChangeStatus(updateWorkItem);
        ChangeDescription(updateWorkItem);
        ChangeTitle(updateWorkItem);

        foreach (var item in _listWorkItemHistory)
        {
            await _workItemsHistoryRepository.AddHistoryAsync(item);
        }

        await _workItemsRepository.UpdateAsync(_workItem);

        return true;

    }

    private void ChangeDescription(UpdateWorkItemsRequest updateWorkItem)
    {
        if (_workItem.Description.Equals(updateWorkItem.Description))
        {
            _listWorkItemHistory.Add(
                new WorkItemsHistory(
                    _workItem.Id,
                    oldData: _workItem.Description,
                    newData: updateWorkItem.Description,
                    propertyChanged: nameof(_workItem.Description),
                    changedBy: updateWorkItem.UpdatedBy));

            _workItem.ChangeDescription(updateWorkItem.Description);
        }
    }

    private void ChangeStatus(UpdateWorkItemsRequest updateWorkItem)
    {
        if (_workItem.Status != updateWorkItem.Status)
        {
            _listWorkItemHistory.Add(
                new WorkItemsHistory(
                    _workItem.Id,
                    oldData: _workItem.Status.ToString(),
                    newData: updateWorkItem.Status.ToString(),
                    propertyChanged: nameof(_workItem.Status),
                    changedBy: updateWorkItem.UpdatedBy));

            _workItem.ChangeStatus(updateWorkItem.Status);
        }
    }

    private void ChangeTitle(UpdateWorkItemsRequest updateWorkItem)
    {
        if (_workItem.Title.Equals(updateWorkItem.Title))
        {
            _listWorkItemHistory.Add(
                new WorkItemsHistory(
                    _workItem.Id,
                    oldData: _workItem.Title,
                    newData: updateWorkItem.Title,
                    propertyChanged: nameof(_workItem.Title),
                    changedBy: updateWorkItem.UpdatedBy));

            _workItem.ChangeTitle(updateWorkItem.Title);
        }
    }
}