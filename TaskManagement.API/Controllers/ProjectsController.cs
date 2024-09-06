using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.UseCases;

namespace TaskManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly CreateProjectUseCase _createProjectUseCase;
    private readonly AddTaskUseCase _addTaskUseCase;

    public ProjectsController(CreateProjectUseCase createProjectUseCase, AddTaskUseCase addTaskUseCase)
    {
        _createProjectUseCase = createProjectUseCase;
        _addTaskUseCase = addTaskUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProject([FromBody] CreateProjectRequest request)
    {
        var projectId = await _createProjectUseCase.ExecuteAsync(request.Name, request.UserId);
        return Ok(projectId);
    }

    [HttpPost("{projectId}/tasks")]
    public async Task<IActionResult> AddTask(Guid projectId, [FromBody] AddTaskRequest request)
    {
        var taskId = await _addTaskUseCase.ExecuteAsync(projectId, request.Name, request.Description, request.Priority, request.CreatedBy);
        return Ok(taskId);
    }
}
