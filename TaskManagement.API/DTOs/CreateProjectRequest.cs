namespace TaskManagement.API.DTOs;

public class CreateProjectRequest
{
    public string Name { get; set; }
    public Guid UserId { get; set; }
}