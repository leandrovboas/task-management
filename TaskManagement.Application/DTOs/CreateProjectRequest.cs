using TaskManagement.Core.Entities;

namespace TaskManagement.API.DTOs;

public class CreateProjectRequest
{
    public string Name { get; set; }
    public List<WorkItems> WorkItems { get; set;  }
    public Guid UserId { get; set; }

    public Project ToEntity() => new(this.Name, this.WorkItems, this.UserId);
}