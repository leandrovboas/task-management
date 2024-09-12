using TaskManagement.Application.DTOs;
using TaskManagement.Application.UseCases.Interfaces;
using TaskManagement.Core.Entities;
using TaskManagement.Core.Exceptions;
using TaskManagement.Core.Repositories;

namespace TaskManagement.Application.UseCases;

public class AddCommentUseCase : IAddCommentUseCase
{
    private readonly IWorkItemsRepository _workItemsRepository;
    private readonly ICommentRepository _commentRepository;
    private readonly IWorkItemsHistoryRepository _workItemsHistoryRepository;

    public AddCommentUseCase(
        IWorkItemsRepository WorkItemsRepository, 
        ICommentRepository commentRepository, 
        IWorkItemsHistoryRepository workItemsHistoryRepository)
    {
        _workItemsRepository = WorkItemsRepository;
        _commentRepository = commentRepository;
        _workItemsHistoryRepository = workItemsHistoryRepository;
    }

    public async Task<Guid> ExecuteAsync(AddCommentRequest commentRequest)
    {
        var workItem = await _workItemsRepository.GetByIdAsync(commentRequest.WorkItemsId) ?? 
            throw new WorkItemException($"Não foi encontrado nenhum tarefa com o id {commentRequest.WorkItemsId}.");

        var comment = commentRequest.ToEntity();
        var result = await _commentRepository.AddCommentAsync(comment);

        await _workItemsHistoryRepository.AddHistoryAsync(
            new WorkItemsHistory(workItem.Id, string.Empty, comment.Content, nameof(comment), comment.CreatedBy));

        return result
            ? comment.Id
            : throw new WorkItemException($"Não foi possível inclir ol comentário na tarefa com id {commentRequest.WorkItemsId}.");
    }
}