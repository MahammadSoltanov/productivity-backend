using Domain.Entities.Base;

namespace Domain.Entities.Relations;
public class TaskAttachment : Entity
{
    public Attachment Attachment { get; set; }
    public Guid AttachmentId { get; set; }
    public Task Task { get; set; }
    public Guid TaskId { get; set; }
}
