using Microsoft.AspNetCore.Mvc;
using TaskManagement.API.DTOs;
using TaskManagement.Application.DTOs;
using TaskManagement.Application.UseCases.Interfaces;

namespace TaskManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    [Produces("application/json")]
    public class WorkItemController : ControllerBase
    {
        private readonly IAddWorkItemsUseCase _addWorkItemsUseCase;
        private readonly IAddCommentUseCase  _addCemmentUseCase;
        private readonly IListWorkItemsUseCase  _listWorkItemsUseCase;
        private readonly IDeleteWorkItemUseCase _deleteWorkItemUseCase;
        private readonly IUpdateWorkItemsUseCase _updateWorkItemsUseCase;

        public WorkItemController(
            IAddWorkItemsUseCase addWorkItemsUseCase, 
            IListWorkItemsUseCase listWorkItemsUseCase,
            IDeleteWorkItemUseCase deleteWorkItemUseCase, 
            IAddCommentUseCase addCemmentUseCase,
            IUpdateWorkItemsUseCase updateWorkItemsUseCase)
        {
            _addWorkItemsUseCase = addWorkItemsUseCase;
            _listWorkItemsUseCase = listWorkItemsUseCase;
            _deleteWorkItemUseCase = deleteWorkItemUseCase;
            _addCemmentUseCase = addCemmentUseCase;
            _updateWorkItemsUseCase= updateWorkItemsUseCase;
        }

        /// <summary>
        /// lista todas as tarefas de um projeto especifico
        /// </summary>
        /// <param name="projectId">
        /// 677a4d39-6057-4440-9ccc-374990f3548d
        /// </param>
        /// <returns>Todas as tarefas de um projeto</returns>
        /// <response code="200">Retorna o novo item criado</response>
        /// <response code="404">Se não for encontrado nenhum item</response>    
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllWorkItems(Guid projectId)
        {
            var WorkItems = await _listWorkItemsUseCase.ExecuteAsync(projectId);
            return Ok(WorkItems);
        }

        /// <summary>
        /// Adiciona uma nova tarefa no projeto
        /// </summary>
        /// <param name="request">
        /// </param>
        /// <returns>o Id da tarefa criado</returns>
        /// <response code="201">Retorna o Id do item criado</response>
        /// <response code="400">Se o item não for criado</response>   
        [HttpPost("addWorkItem")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddWorkItems([FromBody] AddWorkItemsRequest request)
        {
            var workItemsId = await _addWorkItemsUseCase.ExecuteAsync(request);
            return Ok(workItemsId);
        }

        /// <summary>
        /// Esse método remove o projeto da base de dados de forma logica
        /// </summary>
        /// <param name="id">
        /// 677a4d39-6057-4440-9ccc-374990f3548d
        /// </param>
        /// <response code="200">Retorna 200 em caso de sucesso</response>
        /// <response code="400">Se o item não for deletado</response>    
        [HttpDelete()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _deleteWorkItemUseCase.ExecuteAsync(id);
            if (result) return Ok();
            return BadRequest();
        }

        /// <summary>
        /// Adiciona um comentátio na tarefa
        /// </summary>
        /// <param name="request"></param>
        /// <returns>o Id do comentário adcionado</returns>
        /// <response code="201">Retorna o Id do item criado</response>
        /// <response code="400">Se o comentário não for criado</response>   
        [HttpPost("addComment")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddComment([FromBody] AddCommentRequest request)
        {
            var WorkItemsId = await _addCemmentUseCase.ExecuteAsync(request);
            return Ok(WorkItemsId);
        }


        /// <summary>
        /// Atualiza informações da tarefa
        /// </summary>
        /// <param id="request">
        /// 677a4d39-6057-4440-9ccc-374990f3548d
        /// </param>
        /// <returns>o Id do comentário adcionado</returns>
        /// <response code="204">Retorna a tarefa atualizada</response>
        /// <response code="400">Se a atualização não for realizada</response>   
        [HttpPost("{id}/updateWorkItem")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateWorkItem(Guid id, [FromBody] UpdateWorkItemsRequest request)
        {
            return await _updateWorkItemsUseCase.ExecuteAsync(id, request) ? NoContent() : BadRequest();

        }
    }
}
