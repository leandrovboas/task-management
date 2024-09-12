using TaskManagement.Core.Enums;

namespace TaskManagement.API.DTOs;

public class UpdateWorkItemsRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public WorkItemsStatus Status { get; set; }
    public Guid UpdatedBy { get; set; }
}