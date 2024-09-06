namespace TaskManagement.Core.Entities;

public class TaskHistory
{
    public Guid Id { get; set; }
    public Guid TaskId { get; set; }
    public string Change { get; set; }
    public string ChangedBy { get; set; }
    public DateTime ChangedAt { get; set; }
}
