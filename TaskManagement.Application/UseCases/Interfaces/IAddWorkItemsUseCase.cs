using TaskManagement.API.DTOs;

namespace TaskManagement.Application.UseCases.Interfaces;

public interface IAddWorkItemsUseCase
{
    Task<Guid> ExecuteAsync(AddWorkItemsRequest workItemsRequest);
}