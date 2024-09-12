using TaskManagement.Application.UseCases.Interfaces;
using TaskManagement.Core.Exceptions;
using TaskManagement.Core.Repositories;

namespace TaskManagement.Application.UseCases;

public class DeleteProjectsUseCase : IDeleteProjectsUseCase
{
    private readonly IProjectRepository _projectRepository;

    public DeleteProjectsUseCase(IProjectRepository projectRepository) => _projectRepository = projectRepository;


    public async Task<bool> ExecuteAsync(Guid projectId)
    {
        var projeto = await _projectRepository.GetByIdAsync(projectId) ?? 
            throw new ProjectException($"Projeto não encontrado com o id {projectId} ");

        if (!projeto.CanBeDeleted())
        {
            throw new ProjectException(
            "Este projeto tem tarefas inacabadas. Para removê-lo, essas tarefas devem ser concluídas ou removidas.");
        }

        return await _projectRepository.DeleteAsync(projectId);
    }
}
