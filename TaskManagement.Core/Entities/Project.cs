namespace TaskManagement.Core.Entities;

public class Project
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<Task> Tasks { get; set; }
    public Guid UserId { get; set; }

    public bool CanBeDeleted() => Tasks.All(t => t.Status == Status.Completed);
}