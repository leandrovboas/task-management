using TaskManagement.API.DTOs;

namespace TaskManagement.Application.UseCases.Interfaces;

public interface IUpdateWorkItemsUseCase
{
    Task<bool> ExecuteAsync(Guid WorkItemsId, UpdateWorkItemsRequest updateWorkItem);
}