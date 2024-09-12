namespace TaskManagement.Application.UseCases.Interfaces;

public interface IDeleteProjectsUseCase
{
    Task<bool> ExecuteAsync(Guid projectId);
}
