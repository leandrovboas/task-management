using TaskManagement.API.DTOs;

namespace TaskManagement.Application.UseCases.Interfaces;

public interface ICreateProjectUseCase

{
    Task<Guid> ExecuteAsync(CreateProjectRequest projectRequest);
}