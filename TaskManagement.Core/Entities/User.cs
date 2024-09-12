using TaskManagement.Core.Enums;

namespace TaskManagement.Core.Entities;
    public class User : EntityBase
    {
    public required string Name { get; set; }
    public AccessType AccessType { get; set; }
}
