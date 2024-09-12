using TaskManagement.Core.Enums;

namespace TaskManagement.Core.Entities;

public class Project(string name, List<WorkItems> workItems, Guid userId) : EntityBase
{
    private readonly int MAX_WORKITEMS = 20;
    public string Name { get; } = name;
    public List<WorkItems> WorkItems { get; } = workItems;
    public Guid UserId { get; } = userId;
    public bool IsDeleted { get; private set; } = true;

    public bool CanBeDeleted() => WorkItems.All(t => t.Status == WorkItemsStatus.Completed);

    public bool CanBeCreatedWorkItem() => WorkItems.Count < MAX_WORKITEMS;

    public bool ChangeIsDeleted (bool value) => this.IsDeleted = value;
}
