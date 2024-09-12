using TaskManagement.Core.Entities;

namespace TaskManagement.Application.DTOs
{
    public class AddCommentRequest
    {
        public string Content { get; set; }
        public Guid WorkItemsId { get; set; }
        public Guid CreatedBy { get; set; }

        public Comment ToEntity() =>
            new(this.Content, this.WorkItemsId, this.CreatedBy );
    }
}
