namespace TaskManagement.Application.UseCases;

public class CreateProjectUseCase
{
    private readonly IProjectRepository _projectRepository;

    public CreateProjectUseCase(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<Guid> ExecuteAsync(string name, Guid userId)
    {
        var project = new Project { Id = Guid.NewGuid(), Name = name, UserId = userId, Tasks = new List<Task>() };
        await _projectRepository.CreateAsync(project);
        return project.Id;
    }
}
