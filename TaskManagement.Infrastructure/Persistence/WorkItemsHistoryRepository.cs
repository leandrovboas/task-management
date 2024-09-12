using TaskManagement.Core.Entities;
using TaskManagement.Core.Repositories;
using TaskManagement.Infrastructure.Configurations;

namespace TaskManagement.Infrastructure.Persistence;

public class WorkItemsHistoryRepository : IWorkItemsHistoryRepository
{
    private readonly ApplicationDbContext _context;

    public WorkItemsHistoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddHistoryAsync(WorkItemsHistory WorkItemsHistory)
    {
        //throw new NotImplementedException();
    }
}
