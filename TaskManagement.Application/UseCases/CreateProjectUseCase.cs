using TaskManagement.API.DTOs;
using TaskManagement.Application.UseCases.Interfaces;
using TaskManagement.Core.Exceptions;
using TaskManagement.Core.Repositories;

namespace TaskManagement.Application.UseCases;

public class CreateProjectUseCase : ICreateProjectUseCase
{
    private readonly IProjectRepository _projectRepository;

    public CreateProjectUseCase(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<Guid> ExecuteAsync(CreateProjectRequest projectRequest)
    {
        var project = projectRequest.ToEntity();

        if (!project.CanBeCreatedWorkItem()) throw new MaxWorkItemException("O limite máximo de itens para este projeto foi excedido");

        await _projectRepository.CreateAsync(project);
        return project.Id;
    }
}
