using TaskManagement.Application.UseCases.Interfaces;
using TaskManagement.Core.Entities;
using TaskManagement.Core.Repositories;

namespace TaskManagement.Application.UseCases;

public class ListProjectsUseCase : IListProjetcsUseCase
{
    private readonly IProjectRepository _projectRepository;

    public ListProjectsUseCase(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<IEnumerable<Project>> ExecuteAsync(Guid userId)
    {
        return await _projectRepository.GetAllByUserIdAsync(userId);
    }
}
