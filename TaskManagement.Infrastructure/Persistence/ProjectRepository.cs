using Microsoft.EntityFrameworkCore;
using TaskManagement.Core.Entities;
using TaskManagement.Core.Repositories;
using TaskManagement.Infrastructure.Configurations;

namespace TaskManagement.Infrastructure.Persistence;

public class ProjectRepository : IProjectRepository
{
    private readonly ApplicationDbContext _context;

    public ProjectRepository(ApplicationDbContext context) =>
        _context = context;

    public async Task<bool> CreateAsync(Project project)
    {
        //_context.Projects.Add(project);
        //await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(Guid projectID)
    {
        return true;
    }

    public async Task<IEnumerable<Project>> GetAllByUserIdAsync(Guid userID) {
        List<Project> projects = [
            new Project("teste", [], userID),
            new Project("teste2", [], userID),
            new Project("teste3", [], userID)
            ];

        return projects.AsEnumerable();

          }

    public async Task<Project> GetByIdAsync(Guid id) => new Project("teste", [], Guid.NewGuid());
        //await _context.Projects
        //    .Include(p => p.WorkItems)
        //    .FirstOrDefaultAsync(p => p.Id == id);

}
