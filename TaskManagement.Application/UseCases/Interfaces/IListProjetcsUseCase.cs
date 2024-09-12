using TaskManagement.Core.Entities;

namespace TaskManagement.Application.UseCases.Interfaces;

public interface IListProjetcsUseCase
{
    Task<IEnumerable<Project>> ExecuteAsync(Guid userId);
}
