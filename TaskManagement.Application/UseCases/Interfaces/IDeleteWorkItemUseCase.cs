namespace TaskManagement.Application.UseCases.Interfaces;

public interface IDeleteWorkItemUseCase
{
    Task<bool> ExecuteAsync(Guid id);
}
