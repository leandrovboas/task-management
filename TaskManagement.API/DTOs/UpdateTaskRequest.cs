namespace TaskManagement.API.DTOs;

public class UpdateTaskRequest
{
    public TaskStatus Status { get; set; }
    public string UpdatedBy { get; set; }
}