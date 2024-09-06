using Microsoft.EntityFrameworkCore;
using ProjectManagement.Domain.Entities;
using ProjectManagement.Domain.Repositories;

namespace TaskManagement.Infrastructure.Persistence;

public class ProjectRepository : IProjectRepository
{
    private readonly ApplicationDbContext _context;

    public ProjectRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Project project)
    {
        _context.Projects.Add(project);
        await _context.SaveChangesAsync();
    }

    public async Task<Project> GetByIdAsync(Guid id)
    {
        return await _context.Projects.Include(p => p.Tasks).FirstOrDefaultAsync(p => p.Id == id);
    }

    // Other methods...
}
