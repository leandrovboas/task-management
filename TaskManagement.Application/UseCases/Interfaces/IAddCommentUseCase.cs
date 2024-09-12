using TaskManagement.Application.DTOs;

namespace TaskManagement.Application.UseCases.Interfaces;

public interface IAddCommentUseCase
{
    Task<Guid> ExecuteAsync( AddCommentRequest workItemsRequest);
}