using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using TaskManagement.Core.Entities;
using TaskManagement.Core.Enums;
using TaskManagement.Core.Repositories;
using TaskManagement.Infrastructure.Configurations;

namespace TaskManagement.Infrastructure.Persistence;

public class WorkItemsRepository : IWorkItemsRepository
{
    private readonly ApplicationDbContext _context;

    public WorkItemsRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(WorkItems WorkItems)
    {
        //_context.WorkItemss.Add(WorkItems);
        //await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        //throw new NotImplementedException();
        return true;
    }

    public async Task<IEnumerable<WorkItems>> GetAll()
    {
        var user1 = Guid.NewGuid();
        var user2 = Guid.NewGuid();
        var projectId = Guid.NewGuid();

        var result = new List<WorkItems>
        {
            new ("Teste1", "Primeiro Teste", WorkItemsPriority.Low, projectId, user1),
            new ("Teste2", "Primeiro Teste", WorkItemsPriority.Low, projectId, user1),
            new ("Teste3", "Primeiro Teste", WorkItemsPriority.Low, projectId, user1),
            new ("Teste4", "Primeiro Teste", WorkItemsPriority.Low, projectId, user1),
            new ("Teste5", "Primeiro Teste", WorkItemsPriority.Low, projectId, user2),
            new ("Teste6", "Primeiro Teste", WorkItemsPriority.Low, projectId, user2)
        };
        return result.AsEnumerable();
    }

    public async Task<IEnumerable<WorkItems>> GetAllByProjectIdAsync(Guid projectId)
    {
        var result = new List<WorkItems>();
        result.Add(new WorkItems("Teste", "Primeiro Teste", WorkItemsPriority.Low, projectId, Guid.NewGuid()));
        return result.AsEnumerable();
    }

    public async Task<WorkItems> GetByIdAsync(Guid id)
    {
        return new WorkItems("Teste", "Primeiro Teste", WorkItemsPriority.Low, Guid.NewGuid(), Guid.NewGuid());
        //return await _context.WorkItemss.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task UpdateAsync(WorkItems WorkItems)
    {
        //_context.WorkItemss.Update(WorkItems);
        //await _context.SaveChangesAsync();
    }
}
