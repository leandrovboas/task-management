using TaskManagement.Core.Enums;

namespace TaskManagement.Core.Entities;
public class WorkItems : EntityBase
{
    public WorkItems(string title, string description, WorkItemsPriority priority, Guid projectID, Guid UserID)
    {
        this.Priority = priority;
        this.Status = WorkItemsStatus.Pending;
        this.Title = title;
        this.Description = description;
        this.ProjectId = projectID;
        this.CreatedBy = UserID;
        this.CreatedAt = DateTime.Now;
    }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public WorkItemsPriority Priority { get; private set; }
    public WorkItemsStatus Status { get; private set; }
    public Guid ProjectId { get; private set; }
    public Guid CreatedBy { get; private set; }
    public Guid UpdatedBy { get; private set; }
    public DateTime CreatedAt { get; } = DateTime.Now;
    public DateTime UpdatedAt { get; private set; }

    public void ChangeDescription(string description) => this.Description = description;
    public void ChangeTitle(string title) => this.Title = title;
    public void ChangeStatus(WorkItemsStatus status) => this.Status = status;

    public void SetUpdated(DateTime updatedAt, Guid updatedBy)
    {
        this.UpdatedAt = updatedAt;
        this.UpdatedBy = updatedBy;
    }

}
