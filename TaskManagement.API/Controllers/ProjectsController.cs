using Microsoft.AspNetCore.Mvc;
using TaskManagement.API.DTOs;
using TaskManagement.Application.UseCases.Interfaces;

namespace TaskManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class ProjectsController : ControllerBase
{
    private readonly ICreateProjectUseCase _createProjectUseCase;
    private readonly IListProjetcsUseCase _listProjetcsUseCase;
    private readonly IDeleteProjectsUseCase _deleteProjectsUseCase;

    public ProjectsController(
        ICreateProjectUseCase createProjectUseCase, 
        IListProjetcsUseCase listProjetcsUseCase, 
        IDeleteProjectsUseCase deleteProjectsUseCase)
    {
        _createProjectUseCase = createProjectUseCase;
        _listProjetcsUseCase = listProjetcsUseCase;
        _deleteProjectsUseCase = deleteProjectsUseCase;
    }

    /// <summary>
    /// Esse método cria um novo projeto
    /// </summary>
    /// <returns>o Id do projeto criado</returns>
    /// <response code="201">Retorna o Id do item criado</response>
    /// <response code="400">Se o item não for criado</response>   
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateProjectRequest request)
    {
        var projectId = await _createProjectUseCase.ExecuteAsync(request);
        return Ok(projectId);
    }

    /// <summary>
    /// Esse método retorna um lista com todos os projetos de um usuário específico
    /// </summary>
    /// <param name="userid">
    /// 677a4d39-6057-4440-9ccc-374990f3548d
    /// </param>
    /// <returns>Uma lista dos projetos atribuidos ao usuário informado</returns>
    /// <response code="200">Retorna o novo item criado</response>
    /// <response code="404">Se não for encontrado nenhum item</response>    
    [HttpGet()]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllByUserIdAsync(Guid userid)
    {
        var projects = await _listProjetcsUseCase.ExecuteAsync(userid);
        if (projects != null) return Ok(projects);
        return NotFound();
    }

    /// <summary>
    /// Esse método remove o projeto da base de dados de forma logica
    /// </summary>
    /// <param name="projectId">
    /// 677a4d39-6057-4440-9ccc-374990f3548d
    /// </param>
    /// <response code="200">Retorna 200 em caso de sucesso</response>
    /// <response code="400">Se o item não for deletado</response>    
    [HttpDelete()]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(Guid projectId)
    {
        var result = await _deleteProjectsUseCase.ExecuteAsync(projectId);
        if (result) return Ok();
        return BadRequest();
    }
}
