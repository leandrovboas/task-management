using TaskManagement.Core.Entities;

namespace TaskManagement.Core.Repositories;

public interface IWorkItemsHistoryRepository
{
    Task AddHistoryAsync(WorkItemsHistory WorkItemsHistory);
}