namespace TaskManagement.Application.UseCases;

public class AddTaskUseCase
{
    private readonly ITaskRepository _taskRepository;
    private readonly IProjectRepository _projectRepository;

    public AddTaskUseCase(ITaskRepository taskRepository, IProjectRepository projectRepository)
    {
        _taskRepository = taskRepository;
        _projectRepository = projectRepository;
    }

    public async Task<Guid> ExecuteAsync(Guid projectId, string name, string description, TaskPriority priority, string createdBy)
    {
        var project = await _projectRepository.GetByIdAsync(projectId);

        if (project.Tasks.Count >= 20)
            throw new InvalidOperationException("Cannot add more than 20 tasks to a project.");

        var task = new Task
        {
            Id = Guid.NewGuid(),
            Name = name,
            Description = description,
            Priority = priority,
            Status = TaskStatus.Pending,
            ProjectId = projectId,
            CreatedBy = createdBy,
            CreatedAt = DateTime.UtcNow
        };

        await _taskRepository.CreateAsync(task);
        return task.Id;
    }
}