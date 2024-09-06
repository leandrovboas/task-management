namespace TaskManagement.API.DTOs;

public class AddTaskRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public TaskPriority Priority { get; set; }
    public string CreatedBy { get; set; }
}