namespace TaskManagement.Core.Entities;
public class Comment : EntityBase
{
    public Comment(string content, Guid workItemsId, Guid createdBy)
    {
        Content = content;
        CreatedBy = createdBy;
        WorkItemsId = workItemsId;
    }

    public string Content { get; set; }
    public Guid WorkItemsId { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
