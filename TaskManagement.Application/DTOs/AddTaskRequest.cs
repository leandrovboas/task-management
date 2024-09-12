using TaskManagement.Core.Entities;
using TaskManagement.Core.Enums;

namespace TaskManagement.API.DTOs;

public class AddWorkItemsRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public WorkItemsPriority Priority { get; set; }
    public Guid CreatedBy { get; set; }
    public Guid ProjectId { get; set; }

    public WorkItems ToEntity() => 
        new(this.Title, this.Description, this.Priority, this.ProjectId, this.CreatedBy);
    
}