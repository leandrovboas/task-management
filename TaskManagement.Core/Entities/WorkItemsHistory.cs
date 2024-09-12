namespace TaskManagement.Core.Entities;

public class WorkItemsHistory: EntityBase
{
    public WorkItemsHistory(Guid workItemsId, string oldData, string newData, string propertyChanged, Guid changedBy)
    {
        WorkItemsId = workItemsId;
        OldData = oldData;
        NewData = newData;
        PropertyChanged = propertyChanged;
        ChangedBy = changedBy;
            
    }

    public Guid WorkItemsId { get; private set; }
    public string OldData { get; private set; }
    public string NewData { get; private set; }
    public string PropertyChanged { get; private set; }
    public Guid ChangedBy { get; private set; }
    public DateTime ChangedAt { get; private set; } = DateTime.Now;
}
