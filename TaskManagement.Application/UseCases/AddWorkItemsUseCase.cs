using TaskManagement.API.DTOs;
using TaskManagement.Application.UseCases.Interfaces;
using TaskManagement.Core.Exceptions;
using TaskManagement.Core.Repositories;

namespace TaskManagement.Application.UseCases;

public class AddWorkItemsUseCase : IAddWorkItemsUseCase
{
    private readonly IWorkItemsRepository _WorkItemsRepository;
    private readonly IProjectRepository _projectRepository;

    public AddWorkItemsUseCase(IWorkItemsRepository WorkItemsRepository, IProjectRepository projectRepository)
    {
        _WorkItemsRepository = WorkItemsRepository;
        _projectRepository = projectRepository;
    }

    public async Task<Guid> ExecuteAsync( AddWorkItemsRequest workItemsRequest)
    {
        var project = await _projectRepository.GetByIdAsync(workItemsRequest.ProjectId) 
            ?? throw new ProjectException($"Projeto com o id {workItemsRequest.ProjectId} não foi encontrado.");

        if (!project.CanBeCreatedWorkItem()) throw new MaxWorkItemException("Não é possível adicionar mais de 20 tarefas a um projeto.");

        var workItem = workItemsRequest.ToEntity();
        await _WorkItemsRepository.CreateAsync(workItem);

        return workItem.Id;
    }
}