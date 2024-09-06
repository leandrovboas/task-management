namespace TaskManagement.Core.Entities;
public class Comment
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public Guid TaskId { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
}
